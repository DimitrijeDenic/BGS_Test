using UnityEngine;

namespace BGS.Gameplay
{
    [CreateAssetMenu(fileName = "Dialogue",menuName = "Dialogues")]
    public class DialogueSO : ScriptableObject
    {
        public string dialoguePersonName;
        [TextArea] public string[] sentences;
    }
}