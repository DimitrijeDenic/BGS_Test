using BGS._Scripts.Gameplay.Player;
using BGS.Managers;
using UnityEngine;
using UnityEngine.Events;

namespace BGS
{
    public class Interactable : MonoBehaviour
    {
        [SerializeField] private UnityEvent onInteract;
        [SerializeField] private string prompt;
        [SerializeField] private KeyCode interactKey = KeyCode.E;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if(!other.TryGetComponent(out Interactor interactor)) return;    

            interactor.SetInteraction(onInteract,interactKey);
            SetUi(true);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if(!other.TryGetComponent(out Interactor interactor)) return;

            interactor.RemoveInteraction();
            SetUi(false);
        }

        private void SetUi(bool visible)
        {
            GameManager.Instance.interactionManager.interactionUi.SetActive(visible);
            GameManager.Instance.interactionManager.SetPrompt(prompt,interactKey);
        }
    }
}
