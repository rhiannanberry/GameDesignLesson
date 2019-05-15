using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public bool inRun = true;
    private State pausedState = State.inScene;

    public State currentState = State.inScene;
    void Start()
    {
        GameState.inRun = inRun;
        EventManager.TriggerEvent("Start Scene");
    }

    private void OnEnable() {
        EventManager.StartListening("Start Enter", StartEnter);
        EventManager.StartListening("End Enter", EndEnter);
        EventManager.StartListening("Start Game", StartGame);
        EventManager.StartListening("End Game", EndGame);
        EventManager.StartListening("Start Scene", StartScene);
        EventManager.StartListening("End Scene", EndScene);
        EventManager.StartListening("Start Exit", StartExit);
        EventManager.StartListening("End Exit", EndExit);
        EventManager.StartListening("Start Pause", StartPause);
        EventManager.StartListening("End Pause", EndPause);
    }

    // Update is called once per frame
    void Update()
    {
        currentState = GameState.state;
    }

    void StartEnter() {
        Debug.Log("Start Enter");
        GameState.state = State.inEnter;
    }

    void EndEnter() {
        Debug.Log("End Enter");
        if (inRun) {
            EventManager.TriggerEvent("Start Game");
        } else {
            GameState.state = State.inScene;
        }
    }

    void StartScene() {
        Debug.Log("Start Scene");
        EventManager.TriggerEvent("Start Enter");
    }
    void EndScene() {
        Debug.Log("End Scene");
        GameState.state = State.inScene;
    }

    void StartGame() {
        Debug.Log("Start Game");
        GameState.state = State.inGame;
    }

    void EndGame() {
        Debug.Log("End Game");
        EventManager.TriggerEvent("Start Exit");

    }
    void StartExit() {
        Debug.Log("Start Exit");
        GameState.state = State.inExit;
    }
    void EndExit() {
        Debug.Log("End Exit");
        EventManager.TriggerEvent("End Scene");
    }

    void StartPause() {
        Debug.Log("Start Pause");
        pausedState = GameState.state;
        GameState.state = State.inPause;
    }
    void EndPause() {
        Debug.Log("End Pause");
        GameState.state = pausedState;
    }
}


