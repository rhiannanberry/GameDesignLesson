using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

[CustomEditor(typeof(MiniGameManager))]
public class MiniGameManagerInspector : Editor
{    MiniGameDetails m;

    SerializedProperty serializedD;

    void OnEnable () {
        // Setup the SerializedProperties
        serializedD = serializedObject.FindProperty ("miniGameDetails");
    }
    public override void OnInspectorGUI() {
        serializedObject.Update();
        DrawDefaultInspector();
        MiniGameManager detail = (MiniGameManager)target;
        m = detail.miniGameDetails;

        if (m == null) {
            if (GUILayout.Button("Create New Mini Game Details Asset")){
                MiniGameDetails asset = ScriptableObject.CreateInstance<MiniGameDetails>();
                AssetDatabase.CreateAsset(asset, "Assets/Mini Games/NewMiniGameDetails.asset");
                AssetDatabase.SaveAssets();

                SerializedObject so = new SerializedObject(detail);

                serializedD.objectReferenceValue = asset;

            }
        } 

        if (m != null) {
            if (m.SceneName != SceneManager.GetActiveScene().name) {
                serializedD.serializedObject.Update();
                m.SceneName = SceneManager.GetActiveScene().name;
                serializedD.serializedObject.ApplyModifiedProperties();
            }
            if (!EditorApplication.isPlaying && (m.Played || m.Won || m.WinTime != -1)) {
                    m.ResetValues();
                }
        }
        serializedObject.ApplyModifiedProperties();

    }
}
