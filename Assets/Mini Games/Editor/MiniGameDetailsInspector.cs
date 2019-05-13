using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MiniGameDetails))]
public class MiniGameDetailsInspector : Editor
{
    public override void OnInspectorGUI() {
        DrawDefaultInspector();
        MiniGameDetails detail = (MiniGameDetails)target;
        GUILayout.Label("Scene Name: " + detail.SceneName);
    }
}
