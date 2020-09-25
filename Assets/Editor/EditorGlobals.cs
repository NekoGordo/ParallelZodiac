using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EditorGlobals : Editor
{
    public static bool HideEditors = false;

    
    public const int LABEL_WIDTH = 120;
    const int CONSTRAIN_FIELD = 80;    

    public static GameObject ShowObjectField(string label, float labelWidth, GameObject fieldObject)
    {
        EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(label, GUILayout.Width(labelWidth));
            fieldObject = EditorGUILayout.ObjectField(fieldObject, typeof(GameObject), true) as GameObject;
        EditorGUILayout.EndHorizontal();

        return fieldObject;
    }

    public static Vector3 ShowVector3Field(string label, string X, string Y, string Z, ref Vector3 vectorObject)
    {
        EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(label, GUILayout.Width(LABEL_WIDTH));
            EditorGUILayout.LabelField(X, GUILayout.Width(16));
            vectorObject.x = EditorGUILayout.FloatField(GUIContent.none, vectorObject.x, GUILayout.Width(64));
            EditorGUILayout.LabelField(Y, GUILayout.Width(16));
            vectorObject.y = EditorGUILayout.FloatField(GUIContent.none, vectorObject.y, GUILayout.Width(64));
            EditorGUILayout.LabelField(Z, GUILayout.Width(16));
            vectorObject.z = EditorGUILayout.FloatField(GUIContent.none, vectorObject.z, GUILayout.Width(64));
        EditorGUILayout.EndHorizontal();

        return vectorObject;
    }

    public static float ShowOptionSlider(string label, string left, string right, float labelWidth, float modValue, ref float min, ref float max)
    {
        EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(label, GUILayout.Width(LABEL_WIDTH));
            EditorGUILayout.LabelField(left, GUILayout.Width(labelWidth));
            modValue = GUILayout.HorizontalSlider(modValue, min, max, GUILayout.Width(128));
            EditorGUILayout.LabelField(right, GUILayout.Width(labelWidth));
            modValue = EditorGUILayout.FloatField(GUIContent.none, modValue, GUILayout.Width(CONSTRAIN_FIELD));
        EditorGUILayout.EndHorizontal();

        return modValue;
    }

    public static bool ShowToggle(string prompt, bool toggle)
    {
        EditorGUILayout.BeginHorizontal();
            toggle = EditorGUILayout.Toggle(toggle, GUILayout.Width(16));
            EditorGUILayout.LabelField(prompt);
        EditorGUILayout.EndHorizontal();

        return toggle;
    }

    public static void ShowConstraints(string label, ref float min, ref float max)
    {
        EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(label, GUILayout.Width(LABEL_WIDTH));
            EditorGUILayout.LabelField("Min", GUILayout.Width(56));
            min = EditorGUILayout.FloatField(GUIContent.none, min, GUILayout.Width(80));
            EditorGUILayout.LabelField("Max", GUILayout.Width(56));
            max = EditorGUILayout.FloatField(GUIContent.none, max, GUILayout.Width(80));
        EditorGUILayout.EndHorizontal();
    }
}
