using UnityEngine;
using UnityEngine.Events;

namespace BGS._Scripts.Gameplay.Player
{
    public class Interactor : MonoBehaviour
    {
        private UnityEvent _interaction;
        private KeyCode _interactKey;
        private void Update()
        {
            if(_interaction == null) return;
            if(Input.GetKeyDown(_interactKey))
                _interaction?.Invoke();
        }

        public void RemoveInteraction()
        {
            _interaction = null;
        }

        public void SetInteraction(UnityEvent interactEvent,KeyCode key)
        {
            _interaction = interactEvent;
            _interactKey = key;
        }
    }
}