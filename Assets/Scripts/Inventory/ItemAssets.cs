using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets instance { get; private set; }

    public Sprite swordSprite;
    public Sprite manaPotionSprite;
    public Sprite healthPotionSprite;
    public Sprite coinSprite;
    public Sprite medkitSprite;

    public void Awake()
    {
        instance = this;
    }
}
