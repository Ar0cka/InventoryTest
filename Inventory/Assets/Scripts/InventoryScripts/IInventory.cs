using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

namespace InventoryScripts
{
    public interface IInventory
    {
        List<SlotData> SlotList { get; }
        void AddCollectedItem(GameObject item, int count);
        void RemoveItemFromInventory(int id, int count, AnimalState ? state);
    }
}