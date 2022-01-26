using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour {
    protected Singleton() { }
    private static T Instance;

    private void Awake() {
        Type theType = typeof(T);
        Instance = (T)Convert.ChangeType(this, theType);
    }

    public static T GetInstance() {
        return Instance;
    }
}
