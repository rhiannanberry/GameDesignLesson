using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableMover 
{
    private readonly IMovableInput movableInput;
    private readonly Transform transformToMove;
    private readonly MovableSettings movableSettings;

    public MovableMover(IMovableInput movableInput, Transform transformToMove, MovableSettings movableSettings) {
        this.movableInput = movableInput;
        this.transformToMove = transformToMove; 
        this.movableSettings = movableSettings;
    }

    public void Tick() {
        //simple rn
        transformToMove.position +=  new Vector3(movableInput.Horizontal, movableInput.Vertical, 0) * movableSettings.MoveSpeed * Time.deltaTime;
    }
}
