using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]
public class Items : ScriptableObject
{
    public int id;
    public string itemName;
    public string itemDesc;
    public int value;
    public Sprite icon;
    public ItemType itemType;

    public void ItemSelected()
    {
       // InventoryManager.Instance.ShowDescription();
    }

    public enum ItemType
    {
        Healing,
        DamageBuff
    }
}
