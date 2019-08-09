using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

[RequireComponent(typeof(Animator))]
public class GameStateManager : Singleton<GameStateManager>
{
    private Animator _stateMachine;
    public bool inRun = true;
    private Run _run = null;
    [SerializeField] private MiniGamesList _list;
    private MiniGame[] _miniGames;
    private string _nextScene;

    public MiniGame[] MiniGames { get{ return _miniGames; } }

    protected override void Awake() {

        base.Awake();

        _stateMachine = GetComponent<Animator>();
        _miniGames = _list.MiniGameList;
        InitializeRun(_miniGames[0]);

    }
    

    public void InitializeRun(MiniGame startingGame) {
        _run = new Run(_miniGames, startingGame);
        Debug.Log("Run Initialized");
    }

    public void ToMenu() {
        _stateMachine.SetTrigger("ToMenu");
    }

    public void ToGame() {
        _stateMachine.SetTrigger("ToGame");
    }

    public void ToExit() {
        _stateMachine.SetTrigger("ToExit");
    }

    public void ToExitComplete() {
        _stateMachine.SetTrigger("ToExitComplete");
    }
    

    public void EndGame(bool won) {
        //use result from run to determine next scene
    }

    public void StartRun(string sceneName) {
        //TODO: Start run should probably have to do with Run run
        _nextScene = sceneName;
        ToExit();
    }

    public void GotoScene() {
        SceneManager.LoadScene(_nextScene);
    }

}
