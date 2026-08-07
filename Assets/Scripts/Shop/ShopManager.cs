using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private UICoinCounter coinCounter;
    [SerializeField] private int priceModifier;
    [Header("Health")]
    [SerializeField] private int healthPrice = 10;
    [SerializeField] private int healthModifier = 5;
    [SerializeField] private Text currentHealth;
    [SerializeField] private Text healthPriceText;
    [Header("Life")]
    [SerializeField] private int lifePrice = 10;
    [SerializeField] private int lifeModifier = 1;
    [SerializeField] private Text currentLife;
    [SerializeField] private Text LifePriceText;
    [SerializeField] private GameObject[] allHearts;
    [Header("Speed")]
    [SerializeField] private int speedPrice = 10;
    [SerializeField] private float speedModifier = 1;
    [SerializeField] private Text currentSpeed;
    [SerializeField] private Text SpeedPriceText;
    [Header("Damage")]
    [SerializeField] private int damagePrice = 10;
    [SerializeField] private int damageModifier = 5;
    [SerializeField] private Text currentDamage;
    [SerializeField] private Text damagePriceText;

    private int _currentCoins;

    

    private void Start()
    {
        healthPrice = PlayerPrefs.GetInt("HealthPrice", healthPrice);
        lifePrice = PlayerPrefs.GetInt("LifePrice", lifePrice);
        speedPrice = PlayerPrefs.GetInt("SpeedPrice", speedPrice);
        damagePrice = PlayerPrefs.GetInt("DamagePrice", damagePrice);
        
        healthPriceText.text = healthPrice.ToString() + "c";
        LifePriceText.text = lifePrice.ToString() + "c";
        SpeedPriceText.text = speedPrice.ToString() + "c";
        damagePriceText.text = damagePrice.ToString() + "c";
        
        currentHealth.text = PlayerPrefs.GetInt("MaxHealth").ToString();
        currentLife.text = PlayerPrefs.GetInt("MaxLifes").ToString();
        currentSpeed.text = PlayerPrefs.GetFloat("MaxSpeed").ToString();
        currentDamage.text = PlayerPrefs.GetInt("MaxDamage").ToString();
    }

    
    
    public void BuyHealth()
    {
        int newHealth = BuyUpgrade(PlayerPrefs.GetInt("MaxHealth"), healthPrice, healthModifier);
        if (newHealth == 0)
            return;
        
        PlayerPrefs.SetInt("MaxHealth", newHealth);
        
        currentHealth.text = newHealth.ToString();
        healthPrice += priceModifier;
        healthPriceText.text = healthPrice.ToString() + "c";
        PlayerPrefs.SetInt("HealthPrice", lifePrice);
    }

    public void BuyLife()
    {
        if (PlayerPrefs.GetInt("MaxLifes") >= 5)
            return;
        
        int newLife = BuyUpgrade(PlayerPrefs.GetInt("MaxLifes"), lifePrice, lifeModifier);
        if (newLife == 0)
            return;
        
        PlayerPrefs.SetInt("MaxLifes", newLife);
        
        allHearts[newLife - 1].SetActive(true);
        lifePrice += priceModifier;
        LifePriceText.text = lifePrice.ToString() + "c";
        PlayerPrefs.SetInt("LifePrice", lifePrice);
    }
    
    public void BuySpeed()
    {
        float newSpeed = BuyUpgrade(PlayerPrefs.GetFloat("MaxSpeed"), speedPrice, speedModifier);
        if (newSpeed == 0)
            return;
        
        PlayerPrefs.SetFloat("MaxSpeed", newSpeed);

        currentSpeed.text = newSpeed.ToString();
        speedPrice += priceModifier;
        SpeedPriceText.text = speedPrice.ToString() + "c";
        PlayerPrefs.SetInt("SpeedPrice", lifePrice);
    }
    
    public void BuyDamage()
    {
        int newDamage = BuyUpgrade(PlayerPrefs.GetInt("MaxDamage"),  damagePrice, damageModifier);
        if (newDamage == 0)
            return;
        
        PlayerPrefs.SetInt("MaxDamage", newDamage);
        
        currentDamage.text = newDamage.ToString();
        damagePrice += priceModifier;
        damagePriceText.text = damagePrice.ToString() + "c";
        PlayerPrefs.SetInt("DamagePrice", lifePrice);
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
    
    private float BuyUpgrade(float valueToUpgrade, int price, float valueModifier)
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
