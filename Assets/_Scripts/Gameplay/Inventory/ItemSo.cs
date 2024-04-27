﻿using UnityEngine;

namespace BGS.Gameplay
{
    public enum Type
    {
        Wearable,
        Regular
    }
    
    [CreateAssetMenu(fileName = "Item", menuName = "Items/Item")]
    public class ItemSo : ScriptableObject
    {
        public Sprite icon;
        public Type itemType;
        public int price;
    }
}