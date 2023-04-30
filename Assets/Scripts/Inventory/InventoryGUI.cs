using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryGUI : MonoBehaviour
{
    private Inventory inventory;
    private Transform inventoryGUI;
    private GameObject inventoryGrid;
    public GameObject itemSlotPrefab;

    public void Awake()
    {
       inventoryGrid = GameObject.Find("GridBg");
    }

    public void OnEnable()
    {
        Inventory.OnInventoryHasChanged += RefreshInventoryItems;
    }

    public void OnDisable()
    {
        Inventory.OnInventoryHasChanged -= RefreshInventoryItems;
    }

    public void SetInventory(Inventory inv) {
        inventory = inv;
        if (inventory != null )
            Debug.Log("Iventory found");
        //RefreshInventoryItems();
    }
        
    public void RefreshInventoryItems() {

        Debug.Log("RefreshAction was evoked");

        int x = 0;
        int y = 0;
        //float itemSlotCellSize = 20f;
        int numColumns = 4;
        foreach (Transform child in inventoryGrid.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        foreach (var item in inventory.GetItemList())
        {
            GameObject obj = Instantiate(itemSlotPrefab, inventoryGrid.transform);
            obj.SetActive(true);

            var itemIcon = obj.transform.Find("ItemImage").GetComponent<Image>();
            itemIcon.enabled = true;
            itemIcon.sprite = item.icon;

            //Image image = allChildren[x].GetComponent<Image>();
            //image.sprite = item.icon;

            x++;
            if (x > numColumns) {
                x = 0;
                y++;
            }
        }
    }
}
