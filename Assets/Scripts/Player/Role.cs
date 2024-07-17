using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using static UnityEditor.Progress;

public class Role : MonoBehaviour
{
    private NavMeshAgent agent;

    public Weapon Weapon;

    private PlayerProperty playerProperty;

    public Sprite weaponIcon;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        playerProperty = GetComponent<PlayerProperty>();
    }

    // Update is called once per frame
    void Update()
    {
        //检测鼠标右键按下
        if (Input.GetMouseButtonDown(1) && EventSystem.current.IsPointerOverGameObject() == false   )
        {
            //从鼠标位置发出一条射线
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            bool collde = Physics.Raycast(ray, out hit);
            if (collde)
            { 
                if(hit.collider.tag == "Ground")
                {
                    agent.SetDestination(hit.point);
                }
                else if(hit.collider.tag == "Interactable")
                {
                    //进行交互
                     hit.collider.GetComponent<InteractObject>().OnClick(agent);
                }
                
            }
        }

        if (Weapon != null && Input.GetMouseButtonDown(0) && EventSystem.current.IsPointerOverGameObject() == false)
            Weapon.Atk();


    }
    /// <summary>
    /// 加载武器
    /// </summary>
    /// <param name="w"></param>
    //public void LoadWeapon(Weapon w)
    //{
    //    this.Weapon = w;
    //    this.weaponIcon = w.icon;
    //}

    /// <summary>
    /// 重载  通过ItemSO 进行加载武器
    /// </summary>
    /// <param name="itemSO"></param>
    public void LoadWeapon(ItemSO itemSO)
    {
        if(Weapon != null)
        {
            Destroy(Weapon.gameObject);
            UnLoadWeapon();
        }

        string prefabName = itemSO.itemname;
       Transform parent = transform.Find(prefabName + "Position");
       GameObject w = Instantiate(itemSO.prefab , parent);
        w.transform.localPosition = Vector3.zero;
        w.transform.rotation = parent.transform.rotation;

        this.Weapon = w.GetComponent<Weapon>();
        this.weaponIcon = itemSO.icon;

        PropertyPanel.Instance.UpdateProperty();
    }

    public void UnLoadWeapon()
    {
        this.Weapon = null;
    }

    public void UseItem(ItemSO itemSo)
    {
        switch (itemSo.itemtype)
        {
            case E_Itemtype.Weapon:
                //武器  进行装备
                LoadWeapon(itemSo);
                break;
            case E_Itemtype.Consumable:
                //可消耗品 进行属性改变
                playerProperty.UseItem(itemSo);
                break;
                default:
                break;
        }
    }

}
