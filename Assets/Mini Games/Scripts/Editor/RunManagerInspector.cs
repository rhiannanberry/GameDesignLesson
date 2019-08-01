using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(RunManager))]
public class RunManagerInspector : Editor
{
    public override void OnInspectorGUI() {
        DrawDefaultInspector();
        RunManager m = (RunManager)target;
        EditorGUILayout.LabelField("In Run", m.InRun.ToString());
        EditorGUILayout.LabelField("Lives", m.Lives.ToString());
        EditorGUILayout.LabelField("Run Length", m.RunLength.ToString());
    }
}
