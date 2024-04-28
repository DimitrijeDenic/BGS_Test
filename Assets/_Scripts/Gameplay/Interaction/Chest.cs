using BGS.Managers;
using BGS.SO;
using UnityEngine;

namespace BGS.Gameplay
{
    public class Chest : MonoBehaviour
    {
        [SerializeField] private Sprite openChest;
        [SerializeField] private ItemSo coinItem;
        private Interactable _interactable;
        private SpriteRenderer _renderer;
        private Animator _animator;


        private void Awake()
        {
            _interactable = GetComponent<Interactable>();
            _renderer = GetComponent<SpriteRenderer>();
            _animator = GetComponent<Animator>();
        }

        public void OnChestOpen()
        {
            GameManager.Instance.inventoryManager.homeChestOpened = true;
            _interactable.SetInteractionAvailable(false);
            GameManager.Instance.inventoryManager.AddItem(coinItem);
            GameManager.Instance.interactionManager.SetTimedNotification("Check inventory by pressing 'I'");
        }

        public void SetChestValue()
        {
            if (!GameManager.Instance.inventoryManager.homeChestOpened) return;
            _animator.enabled = false;
            _renderer.sprite = openChest;
            _interactable.SetInteractionAvailable(false);
        }
    }
}