using System;
using System.Collections.Generic;
using UnityEngine;


namespace BGS.SO
{
    [CreateAssetMenu(fileName = "Wearable", menuName = "Wearables")]
    public class WearableSO : ScriptableObject
    {
        public List<SpriteAnimations> spriteList = new()
        {
            new SpriteAnimations("walk_up"),
            new SpriteAnimations("walk_down"),
            new SpriteAnimations("walk_left"),
            new SpriteAnimations("walk_right"),
            new SpriteAnimations("idle")
        };
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