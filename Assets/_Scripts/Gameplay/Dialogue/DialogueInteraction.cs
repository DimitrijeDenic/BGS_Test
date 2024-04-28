using BGS.Managers;
using UnityEngine;
using UnityEngine.Events;

namespace BGS.Gameplay
{
    public class DialogueInteraction : MonoBehaviour
    {
        [SerializeField] private DialogueSO dialogueSo;
        private Interactable _interactable;
        [SerializeField] private UnityEvent onDialogueEnd;
        private void Start()
        {
            _interactable = GetComponent<Interactable>();
        }

        public void StartDialogue()
        {
            GameManager.Instance.dialogueManager.StartDialogue(dialogueSo,onDialogueEnd);
            _interactable.StopInteracting();
        }
    }

   
}