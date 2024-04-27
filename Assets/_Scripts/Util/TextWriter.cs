using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace BGS._Scripts.Util
{
    public class TextWriter
    {
        private readonly TextMeshProUGUI _textComponent;
        private readonly float _delayBetweenCharacters;

        public TextWriter(TextMeshProUGUI textComponent, float delayBetweenCharacters)
        {
            _textComponent = textComponent;
            _delayBetweenCharacters = delayBetweenCharacters;
        }

        public IEnumerator WriteText(string targetText,Action onComplete)
        {
            if (_textComponent == null)
            {
                Debug.LogError("Text component is not assigned!");
                yield break;
            }

            _textComponent.text = "";

            foreach (var t in targetText)
            {
                _textComponent.text += t;
                yield return new WaitForSeconds(_delayBetweenCharacters);
            }
            onComplete?.Invoke();
        }
    }
}