using System;
using InventoryScripts;
using UnityEngine;

namespace DefaultNamespace
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private Inventory inventory;
        [SerializeField] private OperationWithAnimal operationWithAnimal;

        private void Start()
        {
            inventory.Initialize();
            operationWithAnimal.Initialize(inventory);
        }
    }
}