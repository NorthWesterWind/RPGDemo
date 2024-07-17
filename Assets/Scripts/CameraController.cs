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
        //��������������ɫ�ƶ�
        this.transform.position = Targettransform.position + offset ;
        //ͨ����껬��  ����������ӽ�����
        value = Input.GetAxis("Mouse ScrollWheel");
        Camera.main.fieldOfView += value * 5;
        Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, 40, 70);
    }
}
