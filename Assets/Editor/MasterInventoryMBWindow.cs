using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MasterInventoryMBWindow : EditorWindow
{
    List<BaseItem> masterInventorycpy;

    public static void Init()
    {
        MasterInventoryMBWindow window = (MasterInventoryMBWindow)EditorWindow.GetWindow(typeof(MasterInventoryMBWindow));
        window.Show();
    }

    private void Awake()
    {
        masterInventorycpy = MasterInventory_MB.masterInventory;        
    }
}