using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    TextMeshProUGUI t;

    bool running = true;
    void Awake()
    {
        t = GetComponent<TextMeshProUGUI>();
        EventManager.StartListening("Time Ran Out", TimeRanOut);
        EventManager.StartListening("Game Win", StopTimer);
        EventManager.StartListening("Game Lose", StopTimer);
    }

    void OnDisable() {
        EventManager.StopListening("Game Win", StopTimer);
        EventManager.StopListening("Game Lose", StopTimer);
    }

    void Update() {
        if (running) {
            if (MiniGameManager.time != 0) {
                t.text = String.Format("{0:0.0}", MiniGameManager.time);
            } else { 
                t.text = String.Format("{0:0.0}", MiniGamesList.CurrentGame.LimitTime);
            }
        }
    }

    void StopTimer() {
        running = false;
    }

    void TimeRanOut() {
        t.color = Color.red;
        
    }
}
