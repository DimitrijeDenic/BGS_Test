using BGS.Managers;
using UnityEngine;

namespace BGS.Gameplay
{
    public class DialogueInteraction : MonoBehaviour
    {
        [SerializeField] private DialogueSO dialogueSo;
        private Interactable _interactable;

        private void Start()
        {
            _interactable = GetComponent<Interactable>();
        }

        public void StartDialogue()
        {
            GameManager.Instance.dialogueManager.StartDialogue(dialogueSo);
            _interactable.StopInteracting();
        }
    }

   
}