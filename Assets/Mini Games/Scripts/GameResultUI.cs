using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameResultUI : MonoBehaviour
{
    [Range(.1f, 1f)]
    public float appearLength = .2f;
    public GameResultData winResult, loseResult;
    private System.Random _random;

    void Awake() {
        winResult.resultObject.SetActive(false);
        loseResult.resultObject.SetActive(false);
        _random = new System.Random();
    }

    void OnEnable() {
        EventManager.StartListening("Game Win", GameWin);
        EventManager.StartListening("Game Lose", GameLose);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GameResult(GameResultData g) {
        StartCoroutine(Coroutines.Lerp(0, 1, appearLength, (position) => {
            transform.localScale = Vector3.one * position;
        }));
        g.resultObject.SetActive(true);
        g.resultObject.GetComponentInChildren<TextMeshProUGUI>().text = g.response[_random.Next(0, g.response.Length - 1)];
    }

    void GameWin() {
        GameResult(winResult);
    }

    void GameLose() {
        GameResult(loseResult);
    }
}

[System.Serializable]
public class GameResultData {
    public GameObject resultObject;
    public string[] response;
}
