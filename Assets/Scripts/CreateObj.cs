using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomHeight : MonoBehaviour
{

    private void OnBecameVisible()
    {
        Vector3 pos = transform.position;
        pos.z = Random.Range(4.27f, -1.3f);
        //pos.z指的是在z轴给的数值内生成位置
        //Range后的数值是生成的z轴数值的范围
        transform.position = pos;
    }

}

