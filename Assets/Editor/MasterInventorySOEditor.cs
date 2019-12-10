using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MasterInventory_SO))]
public class MasterInventorySOEditor : Editor
{
    const float HEADER_SIZE = 128.0f;
    const float FIELD_SIZE = 128.0f;
    MasterInventory_SO masterInventorySO;
    List<BaseItem> masterInventoryList;
    int currentIndex;

    private void OnEnable()
    {
        currentIndex = 0;
        masterInventorySO = (MasterInventory_SO)target;
        if (masterInventorySO.masterInventory == null)
            masterInventorySO.CreateEmptyInventory();
        masterInventoryList = masterInventorySO.masterInventory;
    }


    public override void OnInspectorGUI()
    {
        
        //base.OnInspectorGUI();
        if(masterInventoryList.Count < 1)
        {
            if (GUILayout.Button("Add Inventory Item"))
                AddInventoryItem();
        }
        else
        {
            /**
             * Display:
             * Item ID
             * Item Name
             * Item Price
             * Item Rarity
             * Flavour Text
             * 
             * 
             */
            EditorGUILayout.BeginVertical();
                LabelField("Item ID:", masterInventoryList[currentIndex].ItemID.ToString());
                masterInventoryList[currentIndex].ItemName = TextField("Item Name: ", masterInventoryList[currentIndex].ItemName);
                masterInventoryList[currentIndex].ItemPrice = IntField("Item Price: ", masterInventoryList[currentIndex].ItemPrice);
                masterInventoryList[currentIndex].ItemRarity = TextField("Item Rarity: ", masterInventoryList[currentIndex].ItemRarity);
                masterInventoryList[currentIndex].FlavourText = TextArea("Item Description", masterInventoryList[currentIndex].FlavourText);
            EditorGUILayout.EndVertical();
        }

        SaveInventory();
    }

    void AddInventoryItem()
    {
        BaseItem newItem = new BaseItem();
        newItem.ItemName = "New Item";
        newItem.ItemPrice = 0;
        newItem.ItemRarity = "Common";
        newItem.FlavourText = "Your newly created item. Better give it a more creative description than this.";
        newItem.SetItemID(masterInventoryList.Count);
        masterInventoryList.Add(newItem);
    }

    void LabelField(string header, string label)
    {
        EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(header, GUILayout.Width(HEADER_SIZE));
            EditorGUILayout.LabelField(label, GUILayout.Width(FIELD_SIZE));
        EditorGUILayout.EndHorizontal();
    }

    string TextField(string header, string text)
    {
        string returnText = text;
        EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(header, GUILayout.Width(HEADER_SIZE));
            returnText = EditorGUILayout.TextField(returnText, GUILayout.Width(FIELD_SIZE));
        EditorGUILayout.EndHorizontal();
        return returnText;
    }

    string TextArea(string header, string text)
    {
        EditorStyles.textArea.wordWrap = true;
        string returnText = text;
        EditorGUILayout.BeginVertical();
            EditorGUILayout.LabelField(header, GUILayout.Width(HEADER_SIZE));
            returnText = EditorGUILayout.TextArea(returnText, GUILayout.Height(64));
        EditorGUILayout.EndVertical();
        return returnText;
    }

    int IntField(string header, int num)
    {
        int returnInt = num;
        EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(header, GUILayout.Width(HEADER_SIZE));
            returnInt = EditorGUILayout.IntField(returnInt, GUILayout.Width(FIELD_SIZE));
        EditorGUILayout.EndHorizontal();
        return returnInt;
    }

    void SaveInventory()
    {
        masterInventorySO.masterInventory = masterInventoryList;
        EditorUtility.SetDirty(masterInventorySO);
    }

}
