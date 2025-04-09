using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using ItemsLogic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SlotData
{
        public bool IsFull { get; private set; }
        public bool IsOccupied { get; private set; }
        
        public int CountItemToSlot { get; private set; }
    
        public ItemScriptableObject ItemData { get; private set;}
        
        public GameObject SlotObject { get; private set; }
        
        private TextMeshProUGUI _itemCountText;

        public SlotData(GameObject slotObject)
        {
            SlotObject = slotObject;
            IsFull = false;
            IsOccupied = false;
            CountItemToSlot = 0;
            _itemCountText = slotObject.GetComponentInChildren<TextMeshProUGUI>();
            _itemCountText.text = "";
        }
        
        public int AddItems(int countToAdd, ItemScriptableObject item)
        {
            if (!IsOccupied)
            {
                IsOccupied = true;
                ItemData = item;
            }

            int spaceLeft = ItemData.MaxStackInSlot - CountItemToSlot;
            int itemsToAdd = Mathf.Min(countToAdd, spaceLeft);
        
            CountItemToSlot += itemsToAdd;
            UpdateTextInSlot();

            IsFull = CountItemToSlot == ItemData.MaxStackInSlot;
            return countToAdd - itemsToAdd;
        }

        public bool RemoveItemFromSlot(int countItemRemove)
        {
            CountItemToSlot -= countItemRemove;
            UpdateTextInSlot();

            if (CountItemToSlot <= 0)
            {
                IsOccupied = false;
                IsFull = false;
                return true;
            }

            return false;
        }
        
        public void UpdateTextInSlot()
        {
            if (CountItemToSlot <= 0)
            {
                _itemCountText.text = "";
                return;
            }
            
            _itemCountText.text = CountItemToSlot.ToString();
        }
        
        public bool CheckAnimalStateInSlot(AnimalState animalState)
        {
            ItemSettings itemSettings = SlotObject.GetComponentInChildren<AnimalSettings>();
            
            if (itemSettings is AnimalSettings animalSettings) return animalSettings.AnimalState == animalState;

            return false;
        }
}
