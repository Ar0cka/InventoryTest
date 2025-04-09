using System.Collections;
using System.Collections.Generic;
using InventoryScripts;
using UnityEngine;
using UnityEngine.Serialization;

public class TestButton : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private OperationWithAnimal operationWithAnimal;

    [Header("HealAnimal")] 
    [SerializeField][Min(0)] private int idHealAnimal;
    [SerializeField] private int countToHeal;
    
    [Header("HealAnimal")] 
    [SerializeField][Min(0)] private int idHitAnimal;
    [SerializeField] private int countToHit;
    
    [Header("RemoveItems")]
    [SerializeField][Min(0)]private int id;
    [SerializeField] private int removeItemCount = 1;
    
    [Header("AddItems")]
    [SerializeField] private GameObject item;
    [SerializeField] private int countItem;

    public void AddItem()
    {
        inventory.AddCollectedItem(item, countItem);
    }

    public void RemoveItem()
    {
        inventory.RemoveItemFromInventory(id, removeItemCount);
    }

    public void HitAnimal()
    {
        operationWithAnimal.HitAnimal(idHitAnimal, countToHit);
    }

    public void HealAnimal()
    {
        operationWithAnimal.HealAnimal(idHealAnimal, countToHeal);
    }
    
    
}
