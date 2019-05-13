using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MiniGameSelectManager))]

public class MiniGameSelectManagerInspector : Editor
{
    public override void OnInspectorGUI() {
        DrawDefaultInspector();
        MiniGameSelectManager manager = (MiniGameSelectManager)target;
        if (GUILayout.Button("Update Mini Game List UI")) {
            manager.UpdateGameListUI();
        }
    }
}
