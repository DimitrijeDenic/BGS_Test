using BGS.Managers;
using UnityEngine;

namespace BGS.Gam
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
