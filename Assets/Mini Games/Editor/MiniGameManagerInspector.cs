using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

[CustomEditor(typeof(MiniGameManager))]
public class MiniGameManagerInspector : Editor
{
    bool open = true;
    MiniGameDetails m;

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
        EditorGUILayout.PropertyField(serializedD, new GUIContent("Mini Game Details"), false);

        if (m == null) {
            if (GUILayout.Button("Create New Mini Game Details Asset")){
                MiniGameDetails asset = ScriptableObject.CreateInstance<MiniGameDetails>();
                AssetDatabase.CreateAsset(asset, "Assets/Mini Games/NewMiniGameDetails.asset");
                AssetDatabase.SaveAssets();

                SerializedObject so = new SerializedObject(detail);
                Debug.Log(so.FindProperty("miniGameDetails").displayName);

                serializedD.objectReferenceValue = asset;

            }
        } else {
            open = EditorGUILayout.Foldout(open, "Mini Game Details");
            if (open) {
                EditorGUI.indentLevel++;
                
                detail.miniGameDetails.GameName = EditorGUILayout.TextField("Game Name", detail.miniGameDetails.GameName);
                detail.miniGameDetails.Played = EditorGUILayout.Toggle("Played", detail.miniGameDetails.Played);
                detail.miniGameDetails.Won = EditorGUILayout.Toggle("Won", detail.miniGameDetails.Won);
                detail.miniGameDetails.LimitTime = EditorGUILayout.FloatField("Limit Time", detail.miniGameDetails.LimitTime);
                detail.miniGameDetails.WinTime = EditorGUILayout.FloatField("Win Time", detail.miniGameDetails.WinTime);
                
                

                EditorGUILayout.LabelField("Scene Name", detail.miniGameDetails.SceneName);

                EditorGUI.indentLevel--;
            }
            if (m.SceneName != SceneManager.GetActiveScene().name || m.SceneName == null || m.SceneName == "") {
                detail.miniGameDetails.SceneName = SceneManager.GetActiveScene().name;
            }
        }

        if (m != null) {
            if (!EditorApplication.isPlaying && (m.Played || m.Won || m.WinTime != -1)) {
                    m.ResetValues();
                }
        }
        serializedObject.ApplyModifiedProperties();

    }
}
