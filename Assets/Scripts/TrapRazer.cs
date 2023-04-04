using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaserTrap : MonoBehaviour
{
    public float damageAmount = 10f;
    public float laserLength = 1.5f;
    public Color laserColor = Color.red;
    public float laserWidth = 0.05f;

    private LineRenderer lineRenderer;
    private bool isActivated = false;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
        lineRenderer.startWidth = laserWidth;
        lineRenderer.endWidth = laserWidth + 0.5f;
        lineRenderer.material.color = laserColor;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isActivated && other.CompareTag("Player"))
        {
            Debug.Log("player is in");
            isActivated = true;
            lineRenderer.enabled = true;
            InvokeRepeating("FireLaser", 0f, 0.1f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isActivated && other.CompareTag("Player"))
        {
            isActivated = false;
            lineRenderer.enabled = false;
            CancelInvoke("FireLaser");
        }
    }

    private void FireLaser()
    {
        Vector3 laserStart = transform.position;
        Vector3 laserEnd = transform.position + transform.forward * laserLength;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, laserLength))
        {
            laserEnd = hit.point;
            if (hit.collider.CompareTag("Player"))
            {
                // Player is hit by the laser
                SceneManager.LoadScene("GameOver");
            }
        }

        lineRenderer.SetPosition(0, laserStart);
        lineRenderer.SetPosition(1, laserEnd);
    }
}

