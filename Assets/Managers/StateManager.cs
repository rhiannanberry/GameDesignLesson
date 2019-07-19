using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Relies on the EventManager system.
    
    Transmits/Triggers state changes that are important for various
    systems and objects.

    STATES:
        inEnter
        inScene
        inGame
        inExit
        inPause

    STATE EVENTS:
        Start Enter
        End Enter
        Start Game
        End Game
        Start Scene
        End Scene
        Start Exit
        End Exit
        Start Pause
        End Pause

 */

public class StateManager : MonoBehaviour
{
    [SerializeField] private bool inRun = true;
    private State pausedState = State.inScene;
    [SerializeField] private State currentState = State.inScene;

    public State CurrentState { get { return currentState; } }

    private void Awake() {
        if (FindObjectOfType<EventManager>() == null) {
            Debug.LogError("StateManager requires having an EventManager in the scene.");
        }
    }

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


