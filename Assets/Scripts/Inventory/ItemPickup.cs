using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{

    private float pickupRadius = 1.0f;
    public ItemData itemData;
    private  BoxCollider2D collider2;
    private  SpriteRenderer sp;
    // Start is called before the first frame update
    void Awake()
    {
        collider2 = GetComponent<BoxCollider2D>();
        collider2.isTrigger = true;
        sp = GetComponent<SpriteRenderer>();
        sp.sprite = itemData.icon;
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Pickup Collision");
        var inventory = other.transform.GetComponent<InventoryHolder>();
        if (inventory == null)
            return;
        Debug.Log("Pickup Collision");
        if (inventory.GetInventory().AddItem(itemData))
        {
            Destroy(this.gameObject);
        }
    }
}
