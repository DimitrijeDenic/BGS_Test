using BGS.Managers;
using UnityEngine;

namespace BGS.Gameplay
{
    public class SceneChangeInteraction : MonoBehaviour
    {
        [SerializeField] private bool shop,isOutside;
        public void ChangeScene(string sceneName)
        {
            GameManager.Instance.sceneManager.SwitchScene(sceneName);
            GameManager.Instance.exitingShop = shop;
            GameManager.Instance.isOutside = isOutside;
        }
    }
}
