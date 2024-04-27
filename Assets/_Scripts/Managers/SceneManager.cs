using EasyTransition;
using UnityEngine;

namespace BGS.Managers
{
    public class SceneManager : MonoBehaviour
    {
        [SerializeField] private TransitionSettings transitionSettings;
        
        public void SwitchScene(string sceneName)
        {
            GameManager.Instance.transitionManager.Transition(sceneName,transitionSettings,.2f);
        }
    }
}
