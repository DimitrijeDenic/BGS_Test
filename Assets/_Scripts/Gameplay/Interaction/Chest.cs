using BGS.Managers;
using UnityEngine;

namespace BGS.Gameplay
{
    public class Chest : MonoBehaviour
    {
        private Interactable _interactable;

        private void Awake()
        {
            _interactable = GetComponent<Interactable>();
        }

        public void OnChestOpen()
        {
            GameManager.Instance.inventoryManager.homeChestOpened = true;
            _interactable.SetInteractionAvailable(false);
        }

        public void SetChestValue()
        {
            if (!GameManager.Instance.inventoryManager.homeChestOpened) return;

            _interactable.SetInteractionAvailable(false);
        }
    }
}