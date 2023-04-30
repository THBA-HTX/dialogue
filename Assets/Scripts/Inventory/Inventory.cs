using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inventory { 

    public List<ItemData> itemList;

    public static UnityAction OnInventoryHasChanged;

    public Inventory() {

        itemList = new List<ItemData>();



        Debug.Log("Inventory: " + itemList.Count );
    }

    public bool AddItem(ItemData item) {
        Debug.Log("Item added to inventory..");
        itemList.Add(item);
        OnInventoryHasChanged?.Invoke();
        return true;
    
    }

    public List<ItemData> GetItemList() {
        return itemList;
    }

}
