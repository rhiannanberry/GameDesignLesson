﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GotoNextGame(MiniGamesList list) {
        MiniGameDetails d = list.GetNext();
        if (d != null) {
            MiniGamesList.CurrentGame = d;
            Debug.Log("LOADING SCENE: " + d.SceneName);
            SceneManager.LoadScene(d.SceneName);
        }
    }
}
