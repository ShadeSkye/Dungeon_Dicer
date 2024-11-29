using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Items Items;

    public void Pickup()
    {
        InventoryManager.Instance.Add(Items);
        //DestroyImmediate(this, true);
        gameObject.SetActive(false);
        
    }

    private void OnMouseDown()
    {
        Pickup();
    }
}
