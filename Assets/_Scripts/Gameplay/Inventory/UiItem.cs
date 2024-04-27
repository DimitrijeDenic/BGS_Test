using System;
using BGS.Gameplay;
using BGS.Managers;
using BGS.SO;
using UnityEngine;
using UnityEngine.UI;
using Type = BGS.Gameplay.Type;

namespace BGS
{
    public class UiItem : MonoBehaviour
    {
        [SerializeField] private Image icon;
        private ItemSo _data;
        private Vector2 visualOffset;

        private void OnEnable()
        {
            GetComponent<Button>().onClick.AddListener(Use);
        }

        public void SetUpVisual(ItemSo itemSo)
        {
            _data = itemSo;
            icon.sprite = itemSo.icon;

            if (itemSo.itemType != Type.Wearable) return;
            
            var w = (WearableSO)itemSo;
            icon.rectTransform.anchoredPosition += Vector2.down * w.spriteUiOffset;

        }
        protected virtual void Use()
        {
            switch (_data.itemType)
            {
                case Type.Wearable:
                    GameManager.Instance.wearableManager.SetClothes((WearableSO)_data);
                    break;
                case Type.Regular:
                    print(_data.name);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
