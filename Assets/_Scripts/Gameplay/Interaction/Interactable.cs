using BGS._Scripts.Gameplay.Player;
using BGS.Managers;
using UnityEngine;
using UnityEngine.Events;

namespace BGS
{
    public class Interactable : MonoBehaviour
    {
        [SerializeField] protected UnityEvent onInteract;
        [SerializeField] private string prompt;
        [SerializeField] private KeyCode interactKey = KeyCode.E;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if(!other.TryGetComponent(out Interactor interactor)) return;    

            interactor.SetInteraction(onInteract,interactKey);
            
            GameManager.Instance.interactionManager.SetPrompt(prompt,interactKey);

        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if(!other.TryGetComponent(out Interactor interactor)) return;

            interactor.RemoveInteraction();
            GameManager.Instance.interactionManager.SetUi(false);
        }

       
    }
}
