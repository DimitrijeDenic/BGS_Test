using System;
using BGS.Util;
using TMPro;
using UnityEngine;

namespace BGS.Managers
{
    public class InteractionManager : MonoBehaviour
    {
        [SerializeField] private GameObject interactionUi;
        [SerializeField] private TextMeshProUGUI interactionText;
        [SerializeField] private GameObject dialogueBox;
        
        
        private TextWriter _textWriter;
        private Coroutine _writerCoroutine;
        
        private void Start()
        {
            _textWriter = new TextWriter(interactionText, .03f);
        }

        public void SetPrompt(string prompt, KeyCode interactKey)
        {
            InitiateWriter($"{prompt} \n By Pressing {interactKey}!");
        }

        public void SetNotification(string prompt)
        {
            InitiateWriter($"{prompt}!");
        }

        public void SetUi(bool visible)
        {
            interactionUi.SetActive(visible);
        }

        private void InitiateWriter(string text,Action onWritingCompleted = null)
        {
            if (_writerCoroutine != null)
                StopCoroutine(_writerCoroutine);
            _writerCoroutine = StartCoroutine(_textWriter.WriteText(text,()=>
            {
                _writerCoroutine = null;
                onWritingCompleted?.Invoke();
            }));
            SetUi(true);
        }
    }
}