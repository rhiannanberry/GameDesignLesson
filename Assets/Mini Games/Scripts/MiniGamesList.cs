using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Malee;

[CreateAssetMenu(fileName = "Mini Games List", menuName = "Scriptable Objects/Mini Games List", order = 0)]
public class MiniGamesList : ScriptableObject {

    [SerializeField, Reorderable(paginate = true, pageSize = 0)]
    private ReorderableGameList gameList;
    
    private static MiniGameDetails currentGame = null;


    public int GetCount() {
        return gameList.Count;
    }


    public MiniGameDetails GetNext()  {
        if (currentGame == null) return null;
        int currentIndex = gameList.IndexOf(currentGame);
        if (currentIndex+1 >= gameList.Count) {
            return null;
        } 
        return gameList[currentIndex + 1];
    }

    public MiniGameDetails[] GameList {
        get {
            return gameList.ToArray();
        }
    }

    public MiniGame[] MiniGameList {
        get {

            MiniGame[] ms = new MiniGame[GetCount()];
            MiniGameDetails[] gl = GameList;
            
            for (int i = 0; i < GetCount(); i++) {
                ms[i] = gl[i].ToMiniGame();
            }
            return ms;
        }
    }

    public static MiniGameDetails CurrentGame {
        get { return currentGame; }
        set { currentGame = value; }
    }

    public void ResetSaveValues() {
        foreach(MiniGameDetails m in gameList) {
            m.ResetValues();
        }
    }


    [System.Serializable]
    private class ReorderableGameList : ReorderableArray<MiniGameDetails>{

    }
}
