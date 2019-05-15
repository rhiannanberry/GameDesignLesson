using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RunManager : MonoBehaviour
{
    public MiniGamesList miniGameList;

    private static bool _inRun = false;
    private static int _lives = 3;
    private static int _runLength;
    private static List<MiniGameDetails> _playedGames;


    void Start()
    {
        if (!_inRun) InitializeRun();
        //EventManager.TriggerEvent("Transition From");
    }

    void OnEnable() {
        EventManager.StartListening("Run Lost", EndRunLose);
        EventManager.StartListening("Run Win", EndRunWin);
        EventManager.StartListening("End Scene", EndSceneNextGame);
        EventManager.StartListening("Check Run", CheckRunContinue);
    }

    void OnDisable() {
        EventManager.StopListening("Run Lost", EndRunLose);
        EventManager.StopListening("Run Win", EndRunWin);
    }

    void InitializeRun() {
        _inRun = true;
        _lives = 3;
        _runLength = miniGameList.GetCount();
        _playedGames = new List<MiniGameDetails>();
    }

    static void EndRun() {
        _inRun = false;
        SceneManager.LoadScene(0);

    }

    public static void EndRunLose() {
        Debug.Log("Run Lost");
        EndRun();
    }

    private static void EndRunWin() {
        Debug.Log("Run Won");
        EndRun();
    }

    public static void RemoveLife() {
        _lives -= 1;
        //if (_lives == 0) EventManager.TriggerEvent("Run Lost");
    }

    public static void AddCompletedLevel(MiniGameDetails m) {
        _playedGames.Add(m);
        if (_runLength == _playedGames.Count) EventManager.TriggerEvent("Run Won");
    }

    public static int Lives {
        get {return _lives;}
    }

    void CheckRunContinue() {
        Debug.Log("CHECKING RUN");
        if (_lives == 0) {
            EndRunLose();
            return;
        }

        MiniGameDetails d = miniGameList.GetNext();
        if (d != null) {
            MiniGamesList.CurrentGame = d;
            Debug.Log("LOADING SCENE: " + d.SceneName);
            EventManager.TriggerEvent("Start Exit");
            EventManager.TriggerEvent("Transition To");
        } else {
            EndRunWin();
        }
    }

    void EndSceneNextGame() {
        SceneManager.LoadScene(MiniGamesList.CurrentGame.SceneName);
    }
}
