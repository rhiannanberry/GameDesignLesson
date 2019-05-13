using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

[System.Serializable]
[CreateAssetMenu(fileName = "MiniGame", menuName = "Scriptable Objects/Mini Game Details", order = 0)]
public class MiniGameDetails : ScriptableObject {
    [SerializeField]
    public string gameName;
    [SerializeField]
    private bool played = false;
    [SerializeField]
    private bool won = false;
    [SerializeField]
    private float limitTime = 0f;
    [SerializeField]
    private float winTime = -1f;

    private string sceneName;


    public void ResetValues() {
        played = false;
        won = false;
        winTime = -1f;
    }


    public string GameName {
        get {return gameName;}
        set {gameName = value;}
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
        get {return sceneName;}
        set {
                sceneName = value;
                if(Application.isEditor) {
                    EditorUtility.SetDirty(this);
                    AssetDatabase.SaveAssets();
                    AssetDatabase.Refresh();
                }
            }
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

