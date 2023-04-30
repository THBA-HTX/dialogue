using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemType
    {
         Sword,
         HealthPotion,
         ManaPotion,
         Coin,
         Medkit
    }

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite() {

        switch (itemType) {
            case ItemType.Sword: return ItemAssets.instance.swordSprite;
            case ItemType.ManaPotion: return ItemAssets.instance.manaPotionSprite;
            case ItemType.HealthPotion: return ItemAssets.instance.healthPotionSprite;
            case ItemType.Coin: return ItemAssets.instance.coinSprite;
            case ItemType.Medkit: return ItemAssets.instance.medkitSprite;
        }
        return null;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
