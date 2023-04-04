using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceToCamera1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public float rotationSpeed = 25f; // 旋转速度

    private void Update()
    {
        // 绕Y轴旋转
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    // Update is called once per frame
    //void Update()
    //{
// 计算物体在x-z平面上与相机的方向
            //Vector3 direction =  Camera.main.transform.position - transform.position;
            //direction.y = 0f;
            //direction.Normalize();

// 将物体的x-z方向朝向相机
            //transform.forward = direction;


        //当前对象始终面向摄像机。
        //this.transform.LookAt(Camera.main.transform.position);
        //this.transform.Rotate(0,0,0);
    //}
}