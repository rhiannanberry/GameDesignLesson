using UnityEngine;
using UnityEditor;
using System.Collections;

class EventLog : EditorWindow {
    [MenuItem ("Window/EventLog")]

    public static void  ShowWindow () {
        EditorWindow.GetWindow(typeof(EventLog));
    }
    
    void OnGUI () {
        if (FindObjectOfType<EventManager>() == null) {
            //Debug.LogError("StateManager requires having an EventManager in the scene.");
        } else {
            string[] events = EventManager.GetEvents();
            foreach(string e in events) {
                GUILayout.Label(e);
            }
        }
    }
}