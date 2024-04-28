using System;
using BGS.Util;
using EasyTransition;
using UnityEngine;

namespace BGS.Managers
{
    public class GameManager : GenericSingletonClass<GameManager>
    {
        public WearableManager wearableManager;
        public InventoryManager inventoryManager;
        public InteractionManager interactionManager;
        public SceneManager sceneManager;
        public TransitionManager transitionManager;
        public DialogueManager dialogueManager;
        public ShopManager shopManager;
        public EconomyManager economyManager;
        public AudioManager audioManager;

        public bool exitingShop;
        public bool isOutside;
        public bool uiActive;
        public bool firstLoad = true;

        public static Action OnSceneChanged;

        public void Quit()
        {
            Application.Quit();
        }
    }
}