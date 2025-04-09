using System;
using DefaultNamespace;
using Unity.VisualScripting;
using UnityEngine;

namespace ItemsLogic
{
    public class AnimalSettings : ItemSettings
    {
        [SerializeField] private AnimalState animalState;

        public AnimalState AnimalState => animalState;

        private void Awake()
        {
            if (animalState == AnimalState.Wounded)
            {
                iconItem.color = Color.red;
            }
        }

        public void HitAnimal()
        {
            animalState = AnimalState.Wounded;
            iconItem.color = Color.red;
        }

        public void HealAnimal()
        {
            animalState = AnimalState.Healthy;
            iconItem.color = Color.white;
        }
    }
}