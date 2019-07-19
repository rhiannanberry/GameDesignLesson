using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Use this script as a basis for moving objects.
    With this structure, user input will be ignored before/after
    the duration of the mini-game (See if-statement in Update)



 */

public abstract class Movable : MonoBehaviour
{
    [SerializeField] protected MovableSettings movableSettings;
    private StateManager sm;

    private void Awake() {
        sm = FindObjectOfType<StateManager>();
        if (sm == null) {
            Debug.LogError("Objects inheriting from the Movable class require a state manager to be in the scene.");
        }
    }

    private void FixedUpdate() {
        //TODO: Disable read input before and after game
        Tick();
    }

    private void Update() {
        if (sm.CurrentState == State.inGame) {
            ReadInput();
        } else {
            ClearInput();
        }
    }

    protected abstract void ReadInput();
    protected abstract void ClearInput();
    protected abstract void Tick();

}
