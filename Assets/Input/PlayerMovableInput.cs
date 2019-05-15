using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovableInput : IMovableInput
{
    public void ReadInput() {
        Horizontal = Input.GetAxisRaw("Horizontal");
        Vertical = Input.GetAxisRaw("Vertical");
        RotationKeyboard = Horizontal;
        

    }

    public float Horizontal { get; private set; }
    public float Vertical { get; private set; }
    public float RotationKeyboard { get; private set; }
    public float RotationMouse { get; private set; }
    public bool Jump { get; private set; }
}
