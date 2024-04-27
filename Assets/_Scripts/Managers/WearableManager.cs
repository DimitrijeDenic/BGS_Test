using BGS.Gameplay;
using BGS.SO;
using UnityEngine;

namespace BGS.Managers
{
    public class WearableManager : MonoBehaviour
    {
        [SerializeField] private ClothesChanger _clothesChanger;

        public void SetClothes(WearableSO data)
        {
            _clothesChanger.SetClothes(data);
        }
    }
}