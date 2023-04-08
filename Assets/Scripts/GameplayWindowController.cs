using UnityEngine;
using UnityEngine.UI;

public class GameplayWindowController : MonoBehaviour
{
    public Button closeButton;
    public GameObject gameplayWindow;

    private void Start()
    {           
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        closeButton.onClick.AddListener(CloseWindow);
    }

    private void CloseWindow()
    {
        Debug.Log("Button clicked");
        gameplayWindow.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}