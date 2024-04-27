using System.Text;
using TMPro;
using UnityEngine;

namespace BGS.Managers
{
    public class InteractionManager : MonoBehaviour
    {
        public GameObject interactionUi;
        [SerializeField] private TextMeshProUGUI interactionText;

        public void SetPrompt(string prompt,KeyCode interactKey)
        {
            interactionText.text = $"{prompt} \n By Pressing {interactKey}!";
        }
    }
}