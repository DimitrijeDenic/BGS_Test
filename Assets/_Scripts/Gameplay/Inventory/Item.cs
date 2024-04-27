using BGS.Managers;
using UnityEngine;

namespace BGS.Gameplay
{
   
    public class Item : MonoBehaviour
    {
        public ItemSo itemSo;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if(!col.CompareTag("Player")) return;
            
            GameManager.Instance.inventoryManager.AddItem(itemSo);
            Destroy(gameObject);
        }
    }   
}