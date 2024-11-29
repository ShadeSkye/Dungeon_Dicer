using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Items> Items = new List<Items>();

    public Transform ItemContent;
    public GameObject InventoryItem;
    public Transform DescriptionContent;
    public GameObject InventoryItemDesc;
    public GameObject UseItemButton;

    public ItemController[] InventoryItems;

    private void Awake()
    {
        Instance = this;
    }

    public void Add(Items item)
    {
        Items.Add(item);
    }

    public void Remove(Items item)
    {
        Items.Remove(item);
    }

    public void ListItems()
    {
        //Cleans up inventory
        foreach(Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in Items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<Text>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();

            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;

            obj.GetComponent<Button>().onClick.AddListener(()=> ShowDescription(item.itemDesc, item));
        }

        SetInventoryItems();
    }

    public void ShowDescription(string desc, Items items)
    {
        //Debug.Log(InventoryItemDesc);
        //Debug.Log(UseItemButton);

        GameObject obj = Instantiate(UseItemButton, DescriptionContent);
        //var button = obj.transform.Find("Button").GetComponent<Button>();
        //var image = obj.transform.Find("Button").GetComponent<Image>();
        //var text = obj.transform.Find("Text").GetComponent<Text>();

        InventoryItemDesc.SetActive(true);
        InventoryItemDesc.GetComponent<ItemInfoDisplay>().SetItemDescriptionText(desc);
        UseItemButton.transform.Find("UseItemButton(Clone)").GetComponent<Button>().onClick.AddListener(() => ItemController.Instance.UseItem(items));

        //button.enabled = true;
        //image.enabled = true;
        //text.enabled = true;
    }

    public void HideDescription()
    {

        InventoryItemDesc.SetActive(false);
    }

    public void SetInventoryItems()
    {
        InventoryItems = ItemContent.GetComponentsInChildren<ItemController>();

        for(int i = 0; i < Items.Count; i++)
        {
            InventoryItems[i].AddItem(Items[i]);
        }
    }

  // Button.onClick.RemoveAllListeners();
}

