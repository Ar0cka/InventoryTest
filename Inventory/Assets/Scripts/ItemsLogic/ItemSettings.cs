using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ItemSettings : MonoBehaviour
{
    [SerializeField] protected ItemScriptableObject itemScriptableObject;
    [SerializeField] protected Image iconItem;

    public ItemScriptableObject ItemScriptableObject => itemScriptableObject;

    protected void Start()
    {
        iconItem.sprite = itemScriptableObject.ItemIcon;
    }
}
