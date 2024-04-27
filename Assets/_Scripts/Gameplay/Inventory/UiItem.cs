using System;
using BGS.Managers;
using BGS.SO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Type = BGS.SO.Type;

namespace BGS
{
    public class UiItem : MonoBehaviour
    {
        [SerializeField] private Image icon;
        [SerializeField] private TextMeshProUGUI amountText;
        private ItemSo _data;
        private Vector2 _visualOffset;
        private int _amount;

        private Button _button;

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

        public void SetUpVisual(ItemSo itemSo)
        {
            _data = itemSo;
            icon.sprite = itemSo.icon;

            icon.rectTransform.localScale = Vector3.one * itemSo.scaleFactor;
            
            if (itemSo.itemType != Type.Wearable) return;
            
            var w = (WearableSO)itemSo;
            icon.rectTransform.anchoredPosition = Vector2.down * w.spriteUiOffset;

        }
        protected virtual void Use()
        {
            switch (_data.itemType)
            {
                case Type.Wearable:
                    GameManager.Instance.wearableManager.SetClothes((WearableSO)_data);
                    break;
                case Type.Regular:
                    GameManager.Instance.inventoryManager.RemoveItem(_data);
                    print(_data.name);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void UpdateQuantity(int i)
        {
            _amount = i;
            amountText.text = _amount.ToString();
        }
    }
}
