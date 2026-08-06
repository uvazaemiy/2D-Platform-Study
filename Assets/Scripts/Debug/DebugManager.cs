using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DebugManager : MonoBehaviour
{
    [SerializeField] private Slider timeScaleSlider;
    
    

    private void Update()
    {
        Time.timeScale = timeScaleSlider.value;
    }
    
    public void ResetGameProgress()
    {
        PlayerPrefs.DeleteAll();
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
        Debug.Log("All saves are deleted");
    }
    
    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
