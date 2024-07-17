using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

//����״̬ö��
enum E_State
{
    Normal,
    Moving,
    Resting,
    Acting
}

//������
public class Monster : MonoBehaviour
{


    private NavMeshAgent monsteragent;

    //Ĭ�ϴ�������״̬
    private  E_State state  = E_State.Normal;
    //���ôμ�״̬Ϊ�ƶ�
    private  E_State childstate  = E_State.Moving;
    //������Ϣʱ��
    private float restTime = 10;
    private float nowTime = 0;

    //����Ѫ��
    public int Hp = 100;

    //�������������ľ���ֵ
    public int exp = 30;

    // Start is called before the first frame update
    void Start()
    {
        monsteragent = GetComponent<NavMeshAgent>();    
    }

    // Update is called once per frame
    void Update()
    {
        if(state == E_State.Normal)
        {
            if(childstate == E_State.Resting)
            {
                nowTime += Time.deltaTime;
                if(nowTime > restTime)
                {
                    //��Ϣʱ�����  �����ƶ�
                    Vector3 v = FindRandomPosition();
                    monsteragent.SetDestination(v);
                    //�μ�״̬�л�Ϊ�ƶ�
                    childstate = E_State.Moving;
                }
            }else if(childstate == E_State.Moving)
            {
                if(monsteragent.velocity == Vector3.zero)
                {
                    //�μ�״̬�л�Ϊ�ƶ�
                    childstate = E_State.Resting;
                }
            }
        }
    }

    //Ѱ�����Ŀ���
  private Vector3 FindRandomPosition()
    {
        Vector3 randomDir = new Vector3(Random.Range(-1, 1f), 0 , Random.Range(-1 , 1f));
        return this.transform.position + randomDir.normalized * Random.Range(2,7);
    }
    /// <summary>
    /// �����߼�
    /// </summary>
    /// <param name="value">���˵���ֵ</param>
    public void Wound(int value)
    {
        Hp -= value;

        //��������
        if(Hp <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        //������Ʒ���ϵ���ײ���
        GetComponent<Collider>().enabled = false;
        //�������Ʒ���ɵ�����
        int count =4;
        for (int i = 0; i < count; i++)
        {
            ItemSO item = ItemDBMgr.Instance.GetRandomItemSO();
            GameObject itemobj = GameObject.Instantiate(item.prefab, this.transform.position, Quaternion.identity);
            //����ʵ������������Ʒ��ǩ  ����Ϊ�ɽ�������
            itemobj.tag = "Interactable";
            //�ر���������
            Animator animator = itemobj.GetComponent<Animator>();
            if (animator != null)
                animator.enabled = false;
            //Ϊ������������Ʒ��ӽű�
            PickableObject p = itemobj.AddComponent<PickableObject>();
            p.itemSO = item;

            //������Ʒ�е���ײ���
            Collider collider = itemobj.gameObject.GetComponent<Collider>();
            if (collider != null)
            {
                collider.enabled = true;
                collider.isTrigger = false;
            }
            //���ø�������еĲ���
            Rigidbody rgb = itemobj.GetComponent<Rigidbody>();
            if (rgb != null)
            {
                rgb.isKinematic = false;
                rgb.useGravity = true;
            }

           
        }
        EventMgr.MonsterDied(this);   
        Destroy(this.gameObject);
    }
}
