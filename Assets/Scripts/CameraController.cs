using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 offset;
    private Transform Targettransform;
    private float value;
    // Start is called before the first frame update
    void Start()
    {
        Targettransform = GameObject.FindGameObjectWithTag("Player").transform;
        offset = this.transform.position - Targettransform.position ;
    }

    // Update is called once per frame
    void Update()
    {
        //保持摄像机跟随角色移动
        this.transform.position = Targettransform.position + offset ;
        //通过鼠标滑轮  进行摄像机视角缩放
        value = Input.GetAxis("Mouse ScrollWheel");
        Camera.main.fieldOfView += value * 5;
        Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, 40, 70);
    }
}
