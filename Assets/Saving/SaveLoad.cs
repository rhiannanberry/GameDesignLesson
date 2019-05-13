using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SaveLoad
{
    private static bool startupLoaded = false;
    static public void LoadData(MiniGameDetails[] list) {
        if (startupLoaded) return;
        foreach (MiniGameDetails m in list) {
            if (PlayerPrefs.HasKey(m.SaveWinTime)) {
                m.WinTime = PlayerPrefs.GetFloat(m.SaveWinTime);
                m.Played = (PlayerPrefs.GetInt(m.SavePlayed) == 1 ? true : false);
                m.Won = (PlayerPrefs.GetInt(m.SaveWon) == 1 ? true : false);
            }
        }
        startupLoaded = true;
    }

    static public void SaveLevel(MiniGameDetails m) {
        PlayerPrefs.SetFloat(m.SaveWinTime, m.WinTime);
        PlayerPrefs.SetInt(m.SavePlayed, m.Played ? 1 : 0) ;
        PlayerPrefs.SetInt(m.SaveWon, m.Won ? 1 : 0);
    }

    [MenuItem("Saving/Clear Level Saves")]
    static public void ClearSave() {
        string[] guids = AssetDatabase.FindAssets("t:MiniGamesList");
        MiniGamesList[] a = new MiniGamesList[guids.Length];
        for (int i = 0; i < guids.Length; i++) {
            string path = AssetDatabase.GUIDToAssetPath(guids[i]);
            a[i] = AssetDatabase.LoadAssetAtPath<MiniGamesList>(path);
            foreach(MiniGameDetails m in a[i].GameList) {
                m.ResetValues();
                SaveLevel(m);
            }
        }
    }
}
