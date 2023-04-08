using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SettingsController : MonoBehaviour
    {
        public GameObject GameSettings;

        void Update()
        {

        }

        public void SetVolume(float value)
        {
            AudioListener.volume = Mathf.Clamp01(value);
        }
        
        public void QuitGame()
        {
            Application.Quit();
        }

        private bool isFullScreen;
        
        private void Start()
        {
            isFullScreen = Screen.fullScreen;
        }
        public void ToggleFullScreen()
        {
            isFullScreen = !isFullScreen;
            Screen.fullScreen = isFullScreen;
        }
        
        public void BackGame(){
            Time.timeScale = 1f;
            if (GameSettings.activeSelf)
            {
                GameSettings.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
}


    // Update is called once per frame

