using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class JavelinWeapon : Weapon
{
    public float movespeed;
    public GameObject bullet;

    private GameObject bullten;
  
   

    // Start is called before the first frame update
    void Start()
    {
        SpawnBullet();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public override void Atk()
    {
        

        if(bullten != null)
        {
            bullten.transform.parent = null;
            bullten.GetComponent<Collider>().enabled = true;
            bullten.GetComponent<Rigidbody>().velocity = this.transform.forward * movespeed;

            //10秒后自动移除
            Destroy(bullten.gameObject, 10);

            bullten = null;
            Invoke("SpawnBullet" , 0.5f);
        }
        else
        {
            return;
        }
        
    }

    /// <summary>
    /// 创建长矛对象
    /// </summary>
    private void SpawnBullet()
    {

        bullten = GameObject.Instantiate<GameObject>(bullet , this.transform.position , this.transform.rotation);
        bullten.transform.SetParent(this.transform);
        bullten.GetComponent<Collider>().enabled = false;
        //当长矛容器的标签是 可交互标签时
        if(this.tag == "Interactable")
        {
            //移除长矛子弹的移动脚本
            Destroy(bullten.GetComponent<JavelinBullet>());

            //将长矛的标签设置为 可交互标签
            bullten.tag = "Interactable";

           
            //给长矛物体添加可拾取类脚本
            PickableObject obj = bullten.AddComponent<PickableObject>();
            obj.itemSO = GetComponent<PickableObject>().itemSO;

            //解除刚体组件中Y轴的锁定  让长矛可以落到地面
            Rigidbody r =bullten.GetComponent<Rigidbody>();
            r.constraints = ~RigidbodyConstraints.FreezeAll;
            

            bullten.GetComponent<Collider>().enabled = true;
            bullten.transform.parent = null;
            Destroy(this.gameObject);
        }
          
    }
}
