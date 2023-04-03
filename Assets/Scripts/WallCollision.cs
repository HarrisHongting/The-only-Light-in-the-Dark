using UnityEngine;

public class WallCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("robotic"))
        {
            gameObject.SetActive(false);
        }
    }
}