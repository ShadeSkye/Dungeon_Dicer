using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ItemInfoDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI itemDescription;


    //chnages the description text for each item
    public void SetItemDescriptionText(string description)
    {
        itemDescription.text = description;
    }
}
