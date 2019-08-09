using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateManaged : MonoBehaviour
{
    private static bool _in, _entering, _exiting = false;
    private static NewGameState _state;

    


    public virtual void Update() {
        
        if (_entering) {
            switch(_state) {
                case NewGameState.ENTER: EnteringEnter(); break;
                case NewGameState.MENU: EnteringMenu(); break;
                case NewGameState.GAME: EnteringGame(); break;
                case NewGameState.PAUSE: EnteringPause(); break;
                case NewGameState.EXIT: EnteringExit(); break;
            }
        } else if (_in) {
            switch(_state) {
                case NewGameState.ENTER: InEnter(); break;
                case NewGameState.MENU: InMenu(); break;
                case NewGameState.GAME: InGame(); break;
                case NewGameState.PAUSE: InPause(); break;
                case NewGameState.EXIT: InExit(); break;
            }
        } else if (_exiting) {
            switch(_state) {
                case NewGameState.ENTER: ExitingEnter(); break;
                case NewGameState.MENU: ExitingMenu(); break;
                case NewGameState.GAME: ExitingGame(); break;
                case NewGameState.PAUSE: ExitingPause(); break;
                case NewGameState.EXIT: ExitingExit(); break;
            }
        }
        
        _in = false;
        _entering = false;
        _exiting = false;
    }

    //will run through states if nothing is overriding

    public virtual void EnteringEnter() {

    }
    public virtual void InEnter() {
        Debug.Log("IN ENTER");
        GameStateManager.Instance.ToMenu();
    }
    public virtual void ExitingEnter() {}

    public virtual void EnteringGame() {}
    public virtual void InGame() {}
    public virtual void ExitingGame() {}

    public virtual void EnteringMenu() {}
    public virtual void InMenu() {}
    public virtual void ExitingMenu() {}

    public virtual void EnteringPause() {}
    public virtual void InPause() {}
    public virtual void ExitingPause() {}

    public virtual void EnteringExit() {}
    public virtual void InExit() {
        Debug.Log("IN EXIT");
        GameStateManager.Instance.ToExitComplete();
    }
    public virtual void ExitingExit() {}



    public static void SetState(NewGameState s, Timing t) {
        _state = s;
        SetTiming(t);
    }

    private static void SetTiming(Timing t) {
        switch(t) {
            case Timing.ENTERING: _entering = true; break;
            case Timing.IN: _in = true; break;
            case Timing.EXITING: _exiting = true; break;
        }
    }
}


public enum NewGameState {ENTER, EXIT, GAME, MENU, PAUSE};
public enum Timing {ENTERING, IN, EXITING};