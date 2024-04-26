using System.Collections.Generic;
using BGS.Gameplay;
using BGS.SO;
using BGS.Util;
using UnityEngine;

namespace BGS.Managers
{
    public class WearableManager : GenericSingletonClass<WearableManager>
    {
        public List<WearableSO> clothes;
        public List<WearableSO> hats;
        public List<WearableSO> hairs;

        [SerializeField] private WearablesAnim clothesAnim, hatAnim, hairAnim;

        public void SetClothes(int index) => clothesAnim.animationSheat = clothes[index];
        public void SetHats(int index) => hatAnim.animationSheat = hats[index];
        public void SetHair(int index) => hairAnim.animationSheat = hairs[index];
    }
}