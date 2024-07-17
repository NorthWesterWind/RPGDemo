using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JavelinBullet : MonoBehaviour
{
    private Rigidbody rb;
    private Collider col;

    public int atkValue = 30;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();

       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            return;
        }
        rb.velocity = Vector3.zero;
        rb.isKinematic = true;
        col.enabled = false;

        //让长矛插在物体上
        this.transform.parent = collision.gameObject.transform;

        if (collision.collider.tag == "monster")
        {
            //调用怪物脚本 中 受伤逻辑
            collision.collider.GetComponent<Monster>().Wound(atkValue);

        }

          //一秒后移除
            Destroy(this.gameObject, 1.5f);

    
    }


}
