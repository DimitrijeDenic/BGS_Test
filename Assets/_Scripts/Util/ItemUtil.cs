using System.Collections.Generic;
using BGS.Gameplay;
using BGS.SO;
using UnityEngine;

namespace BGS.Util
{
    public class ItemUtil
    {
        private readonly Dictionary<ItemSo, UiItem> _uiItems;
        private readonly Dictionary<ItemSo, int> _itemsInInventory;
        private readonly UiItemPooler _pooler;
        private readonly RectTransform _content;
        private readonly bool _shop;
        public ItemUtil(ref Dictionary<ItemSo, UiItem> dict,ref Dictionary<ItemSo, int> amount,ref UiItemPooler pooler,RectTransform content,bool shop)
        {
            _itemsInInventory = amount;
            _uiItems = dict;
            _content = content;
            _pooler = pooler;
            _shop = shop;
        }

        public void AddItem(ItemSo item)
        {
            if (item.icon == null) return;

            if (_itemsInInventory.ContainsKey(item))
            {
                _itemsInInventory[item]++;
                _uiItems[item].UpdateQuantity(_itemsInInventory[item]);
            }
            else
            {
                var i = _pooler.GetItem(item,_content,_shop);
                _itemsInInventory.Add(item, 1);
                _uiItems.Add(item, i);
            }
        }

        public void RemoveItem(ItemSo item)
        {
            if (!_itemsInInventory.ContainsKey(item)) return;

            if (_itemsInInventory[item] > 1)
            {
                _itemsInInventory[item]--;
                _uiItems[item].UpdateQuantity(_itemsInInventory[item]);
            }
            else
            {
                _itemsInInventory.Remove(item);
                _pooler.ReleaseItem(_uiItems[item]);
                _uiItems.Remove(item);
            }
        }
        
        public void ReplaceItem(ItemSo toEquip, ItemSo toStore)
        {
            RemoveItem(toEquip);
            AddItem(toStore);
        }

    }
}