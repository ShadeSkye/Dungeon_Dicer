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

    //adds items to the list
    public void Add(Items item)
    {
        Items.Add(item);
    }

    //removes items from the list
    public void Remove(Items item)
    {
        Items.Remove(item);
    }

    //displays the items in the inventory
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

            obj.GetComponent<Button>().onClick.RemoveAllListeners();
            obj.GetComponent<Button>().onClick.AddListener(()=> ShowDescription(item.itemDesc, item, obj));
        }

        SetInventoryItems();
    }

    //shows the description ui
    public void ShowDescription(string desc, Items items, GameObject target)
    {
        InventoryItemDesc.SetActive(true);
        InventoryItemDesc.GetComponent<ItemInfoDisplay>().SetItemDescriptionText(desc);

        var button = UseItemButton.transform.Find("Button").GetComponent<Button>();

        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() => ItemController.Instance.UseItem(items));
        button.onClick.AddListener(() => Destroy(target));
    }

    //hides the description ui
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

