using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private GameObject WinPanel;
    
    public void ResetGame()
    {
        if (PlayerPrefs.GetInt("MaxLifes") == 0)
        {
            int highScore = PlayerPrefs.GetInt("HighScore");
            PlayerPrefs.DeleteAll();
            PlayerPrefs.SetInt("HighScore", highScore);
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void EndLevel()
    {
        playerController.allowMoving = false;
        WinPanel.SetActive(true);
    }
}
