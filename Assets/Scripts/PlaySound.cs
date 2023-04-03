using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, 100f);

            foreach (Collider col in colliders)
            {
                // 检测附近的物体是否包含所需的组件
                AudioSource audioSource = col.GetComponent<AudioSource>();
                if (audioSource != null)
                {
                    audioSource.Play();
                }
            }
        }
    }

}