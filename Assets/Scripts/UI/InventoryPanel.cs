using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 背包面板类
/// </summary>
public class InventoryPanel : MonoBehaviour
{
    public static InventoryPanel Instance { get; private set; }

    public GameObject UIObj;

    public  GameObject content;

    public GameObject itemprefabs;

    public DeatalUI deatalUI;

    private bool isShow = true;
    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }    
        Instance = this;
    }
    private void Start()
    {
        Hide();
    }

    public void Show()
    {
        if(isShow == false)
        {
            UIObj.SetActive(true);
            isShow = true;
        }
    }

    public void Hide()
    {
        if(isShow == true)
        {
            UIObj.SetActive(false);
            isShow = false;
        }
       
    }

    public void AddItem(ItemSO itemSO)
    {
        GameObject item = GameObject.Instantiate(itemprefabs);
        item.transform.SetParent(content.transform);
        ItemUI itemUI = item.GetComponent<ItemUI>();
        
        itemUI.InitItem(itemSO);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if(!isShow)
            {
                Show();
            }
            else
            {
                Hide();
            }
            
        }
       
    }


    /// <summary>
    /// 处理背包物品被点击逻辑
    /// </summary>
    /// <param name="itemSO"></param>
    public void onClick(ItemSO itemSO ,ItemUI itemUI)
    {
        deatalUI.InitInfo(itemSO ,itemUI);
    }

    /// <summary>
    /// 处理使用按钮被点击
    /// </summary>
    /// <param name="itemSo"></param>
    public void onItemUse(ItemSO itemSo , ItemUI itemUI)
    {
        //将被使用的物品进行销毁
        Destroy(itemUI.gameObject);
        InventoryManager.Instance.RemoveItem(itemSo);

        GameObject.FindGameObjectWithTag("Player").GetComponent<Role>().UseItem(itemSo);
    }
}
