using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Inventory/Add item")]
public class ItemData : ScriptableObject 
{
    public int ID;
    public string displayName;
    [TextArea(4,4)]
    public string description;
    public Sprite icon;
    public int maxStackSize = 1;
}
