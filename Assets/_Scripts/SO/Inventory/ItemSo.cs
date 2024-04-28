using UnityEngine;

namespace BGS.SO
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
        public float price;
        public float scaleFactor = 1;
    }
}