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
        if (isNearby && Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene("Maze1");
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
