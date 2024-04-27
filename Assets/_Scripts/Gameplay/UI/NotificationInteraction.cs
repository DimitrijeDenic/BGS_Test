using BGS.Managers;
using UnityEngine;

namespace BGS.Gameplay
{
    public class NotificationInteraction : MonoBehaviour
    {
        [TextArea] public string notificationText;

        public void SendNotification()
        {
            GameManager.Instance.interactionManager.SetNotification(notificationText);
        }
    }
}