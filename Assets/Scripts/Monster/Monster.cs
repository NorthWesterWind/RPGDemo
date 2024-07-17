using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

//怪物状态枚举
enum E_State
{
    Normal,
    Moving,
    Resting,
    Acting
}

//怪物类
public class Monster : MonoBehaviour
{


    private NavMeshAgent monsteragent;

    //默认处于正常状态
    private  E_State state  = E_State.Normal;
    //设置次级状态为移动
    private  E_State childstate  = E_State.Moving;
    //怪物休息时间
    private float restTime = 10;
    private float nowTime = 0;

    //怪物血量
    public int Hp = 100;

    //怪物死亡产生的经验值
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
                    //休息时间结束  进行移动
                    Vector3 v = FindRandomPosition();
                    monsteragent.SetDestination(v);
                    //次级状态切换为移动
                    childstate = E_State.Moving;
                }
            }else if(childstate == E_State.Moving)
            {
                if(monsteragent.velocity == Vector3.zero)
                {
                    //次级状态切换为移动
                    childstate = E_State.Resting;
                }
            }
        }
    }

    //寻找随机目标点
  private Vector3 FindRandomPosition()
    {
        Vector3 randomDir = new Vector3(Random.Range(-1, 1f), 0 , Random.Range(-1 , 1f));
        return this.transform.position + randomDir.normalized * Random.Range(2,7);
    }
    /// <summary>
    /// 受伤逻辑
    /// </summary>
    /// <param name="value">受伤的数值</param>
    public void Wound(int value)
    {
        Hp -= value;

        //怪物死亡
        if(Hp <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        //禁用物品身上的碰撞组件
        GetComponent<Collider>().enabled = false;
        //随机化物品生成的数量
        int count =4;
        for (int i = 0; i < count; i++)
        {
            ItemSO item = ItemDBMgr.Instance.GetRandomItemSO();
            GameObject itemobj = GameObject.Instantiate(item.prefab, this.transform.position, Quaternion.identity);
            //设置实例化出来的物品标签  设置为可交互类型
            itemobj.tag = "Interactable";
            //关闭武器动画
            Animator animator = itemobj.GetComponent<Animator>();
            if (animator != null)
                animator.enabled = false;
            //为创建出来的物品添加脚本
            PickableObject p = itemobj.AddComponent<PickableObject>();
            p.itemSO = item;

            //开启物品中的碰撞检测
            Collider collider = itemobj.gameObject.GetComponent<Collider>();
            if (collider != null)
            {
                collider.enabled = true;
                collider.isTrigger = false;
            }
            //设置刚体组件中的参数
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
