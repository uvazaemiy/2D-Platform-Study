using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private UICoinCounter coinCounter;
    [Header("Health")]
    [SerializeField] private int healthPrice = 10;
    [SerializeField] private Text currentHealth;
    [SerializeField] private Text healthPriceText;
    [Header("Life")]
    [SerializeField] private int lifePrice = 10;
    [SerializeField] private Text currentLife;
    [SerializeField] private Text LifePriceText;
    [Header("Speed")]
    [SerializeField] private int speedPrice = 10;
    [SerializeField] private Text currentSpeed;
    [SerializeField] private Text SpeedPriceText;
    [Header("Damage")]
    [SerializeField] private int damagePrice = 10;
    [SerializeField] private Text currentDamage;
    [SerializeField] private Text damagePriceText;

    private int _currentCoins;

    

    private void Start()
    {
        healthPrice = PlayerPrefs.GetInt("HealthPrice", healthPrice);
        lifePrice = PlayerPrefs.GetInt("LifePrice", lifePrice);
        speedPrice = PlayerPrefs.GetInt("SpeedPrice", speedPrice);
        damagePrice = PlayerPrefs.GetInt("DamagePrice", damagePrice);
        
        healthPriceText.text = healthPrice.ToString();
        LifePriceText.text = lifePrice.ToString();
        SpeedPriceText.text = speedPrice.ToString();
        damagePriceText.text = damagePrice.ToString();
        
        currentHealth.text = PlayerPrefs.GetInt("MaxHealth").ToString();
        currentLife.text = PlayerPrefs.GetInt("MaxLifes").ToString();
        currentSpeed.text = PlayerPrefs.GetInt("Speed").ToString();
        currentDamage.text = PlayerPrefs.GetInt("Damage").ToString();
        
    }

    
    
    public void BuyHealth()
    {
        int newHealth = BuyUpgrade(PlayerPrefs.GetInt("MaxHealth"), healthPrice, 5);
        if (newHealth != 0)
            PlayerPrefs.SetInt("MaxHealth", newHealth);
    }

    public void BuyLife()
    {
        int newLife = BuyUpgrade(PlayerPrefs.GetInt("MaxLifes"), lifePrice, 1);
        if (newLife != 0)
            PlayerPrefs.SetInt("MaxLifes", newLife);
    }
    
    public void BuySpeed()
    {
        int newSpeed = BuyUpgrade(PlayerPrefs.GetInt("MaxSpeed"), speedPrice, 2);
        if (newSpeed != 0)
            PlayerPrefs.SetInt("MaxSpeed", newSpeed);
    }
    
    public void BuyDamage()
    {
        int newDamage = BuyUpgrade(PlayerPrefs.GetInt("MaxDamage"),  damagePrice, 1);
        if (newDamage != 0)
            PlayerPrefs.SetInt("MaxDamage", newDamage);
    }

    
    
    private int BuyUpgrade(int valueToUpgrade, int price, int valueModifier)
    {
        _currentCoins = PlayerPrefs.GetInt("Coins", 0);

        if (_currentCoins >= price)
        {
            _currentCoins -= price;

            coinCounter.AddCoin(-price);

            valueToUpgrade += valueModifier;
            
            Debug.Log("Покупка успішна! Здоров'я збільшено.");

            return valueToUpgrade;
        }
        else
        {
            Debug.Log("Недостатньо монет для покупки!");

            return 0;
        }
    }
}
