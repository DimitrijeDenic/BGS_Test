using System.Collections.Generic;
using BGS.Gameplay;
using BGS.Util;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace BGS.Managers
{
    public class DialogueManager : MonoBehaviour
    {
        private Queue<string> _sentences;
        private TextWriter _writer;
        private Coroutine _writerCoroutine;
        private string _lastSentence;

        [SerializeField] private GameObject dialogueBox;
        [SerializeField] private List<GameObject> characters;
        [SerializeField] private TextMeshProUGUI dialogueText,dialogueName;
        private UnityEvent _onDialogueEnd;
        
        private void Start()
        {
            _sentences = new Queue<string>();
            _writer = new TextWriter(dialogueText, .03f);
        }

        public void StartDialogue(DialogueSO dialogueSo,UnityEvent onDialogueEnd)
        {
            _sentences.Clear();
            _onDialogueEnd = onDialogueEnd;
            
            characters.ForEach(c => c.SetActive(c.name == dialogueSo.dialoguePersonName));

            foreach (var s in dialogueSo.sentences)
            {
                print(s);
                _sentences.Enqueue(s);
            }
            
            dialogueBox.SetActive(true);
            
            dialogueName.text = dialogueSo.dialoguePersonName;
            WriteNext();
        }

        private void Update()
        {
            if(!dialogueBox.activeSelf) return;

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                if(_writerCoroutine == null)
                    WriteNext();
                else
                {
                    StopCoroutine(_writerCoroutine);
                    _writerCoroutine = null;
                    dialogueText.text = _lastSentence;
                }
            }
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
            
            _lastSentence = _sentences.Dequeue();
            _writerCoroutine = StartCoroutine(_writer.WriteText(_lastSentence, () => _writerCoroutine = null));
        }

        private void EndDialogue()
        {
            dialogueBox.SetActive(false);
            _onDialogueEnd?.Invoke();
            _onDialogueEnd = null;
        }
    }
}