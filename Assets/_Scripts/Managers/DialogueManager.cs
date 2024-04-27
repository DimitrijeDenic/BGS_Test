using System.Collections.Generic;
using BGS.Gameplay;
using BGS.Util;
using TMPro;
using UnityEngine;

namespace BGS.Managers
{
    public class DialogueManager : MonoBehaviour
    {
        private Queue<string> _sentences;
        private TextWriter _writer;
        private Coroutine _writerCoroutine;

        [SerializeField] private GameObject dialogueBox;
        [SerializeField] private TextMeshProUGUI dialogueText,dialogueName;
        private void Start()
        {
            _sentences = new Queue<string>();
            _writer = new TextWriter(dialogueText, .03f);
        }

        public void StartDialogue(DialogueSO dialogueSo)
        {
            _sentences.Clear();
            foreach (var s in dialogueSo.sentences)
            {
                _sentences.Enqueue(s);
            }

            dialogueBox.SetActive(true);
            
            dialogueName.text = dialogueSo.dialoguePersonName;
            WriteNext();
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                WriteNext();
        }

        private void WriteNext()
        {
            if (_sentences.Count <= 0)
            {
                EndDialogue();
                return;
            }

            if (_writerCoroutine != null)
                StopCoroutine(_writerCoroutine);
            
            var s = _sentences.Dequeue();
            _writerCoroutine = StartCoroutine(_writer.WriteText(s, () => _writerCoroutine = null));
        }

        private void EndDialogue()
        {
            dialogueBox.SetActive(false);
        }
    }
}