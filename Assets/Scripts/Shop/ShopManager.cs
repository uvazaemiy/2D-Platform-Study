using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private UICoinCounter coinCounter;
    [Space]
    [SerializeField] Health playerHealth;
    [SerializeField] private int healthPrice = 10;

    private int _currentCoins;

    

    private void Start()
    {
        healthPrice = PlayerPrefs.GetInt("HealthPrice", healthPrice);
    }

    public void BuyHealthUpgrade()
    {
        _currentCoins = PlayerPrefs.GetInt("Coins", 0);

        if (_currentCoins >= healthPrice)
        {
            _currentCoins -= healthPrice;
            
            int currentMaxHealth = playerHealth.maxHealth + 1;
            PlayerPrefs.SetInt("MaxHealth", currentMaxHealth);
            coinCounter.AddCoin(-healthPrice);

            healthPrice *= 2;
            PlayerPrefs.SetInt("HealthPrice", healthPrice);
            
            PlayerPrefs.Save();
            
            Debug.Log("Покупка успішна! Здоров'я збільшено.");
        }
        else
        {
            Debug.Log("Недостатньо монет для покупки!");
        }
    }
}
