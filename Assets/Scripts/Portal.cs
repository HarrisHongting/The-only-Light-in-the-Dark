using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class Portal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Interacted with " + other.gameObject.name);
        
        if (other.CompareTag("Player"))
        {
            
        }
    }

    public void OnInteract()
    {
        
    }
}
