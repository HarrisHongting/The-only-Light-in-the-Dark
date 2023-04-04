using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void RestartGame1()
    {
        Debug.Log("clicked");
        SceneManager.LoadScene("Maze0");
    }
    
    public void RestartGame2()
    {
        SceneManager.LoadScene("Maze1");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}