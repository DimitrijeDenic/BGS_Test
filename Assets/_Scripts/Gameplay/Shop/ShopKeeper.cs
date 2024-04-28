using BGS.Managers;
using UnityEngine;

namespace BGS
{
    public class ShopKeeper : MonoBehaviour
    {
        public void OpenShopAndInventory()
        {
            GameManager.Instance.inventoryManager.inventoryUi.SetActive(true);
            GameManager.Instance.shopManager.OpenShop();
        }
    }
}
