using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MiniGameManager : MonoBehaviour
{
    public MiniGamesList miniGameList;

    [HideInInspector]
    public MiniGameDetails miniGameDetails;

    private bool _running = false;
    private float _time = 0f;

    private static MiniGameManager _instance;

    public static float time {
        get { return _instance._time; }
    }


    void Awake()
    {
        _instance = this;
        SaveLoad.LoadData(miniGameList.GameList);

        MiniGamesList.CurrentGame = miniGameDetails;
    }

    void OnEnable() {
        EventManager.StartListening("Start Scene", StartGame);
        EventManager.StartListening("Time Ran Out", TimeRanOut);
        EventManager.StartListening("Game Lost", GameLost);
        EventManager.StartListening("Game Won", GameWon);
    }

    void OnDisable() {
        EventManager.StopListening("Time Ran Out", TimeRanOut);
        EventManager.StopListening("Game Lost", GameLost);
        EventManager.StopListening("Game Won", GameWon);
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

    void StartGame() {
        _time = miniGameDetails.LimitTime;
        _running = true;
    }

    void GameCompleted() {
        _running = false;
        miniGameDetails.Played = true;
        SaveLoad.SaveLevel(miniGameDetails);
        EventManager.TriggerEvent("Check Run");
    }
    
    void TimeRanOut() {
        
        RunManager.RemoveLife();
        Debug.Log("Time Ran Out");
        GameCompleted();
    }

    void GameLost() {
        RunManager.RemoveLife();
        Debug.Log("Game Lost");
        GameCompleted();
    }

    void GameWon() {
        miniGameDetails.Won = true;
        miniGameDetails.WinTime = miniGameDetails.LimitTime - _time;
        RunManager.AddCompletedLevel(miniGameDetails);
        
        Debug.Log("Game Won");
        GameCompleted();
    }
}
