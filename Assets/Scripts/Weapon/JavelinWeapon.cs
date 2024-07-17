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

            //10����Զ��Ƴ�
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
    /// ������ì����
    /// </summary>
    private void SpawnBullet()
    {

        bullten = GameObject.Instantiate<GameObject>(bullet , this.transform.position , this.transform.rotation);
        bullten.transform.SetParent(this.transform);
        bullten.GetComponent<Collider>().enabled = false;
        //����ì�����ı�ǩ�� �ɽ�����ǩʱ
        if(this.tag == "Interactable")
        {
            //�Ƴ���ì�ӵ����ƶ��ű�
            Destroy(bullten.GetComponent<JavelinBullet>());

            //����ì�ı�ǩ����Ϊ �ɽ�����ǩ
            bullten.tag = "Interactable";

           
            //����ì������ӿ�ʰȡ��ű�
            PickableObject obj = bullten.AddComponent<PickableObject>();
            obj.itemSO = GetComponent<PickableObject>().itemSO;

            //������������Y�������  �ó�ì�����䵽����
            Rigidbody r =bullten.GetComponent<Rigidbody>();
            r.constraints = ~RigidbodyConstraints.FreezeAll;
            

            bullten.GetComponent<Collider>().enabled = true;
            bullten.transform.parent = null;
            Destroy(this.gameObject);
        }
          
    }
}
