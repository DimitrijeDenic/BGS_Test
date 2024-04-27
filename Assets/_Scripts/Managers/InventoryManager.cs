using BGS.Gameplay;
using UnityEngine;

namespace BGS.Managers
{
    public class InventoryManager : MonoBehaviour
    {
        [SerializeField] private RectTransform content;
        [SerializeField] private UiItem itemPrefab;
        [SerializeField] private GameObject inventoryUi;
        public void AddItem(ItemSo item)
        {
            var i = Instantiate(itemPrefab, content);
            i.SetUpVisual(item);
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.I))
                inventoryUi.SetActive(!inventoryUi.activeSelf);
            if (Input.GetKeyDown(KeyCode.Escape))
                inventoryUi.SetActive(false);
        }
    }
}