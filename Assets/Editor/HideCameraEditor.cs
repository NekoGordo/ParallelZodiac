using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CameraBehaviour))]
public class HideCameraEditor : Editor {

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }
}
