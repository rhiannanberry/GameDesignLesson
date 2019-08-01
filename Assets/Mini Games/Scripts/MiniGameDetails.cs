using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

[System.Serializable]
[CreateAssetMenu(fileName = "MiniGame", menuName = "Scriptable Objects/Mini Game Details", order = 0)]
public class MiniGameDetails : ScriptableObject {
    [SerializeField] public string gameName;
    [SerializeField] private string instructions;
    [SerializeField] private bool played = false;
    [SerializeField] private bool won = false;
    [SerializeField] private float limitTime = 0f;
    [SerializeField] private float winTime = -1f;

    [HideInInspector] [SerializeField] private string sceneName;


    public void ResetValues() {
        played = false;
        won = false;
        winTime = -1f;
    }

    public void Load() {
        if (PlayerPrefs.HasKey("winTime_" + GameName)) {
            WinTime = PlayerPrefs.GetFloat(SaveWinTime);
            Played = (PlayerPrefs.GetInt(SavePlayed) == 1 ? true : false);
            Won = (PlayerPrefs.GetInt(SaveWon) == 1 ? true : false);
        }
    }

    public void Save() {
        PlayerPrefs.SetFloat(SaveWinTime, WinTime);
        PlayerPrefs.SetInt(SavePlayed, Played ? 1 : 0) ;
        PlayerPrefs.SetInt(SaveWon, Won ? 1 : 0);
    }

    public void ClearSave() {
        ResetValues();
        Save();
    }


    public string GameName {
        get {return gameName;}
        set {gameName = value;}
    }

    public string Instructions {
        get {return instructions;}
        set {instructions = value;}
    }

    public bool Played {
        get { return played; }
        set { played = value; }
    }

    public bool Won {
        get {return won;}
        set { won = value; }
    }

    public float LimitTime {
        get { return limitTime; }
        set { limitTime = value; }
    }

    public float WinTime {
        get { return winTime; }
        set { winTime = value; }
    }

    public string SceneName {
        get { return sceneName; }
        set { sceneName = value; }
    }

    public string SavePlayed {
        get {
            return "played_" + GameName;
        }
    }

    public string SaveWon {
        get {
            return "won_" + GameName;
        }
    }
    public string SaveWinTime {
        get {
            return "winTime_" + GameName;
        }
    }
}

