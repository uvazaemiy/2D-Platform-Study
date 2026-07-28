using UnityEngine;
using UnityEngine.UI;

public class UICoinCounter : MonoBehaviour
{
    [SerializeField] private Text cointText;
    [SerializeField] private Text highScoreText;
    
    private int _totalCoins = 0;
    private int _highScore = 0;

    private void Start()
    {
        //_totalCoins = PlayerPrefs.GetInt("Coins", 0);
        _highScore = PlayerPrefs.GetInt("HighScore", 0);
        
        ApplyText();
    }

    private void OnEnable()
    {
        Coin.OnCoinCollected += AddCoin;
    }

    private void OnDisable()
    {
        Coin.OnCoinCollected -= AddCoin;
        
        PlayerPrefs.Save();
    }

    private void AddCoin(int value)
    {
        _totalCoins += value;
        if (_totalCoins >= _highScore)
        {
            _highScore = _totalCoins;
            PlayerPrefs.SetInt("HighScore",  _highScore);
        }
            
        //PlayerPrefs.SetInt("Coins", _totalCoins);
        PlayerPrefs.Save();
        
        ApplyText();
    }

    private void ApplyText()
    {
        cointText.text = "Coins: " + _totalCoins.ToString();
        highScoreText.text = "High Score: " + _highScore.ToString();
    }
}
