using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Master Inventory", menuName = "Scriptable Objects/Spawn Master Inventory Object", order = 1)]
[System.Serializable]
public class MasterInventory_SO : ScriptableObject
{
    public List<BaseItem> masterInventory;

    public void CreateEmptyInventory()
    {
        masterInventory = new List<BaseItem>();
    }

    public void CopyInventory(List<BaseItem> inventorycpy)
    {
        masterInventory = inventorycpy;
    }
}
