using BGS.Util;
using TMPro;
using UnityEngine;

namespace BGS.Managers
{
    public class EconomyManager : MonoBehaviour
    {
        public float money;
        public TextMeshProUGUI moneyText;

        private void Start()
        {
            UpdateUi();
        }

        public bool CheckFunds(float price)
        {
            return money >= price;
        }

        public void RemoveFunds(float amount)
        {
            money -= amount;
            UpdateUi();
        }

        public void AddFunds(float amount)
        {
            money += amount;
            UpdateUi();
        }

        private void UpdateUi()
        {
            moneyText.text = money.WithSuffix("N");
        }
    }


}