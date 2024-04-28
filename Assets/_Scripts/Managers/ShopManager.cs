using System.Collections.Generic;
using BGS.Gameplay;
using BGS.SO;
using BGS.Util;
using UnityEngine;

namespace BGS.Managers
{
    public class ShopManager : MonoBehaviour
    {
        [SerializeField] private GameObject shopPanel;
        public List<ItemSo> buyableItems;
        public RectTransform shopContent;
        private UiItemPooler _pooler;
        private Dictionary<ItemSo, UiItem> _itemsInShop = new();
        private Dictionary<ItemSo, int> _itemsInShopAmount = new();

        private ItemUtil _itemUtil;

        
        
        
        private void Start()
        {
            _pooler = GameManager.Instance.inventoryManager.UIPooler;

            _itemUtil = new ItemUtil(ref _itemsInShop, ref _itemsInShopAmount, ref _pooler, shopContent, true);

            foreach (var itemSo in buyableItems)
            {
                AddItem(itemSo);
            }
        }

        private void AddItem(ItemSo so) => _itemUtil.AddItem(so);
        private void RemoveItem(ItemSo so) => _itemUtil.RemoveItem(so);

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.Escape))
                CloseShop();
        }

        public bool PurchaseItem(ItemSo data)
        {
            if (!GameManager.Instance.economyManager.CheckFunds(data.price)) return false;

            RemoveItem(data);
            GameManager.Instance.economyManager.RemoveFunds(data.price);

            return true;
        }

        public void SellItem(ItemSo data)
        {
            AddItem(data);
            GameManager.Instance.economyManager.AddFunds(data.price);
        }

        public virtual void OpenShop()
        {
            shopPanel.SetActive(true);
        }

        private void CloseShop()
        {
            shopPanel.SetActive(false);
        }

        public bool IsShopActive()
        {
            return shopPanel.activeSelf;
        }
    }
}