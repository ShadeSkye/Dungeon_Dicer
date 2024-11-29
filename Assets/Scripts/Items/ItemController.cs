using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public static ItemController Instance;

    public Items items;

    private void Awake()
    {
        Instance = this;
    }

    //removes the used item
    public void RemoveItem(Items items)
    {
        InventoryManager.Instance.Remove(items);

        InventoryManager.Instance.HideDescription();
    }

    public void AddItem(Items newItem)
    {
        items = newItem;
    }

    //uses a selected item
    public void UseItem(Items items)
    {
        switch (items.itemType)
        {
            case Items.ItemType.Healing:
                PlayerController.Instance.Heal(items.value);
                break;

            case Items.ItemType.DamageBuff:
                PlayerController.Instance.IncreaseAttack(items.value);
                break;
        }
        RemoveItem(items);
    }

    public void ResetButton()
    {
        Destroy(InventoryManager.Instance.UseItemButton.gameObject);
    }
}
