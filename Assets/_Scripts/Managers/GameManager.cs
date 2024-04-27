using BGS.Util;
using EasyTransition;

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
        
        public bool exitingShop;
        public bool isOutside;
    }
}
