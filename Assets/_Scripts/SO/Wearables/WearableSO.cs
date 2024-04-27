using System;
using System.Collections.Generic;
using BGS.Gameplay;
using UnityEngine;


namespace BGS.SO
{
    public enum WearableType
    {
        Clothes,
        Hair,
        Hat
    }
    
    [CreateAssetMenu(fileName = "Wearable", menuName = "Items/Wearable")]
    public class WearableSO : ItemSo
    {
        [Space,Header("Wearable info")]
        public List<SpriteAnimations> spriteAnimationsList = new()
        {
            new SpriteAnimations("walk_up"),
            new SpriteAnimations("walk_down"),
            new SpriteAnimations("walk_left"),
            new SpriteAnimations("walk_right"),
            new SpriteAnimations("idle")
        };

        public WearableType wearableType;
        public float spriteUiOffset;
    }

    [Serializable]
    public class SpriteAnimations
    {
        public string name;
        public List<Sprite> animations;

        public SpriteAnimations(string name)
        {
            this.name = name;
        }
    }
}