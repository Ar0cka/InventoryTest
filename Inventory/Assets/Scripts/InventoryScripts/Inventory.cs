using System.Collections.Generic;
using DefaultNamespace;
using InventoryScripts;
using ItemsLogic;
using UnityEngine;

public class Inventory : MonoBehaviour, IInventory
{
    [SerializeField] private int countSlots;
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private Transform parentSlot;

    private List<SlotData> _slotsList = new List<SlotData>();

    public List<SlotData> SlotList => _slotsList;

    public void Initialize()
    {
        for (int i = 0; i < countSlots; i++)
        {
            var slotObject = Instantiate(slotPrefab, parentSlot);
            _slotsList.Add(new SlotData(slotObject));
        }
    }

    public void AddCollectedItem(GameObject itemForSpawn, int countItem)
    {
        if (itemForSpawn == null || countItem <= 0) return;
        ItemSettings itemSettings = itemForSpawn.GetComponent<ItemSettings>();
        if (itemSettings == null) return;

        int remainingItems = countItem;
        foreach (var slot in _slotsList)
        {
            if (remainingItems == 0) break;
            if (slot.IsOccupied && slot.ItemData.ID == itemSettings.ItemScriptableObject.ID && !slot.IsFull)
            {
                if (CheckItemType(itemSettings, slot))
                {
                    remainingItems = slot.AddItems(remainingItems, itemSettings.ItemScriptableObject);
                }
            }
            else if (!slot.IsOccupied)
            {
                Instantiate(itemForSpawn, slot.SlotObject.transform);
                remainingItems = slot.AddItems(remainingItems, itemSettings.ItemScriptableObject);
            }
        }
        if (remainingItems != 0) Debug.Log("Не осталось слотов");
    }

    public void RemoveItemFromInventory(int id, int countRemove, AnimalState? animalState = null)
    {
        int remainingToRemove = countRemove;
        foreach (var slot in _slotsList)
        {
            if (slot.ItemData == null) return;
            
            if (slot.IsOccupied && slot.ItemData.ID == id)
            {
                bool stateMatches = animalState == null || 
                                    (slot.SlotObject.GetComponentInChildren<ItemSettings>() is AnimalSettings animalSettings && 
                                     animalSettings.AnimalState == animalState);

                if (stateMatches)
                {
                    int itemsToRemove = Mathf.Min(remainingToRemove, slot.CountItemToSlot);
                    bool isRemovedFromInventory = slot.RemoveItemFromSlot(itemsToRemove);
                    Debug.Log(isRemovedFromInventory);
                    GameObject item = slot.SlotObject.GetComponentInChildren<ItemSettings>().gameObject;
                    if (isRemovedFromInventory) Destroy(item);
                    remainingToRemove -= itemsToRemove;
                }
            }
        }
    }

    private bool CheckItemType(ItemSettings itemSettings, SlotData slot)
    {
        switch (itemSettings.ItemScriptableObject.ItemType)
        {
            case ItemType.Animal:
                if (itemSettings is AnimalSettings animalSettings)
                    return slot.CheckAnimalStateInSlot(animalSettings.AnimalState);
                break;
            default: return true;
        }

        return false;
    }
}