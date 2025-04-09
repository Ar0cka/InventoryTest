using System;
using System.Collections.Generic;
using DefaultNamespace;
using ItemsLogic;
using Unity.Burst.CompilerServices;
using UnityEngine;

namespace InventoryScripts
{
    public class OperationWithAnimal : MonoBehaviour
    {
        private IInventory _inventory;

        [SerializeField] private List<GameObject> frogState;

        public void Initialize(Inventory inventory)
        {
            _inventory = inventory;
        }

        private void ProcessAnimalState(int id, int count, AnimalState requiredState, GameObject newStatePrefab)
        {
            int remainingCount = count;
            foreach (var slot in _inventory.SlotList)
            {
                if (slot.IsOccupied && slot.ItemData.ID == id &&
                    slot.SlotObject.GetComponentInChildren<ItemSettings>() is AnimalSettings animalSettings)
                {
                    if (animalSettings.AnimalState == requiredState && remainingCount > 0)
                    {
                        int itemsToRemove = Mathf.Min(remainingCount, slot.CountItemToSlot);
                        _inventory.RemoveItemFromInventory(id, itemsToRemove, requiredState);
                        _inventory.AddCollectedItem(newStatePrefab, itemsToRemove);
                        remainingCount -= itemsToRemove;
                    }
                }
            }
        }

        public void HitAnimal(int id, int count) => ProcessAnimalState(id, count, AnimalState.Healthy, frogState[0]);
        public void HealAnimal(int id, int count) => ProcessAnimalState(id, count, AnimalState.Wounded, frogState[1]);
    }
}