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
        EventManager.StartListening("Game Won", StopTimer);
        EventManager.StartListening("Game Lost", StopTimer);
    }

    void OnDisable() {
        EventManager.StopListening("Game Won", StopTimer);
        EventManager.StopListening("Game Lost", StopTimer);
    }

    void Update() {
        if (running) {
            t.text = String.Format("{0:0.0}", MiniGameManager.time);
        }
    }

    void StopTimer() {
        running = false;
    }
}
