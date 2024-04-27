using System;
using BGS.Managers;
using BGS.SO;
using UnityEngine;

namespace BGS.Gameplay
{
    public class ClothesChanger : MonoBehaviour
    {
        [SerializeField] private Wearables wearables;
        [SerializeField] private WearableSO defaultClothes, defaultHat, defaultHair;

        private WearableSO _currentWearableC, _currentWearableH;

        private void Start()
        {
            SetClothes(defaultClothes);
            SetClothes(defaultHat);
            SetClothes(defaultHair);
        }

        public void SetClothes(WearableSO wearableSo)
        {
            switch (wearableSo.wearableType)
            {
                case WearableType.Clothes:
                    Change(ref _currentWearableC, wearables.clothes, wearableSo);
                    break;
                case WearableType.Hair:
                    wearables.hair.SwapSpritesInAnimations(wearableSo);
                    break;
                case WearableType.Hat:
                    Change(ref _currentWearableH, wearables.hats, wearableSo);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void Change(ref WearableSO currentWearable, WearablesAnim anim, WearableSO wearableSo)
        {
            if (currentWearable == wearableSo) return;

            if (currentWearable != null)
            {
                GameManager.Instance.inventoryManager.ReplaceItem(wearableSo, currentWearable);
            }
            else
            {
                GameManager.Instance.inventoryManager.RemoveItem(wearableSo);
            }

            anim.SwapSpritesInAnimations(wearableSo);
            currentWearable = wearableSo;
        }
    }

    [Serializable]
    public class Wearables
    {
        public WearablesAnim clothes, hair, hats;
    }
}