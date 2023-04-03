using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    public AudioClip hitWallSound;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("wall"))
        {
            // 碰撞到墙体，播放声音
            audioSource.PlayOneShot(hitWallSound);
            other.gameObject.SetActive(false);
        }
    }
}

