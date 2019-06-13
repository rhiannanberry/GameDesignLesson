using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movable : MonoBehaviour
{
    [SerializeField] protected MovableSettings movableSettings;
    private StateManager sm;
    public static bool canMove = false;


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
        if (sm.currentState == State.inGame) {
            ReadInput();
        } else {
            ClearInput();
        }
    }

    protected abstract void ReadInput();
    protected abstract void ClearInput();
    protected abstract void Tick();

}
