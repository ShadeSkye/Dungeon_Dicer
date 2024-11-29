using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ItemInfoDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI itemDescription;



    public void SetItemDescriptionText(string description)
    {
        itemDescription.text = description;
    }
}
