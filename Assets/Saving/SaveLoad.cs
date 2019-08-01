using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SaveLoad
{
    private static bool startupLoaded = false;
    static public void LoadData(MiniGamesList list) {
        if (startupLoaded) return;

        foreach (MiniGameDetails m in list.GameList) {
            m.Load();
        }

        startupLoaded = true;
    }

    static public void SaveLevel(MiniGameDetails m) {
        m.Save();
    }

    static public void ClearSave(MiniGamesList list) {
        foreach (MiniGameDetails m in list.GameList) {
            m.ClearSave();
        }
    }
}
