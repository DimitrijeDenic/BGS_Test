using System;
using BGS.Gameplay;
using BGS.SO;
using UnityEngine;

namespace BGS
{
    public class ClothesChanger : MonoBehaviour
    {
        [SerializeField] private Wearables wearables;
        [SerializeField] private WearableSO defaultClothes,defaultHat,defaultHair;

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
                    wearables.clothes.SwapSpritesInAnimations(wearableSo);
                    break;
                case WearableType.Hair:
                    wearables.hair.SwapSpritesInAnimations(wearableSo);
                    break;
                case WearableType.Hat:
                    wearables.hats.SwapSpritesInAnimations(wearableSo);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
    }

    [Serializable]
    public class Wearables
    {
        public WearablesAnim clothes, hair, hats;
    }
}
