using System;
using System.Net.Mime;
using BGS.Managers;
using BGS.SO;
using BGS.Util;
using GluonGui.WorkspaceWindow.Views.WorkspaceExplorer;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Type = BGS.SO.Type;

namespace BGS
{
    public class UiItem : MonoBehaviour
    {
        [SerializeField] private Image icon;
        [SerializeField] private TextMeshProUGUI priceText;
        [SerializeField] private TextMeshProUGUI amountText;
        private ItemSo _data;
        private Vector2 _visualOffset;
        private int _amount;

        private Button _button;

        public bool inShop;
        private bool _shopOpen;
        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(Use);
        
        }
        private void OnDisable()
        {
            _button.onClick.RemoveAllListeners();
        }
        
        private void Update()
        {
            ShowPrice(GameManager.Instance.shopManager.IsShopActive());
        }
        private void ShowPrice(bool visible)
        {
            priceText.gameObject.SetActive(visible);
        }

        public void SetUpVisual(ItemSo itemSo)
        {
            _data = itemSo;
            icon.sprite = itemSo.icon;
            
            priceText.text = itemSo.price.WithSuffix("N");
            
            icon.rectTransform.localScale = Vector3.one * itemSo.scaleFactor;

            if (itemSo.itemType != Type.Wearable) return;

            var w = (WearableSO)itemSo;
            icon.rectTransform.anchoredPosition = Vector2.down * w.spriteUiOffset;
        }

        protected virtual void UseItem()
        {
            switch (_data.itemType)
            {
                case Type.Wearable:
                    GameManager.Instance.wearableManager.SetClothes((WearableSO)_data);
                    break;
                case Type.Regular:
                    GameManager.Instance.interactionManager.SetTimedNotification();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void Use()
        {
            if (GameManager.Instance.shopManager.IsShopActive())
            {
                if (inShop)
                    PurchaseItem();
                else
                    SellItem();
            }
            else
                UseItem();
        }

        private void PurchaseItem()
        {
            if (GameManager.Instance.shopManager.PurchaseItem(_data))
            {
                GameManager.Instance.inventoryManager.AddItem(_data);
            }
            else
            {
                Debug.LogWarning("Purchase failed: Insufficient funds or item out of stock.");
            }
        }

        private void SellItem()
        {
            GameManager.Instance.shopManager.SellItem(_data);
            GameManager.Instance.inventoryManager.RemoveItem(_data);
        }

        public void UpdateQuantity(int i)
        {
            _amount = i;
            amountText.text = _amount.ToString();
        }
    }
}