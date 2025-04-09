using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenAndCloseInventory : MonoBehaviour
{
    [SerializeField] private GameObject inventoryPanel;
    
    public void OpenInventory()
    {
        if (inventoryPanel !=  null)
        inventoryPanel.SetActive(!inventoryPanel.activeSelf);
    }
}
