using System.Collections;
using System.Collections.Generic;
using BGS.Managers;
using BGS.Util;
using UnityEngine;

namespace BGS.Managers
{
    public class GameManager : GenericSingletonClass<GameManager>
    {
        public WearableManager wearableManager;
        public InventoryManager inventoryManager;
        public InteractionManager interactionManager;
        
    }
}
