using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonCanMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public MonsterController monsterController;

    // Update is called once per frame
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MonsterCanMove"))
        {
            Debug.Log("player moved out");
            monsterController.PlayerMoved();
        }
    }
}

    