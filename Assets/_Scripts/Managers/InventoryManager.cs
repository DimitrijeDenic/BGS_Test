using System.Collections.Generic;
using BGS.Gameplay;
using BGS.SO;
using UnityEngine;

namespace BGS.Managers
{
    public class InventoryManager : MonoBehaviour
    {
        [SerializeField] private RectTransform content;
        [SerializeField] private UiItem itemPrefab;
        [SerializeField] private GameObject inventoryUi;

        private readonly Dictionary<ItemSo, int> _itemsInInventory = new();
        private readonly Dictionary<ItemSo, UiItem> _uiItems = new();

        private readonly UiItemPooler _uiPooler = new();

        public bool homeChestOpened;

        private void Start()
        {
            _uiPooler.InitPooler(itemPrefab, content);
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
                var i = _uiPooler.GetItem();
                _itemsInInventory.Add(item, 1);
                i.SetUpVisual(item);
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
                _uiPooler.ReleaseItem(_uiItems[item]);
                _uiItems.Remove(item);
            }
        }

        public void ReplaceItem(ItemSo toEquip, ItemSo toStore)
        {
            RemoveItem(toEquip);
            AddItem(toStore);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
                inventoryUi.SetActive(!inventoryUi.activeSelf);
            if (Input.GetKeyDown(KeyCode.Escape))
                inventoryUi.SetActive(false);
        }
    }
}