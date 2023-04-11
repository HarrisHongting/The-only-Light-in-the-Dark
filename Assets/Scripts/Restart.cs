using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    private string previousSceneName;
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        previousSceneName = PlayerPrefs.GetString("PreviousScene");
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(previousSceneName);
    }
    
    public void RestartGame1()
    {
        SceneManager.LoadScene("Background");
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }
}