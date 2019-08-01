﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
    private static T instance;

    public static T Instance {
        get {
            if ( instance == null ) {
                GameObject o = new GameObject();
                o.name = typeof( T ).Name;
                instance = o.AddComponent<T>();
            }
            return instance;
        }
    }

    protected virtual void Awake() {
        if ( instance == null ) {
            instance = this as T;
            DontDestroyOnLoad( gameObject );
        } else {
            DestroyImmediate( gameObject );
        }
    }
}
