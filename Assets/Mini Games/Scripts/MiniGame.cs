using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame 
{
    private string _gameName, _instructions, _sceneName;
    private bool _played, _won;
    private float _limitTime, _winTime;

    
    public MiniGame(string gameName, string instructions, string sceneName) 
        :this(gameName, instructions, sceneName, false, false, 0f, -1f) {
            
    }
    public MiniGame(string gameName, string instructions, string sceneName, bool played, bool won, float limitTime, float winTime) {
        _gameName = gameName;
        _instructions = instructions;
        _sceneName = sceneName; 
        _played = played;
        _won = won;
        _limitTime = limitTime;
        _winTime = winTime;
    }


    public string GameName {
        get { return _gameName; }
        set { _gameName = value; }
    }

    public string Instructions {
        get { return _instructions; }
        set { _instructions = value; }
    }

    public bool Played {
        get { return _played; }
        set { _played = value; }
    }

    public bool Won {
        get { return _won;}
        set { _won = value; }
    }

    public float LimitTime {
        get { return _limitTime; }
        set { _limitTime = value; }
    }

    public float WinTime {
        get { return _winTime; }
        set { _winTime = value; }
    }

    public string SceneName {
        get { return _sceneName; }
        set { _sceneName = value; }
    }

}
