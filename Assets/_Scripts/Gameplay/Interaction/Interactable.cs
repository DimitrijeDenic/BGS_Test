using BGS.Managers;
using UnityEngine;
using UnityEngine.Events;

namespace BGS.Gameplay
{
    public class Interactable : MonoBehaviour
    {
        [SerializeField] protected UnityEvent onInteract;
        [SerializeField] private string prompt;
        [SerializeField] private KeyCode interactKey = KeyCode.E;

        private Interactor _currentInteractor;
        private bool _canInteract = true;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if(!_canInteract) return;
            
            if (!other.TryGetComponent(out Interactor interactor)) return;

            _currentInteractor = interactor;
            StartInteracting();
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (!other.TryGetComponent(out Interactor interactor)) return;
            
            if(interactor == _currentInteractor)
                StopInteracting();
        }

        private void StartInteracting()
        {
            _currentInteractor.SetInteraction(onInteract, interactKey);
            GameManager.Instance.interactionManager.SetPrompt(prompt, interactKey);
            
        }

        public void StopInteracting()
        {
            _currentInteractor.RemoveInteraction();
            GameManager.Instance.interactionManager.SetUi(false);
            _currentInteractor = null;
        }

        public void SetInteractionAvailable(bool canInteract)
        {
            _canInteract = canInteract;
        }
    }
}