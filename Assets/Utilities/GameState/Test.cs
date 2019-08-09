using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : StateManaged
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void Update() {
        base.Update();
        
    }

    public override void EnteringEnter() {
        Debug.Log("OVERRIDE!!!!!!");
    }


}
