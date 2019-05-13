using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    Image[] lives;

    void Start() {
        lives = GetComponentsInChildren<Image>();
    }

    void Update() {
        for (int i = 0; i < 3; i++ ){
            lives[i].enabled = !(i + 1 > RunManager.Lives );
        }
    }
}
