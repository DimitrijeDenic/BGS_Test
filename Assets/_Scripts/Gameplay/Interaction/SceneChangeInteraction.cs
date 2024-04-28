using System;
using BGS.Managers;
using UnityEngine;

namespace BGS.Gameplay
{
    public class SceneChangeInteraction : MonoBehaviour
    {
        [SerializeField] private bool shop,isOutside;

        private void OnEnable()
        {
                GameManager.OnSceneChanged += PlaySound;
        }

        private void OnDisable()
        {
            GameManager.OnSceneChanged -= PlaySound;
        }

        public void ChangeScene(string sceneName)
        {
            GameManager.Instance.sceneManager.SwitchScene(sceneName);
            GameManager.Instance.exitingShop = shop;
            GameManager.Instance.isOutside = isOutside;
            
            GameManager.OnSceneChanged?.Invoke();
        }

        private void PlaySound()
        {
            GameManager.Instance.audioManager.PlayDoorSound();
        }
    }
}
