using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IMovableMover 
{
    IMovableInput MovableInput { get; set; }
    Transform TransformToMove { get; set; }
    MovableSettings Settings { get; set;}

    public abstract void Instantiate(IMovableInput movableInput, Transform transformToMove, MovableSettings moveableSettings);

    public abstract void Tick();
}
