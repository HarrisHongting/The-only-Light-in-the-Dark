using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public GameObject text;
    private bool isNearby = false;

    private void Update()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        string nextSceneName = currentSceneName == "Maze0" ? "Maze1" : "Victory";
        
        if (isNearby && Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.Log("当前场景是："+ currentSceneName + ", 下个场景是："+ nextSceneName);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Interacted with " + other.gameObject.name);
        
        if (other.CompareTag("Player"))
        {
            isNearby = true;
            text.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isNearby = false;
            text.SetActive(false);
        }
    }
}
