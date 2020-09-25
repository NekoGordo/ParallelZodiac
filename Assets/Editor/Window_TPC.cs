using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Window_TPC : EditorWindow
{
    private static Window_TPC instance;

    public static void ShowWindow()
    {
        instance = EditorWindow.GetWindow<Window_TPC>();
        instance.titleContent = new GUIContent("TPC Editor");

        if(!GameObject.Find("ThirdPersonController"))
        {
            string[] playerGUIds = AssetDatabase.FindAssets("ThirdPersonController");
        }
    }
}
