using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsController : MonoBehaviour
    {
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
}


    // Update is called once per frame

