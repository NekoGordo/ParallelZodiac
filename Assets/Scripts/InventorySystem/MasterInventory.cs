using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterInventory : MonoBehaviour
{
    public List<BaseItem> masterList;
    // function ReturnInventoryItem returns an item based on a passed
    //    itemID.
    BaseItem ReturnInventoryItem ( int itemID )
    {
        // Search the list for the item indicated by ID and return it
        foreach ( BaseItem item in masterList )
        if ( item.ItemID == itemID ) return item;
        // Return null if the item isn't found
        return null;
    }
}
