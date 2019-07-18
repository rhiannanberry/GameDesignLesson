using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MiniGameManager : MonoBehaviour
{
    public MiniGamesList miniGameList;

    public MiniGameDetails miniGameDetails;

    private bool _running = false;
    private float _time = 0f;

    private static MiniGameManager _instance;

    public static float time {
        get { return _instance._time; }
    }

    public static string gameName {
        get { return _instance.miniGameDetails.GameName; }
    }


    void Awake()
    {
        _instance = this;
        SaveLoad.LoadData(miniGameList.GameList);

        MiniGamesList.CurrentGame = miniGameDetails;
    }

    void OnEnable() {
        EventManager.StartListening("Start Scene", StartScene);
        EventManager.StartListening("Start Game", StartGame);
        EventManager.StartListening("Time Ran Out", TimeRanOut);
        EventManager.StartListening("Game Lose", GameLost);
        EventManager.StartListening("Game Win", GameWon);
    }

    void OnDisable() {
        EventManager.StopListening("Time Ran Out", TimeRanOut);
        EventManager.StopListening("Game Lose", GameLost);
        EventManager.StopListening("Game Win", GameWon);
    }

    void Update() {
        if (_time > 0 && _running) {
            _time -= Time.deltaTime;
            _time = Mathf.Max(time, 0);
            if (_time == 0) {
                EventManager.TriggerEvent("Time Ran Out");
            }
        }
    }

    void StartScene() {
        _time = miniGameDetails.LimitTime;
    }

    void StartGame() {
        _running = true;
    }

    IEnumerator GameCompleted() {
        _running = false;
        miniGameDetails.Played = true;
        SaveLoad.SaveLevel(miniGameDetails);
         yield return new WaitForSeconds(2);
        EventManager.TriggerEvent("Check Run");
    }
    
    void TimeRanOut() {        
        Debug.Log("Time Ran Out");
        EventManager.TriggerEvent("Game Lose");
    }

    void GameLost() {
        RunManager.RemoveLife();
        Debug.Log("Game Lose");
        StartCoroutine(GameCompleted());
    }

    void GameWon() {
        miniGameDetails.Won = true;
        miniGameDetails.WinTime = miniGameDetails.LimitTime - _time;
        RunManager.AddCompletedLevel(miniGameDetails);
        
        Debug.Log("Game Win");
        StartCoroutine(GameCompleted());
    }
}
