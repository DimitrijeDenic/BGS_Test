using BGS.Managers;
using UnityEngine;

namespace BGS.Gam
{
    public class SceneChangeInteraction : MonoBehaviour
    {
        public void ChangeScene(string sceneName)
        {
            GameManager.Instance.sceneManager.SwitchScene(sceneName);
        }
    }
}
