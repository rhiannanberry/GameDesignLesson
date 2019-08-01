using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RunManager : Singleton<RunManager>
{
    public MiniGamesList miniGameList;

    private bool _inRun = false;
    private int _lives = 3;
    private int _runLength;
    private List<MiniGameDetails> _playedGames;

    public void Start()
    {
        if (!_inRun) InitializeRun();

        FlushListeners();
        AssignListeners();
    }

    public void OnEnable() {
        FlushListeners();
        AssignListeners();
    }

    void OnDisable() {
        FlushListeners();
    }

    private void AssignListeners() {
        Debug.Log("ASSIGNING");
        EventManager.StartListening("Run Lost", EndRunLose);
        EventManager.StartListening("Run Win", EndRunWin);
        EventManager.StartListening("End Scene", EndSceneNextGame);
        EventManager.StartListening("Check Run", CheckRunContinue);
    }
    private void FlushListeners() {
        EventManager.StopListening("Run Lost", EndRunLose);
        EventManager.StopListening("Run Win", EndRunWin);
        EventManager.StopListening("End Scene", EndSceneNextGame);
        EventManager.StopListening("Check Run", CheckRunContinue);
    }


    void InitializeRun() {
        _inRun = true;
        _lives = 3;
        _runLength = miniGameList.GetCount() + 1;
        _playedGames = new List<MiniGameDetails>();
    }

    void EndRun() {
        _inRun = false;
        SceneManager.LoadScene(0);

    }

    public void EndRunLose() {
        Debug.Log("Run Lost");
        EndRun();
    }

    private void EndRunWin() {
        Debug.Log("Run Won");
        EndRun();
    }

    public void RemoveLife() {
        _lives -= 1;
        //if (_lives == 0) EventManager.TriggerEvent("Run Lost");
    }

    public void AddCompletedLevel(MiniGameDetails m) {
        _playedGames.Add(m);
        if (_runLength == _playedGames.Count) EventManager.TriggerEvent("Run Won");
    }

    public int Lives { get { return _lives; } }

    public bool InRun { get { return _inRun; } }

    public int RunLength { get { return _runLength; } }

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
            EventManager.TriggerEvent("End Game");
            EventManager.TriggerEvent("Transition To");
        } else {
            EndRunWin();
        }
    }

    void EndSceneNextGame() {
        SceneManager.LoadScene(MiniGamesList.CurrentGame.SceneName);
    }
}
