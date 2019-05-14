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
        EventManager.StartListening("Game Won", StopTimer);
        EventManager.StartListening("Game Lost", StopTimer);
    }

    void OnDisable() {
        EventManager.StopListening("Game Won", StopTimer);
        EventManager.StopListening("Game Lost", StopTimer);
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
