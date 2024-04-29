using System.Collections.Generic;
using BGS.Gameplay;
using BGS.SO;
using BGS.Util;
using UnityEngine;

namespace BGS.Managers
{
    public class InventoryManager : MonoBehaviour
    {
        [SerializeField] private RectTransform content;
        [SerializeField] private UiItem itemPrefab;
        public GameObject inventoryUi;

        private Dictionary<ItemSo, int> _itemsInInventory = new();
        private Dictionary<ItemSo, UiItem> _uiItems = new();

        public UiItemPooler UIPooler = new();

        public bool homeChestOpened;

        private ItemUtil _itemUtil;

        private void Awake()
        {
            UIPooler.InitPooler(itemPrefab, content);
        }

        private void Start()
        {
            _itemUtil = new ItemUtil(ref _uiItems, ref _itemsInInventory, ref UIPooler, content, false);
        }

        public void AddItem(ItemSo so) => _itemUtil.AddItem(so);
        public void RemoveItem(ItemSo so) => _itemUtil.RemoveItem(so);
        public void ReplaceItem(ItemSo toEquip, ItemSo toStore) => _itemUtil.ReplaceItem(toEquip, toStore);


        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
                inventoryUi.SetActive(!inventoryUi.activeSelf);
            
            if (Input.GetKeyDown(KeyCode.Escape))
                inventoryUi.SetActive(false);

            GameManager.Instance.uiActive = inventoryUi.activeSelf;
        }
    }
}