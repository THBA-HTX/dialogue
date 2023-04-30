using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryHolder : MonoBehaviour
{
    [SerializeField] public Inventory inventory;
    [SerializeField] private InventoryGUI inventoryGUI;

    public void Awake() {
        inventory = new Inventory();
       

        inventoryGUI.SetInventory(inventory);
    }

    public Inventory GetInventory() {
        return inventory;
    }

}
