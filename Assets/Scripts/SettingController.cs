using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SettingsController : MonoBehaviour
    {
        public GameObject GameSettings;
        void Start()
        {
            
        }

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
        
        public void SetFullscreen(bool value)
        {
            Screen.fullScreen = value; 
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

