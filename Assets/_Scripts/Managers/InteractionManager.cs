using System.Text;
using TMPro;
using UnityEngine;

namespace BGS.Managers
{
    public class InteractionManager : MonoBehaviour
    {
        public GameObject interactionUi;
        [SerializeField] private TextMeshProUGUI interactionText;

        public bool notificationShowing;
        public float notificationDuration;

        public void SetPrompt(string prompt,KeyCode interactKey)
        {
            interactionText.text = $"{prompt} \n By Pressing {interactKey}!";
            SetUi(true);

        }

        public void SetUi(bool visible)
        {
            interactionUi.SetActive(visible);
            notificationShowing = visible;
        }
        public void SetNotification(string prompt)
        {
            interactionText.text = $"{prompt}!";
            SetUi(true);
        }
    }
}