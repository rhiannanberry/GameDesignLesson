using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movable : MonoBehaviour
{
    [SerializeField] private MovableSettings movableSettings;

    //private IMovableInput movableInput;
    //private MovableMover movableMover;

    private void Awake() {
        //movableInput = movableSettings.UseAi ? new PlayerMovableInput() as IMovableInput : new PlayerMovableInput();
        //TODO: manage different movement schemes
        //movableMover = new MovableMover(movableInput, transform, movableSettings); 
    }

    private void Update() {
        //TODO: Disable read input before and after game
        ReadInput();
        Tick();
    }

    protected abstract void ReadInput();
    protected abstract void Tick();
}
