using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseItem {
    public string ItemName { get; set; }
    public string FlavourText { get; set; }
    public int ItemPrice { get; set; }
    public int ItemID { get; private set; }
    public string ItemRarity { get; set; }

    public void SetItemID(int itemID)
    {
        ItemID = itemID;
    }
}
