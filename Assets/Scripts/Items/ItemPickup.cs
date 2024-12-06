using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Items Items;

    //picks up the item
    public void Pickup()
    {
        InventoryManager.Instance.Add(Items);
        PlayerController.Instance.Score += Items.Score;
        gameObject.SetActive(false);
        
    }
}
