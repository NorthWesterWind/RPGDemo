using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 背包物品管理单例类
/// </summary>
public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        } 
        Instance = this;
    }

    public List<ItemSO> items = new List<ItemSO>();
 
    //增加物品
    public void AddItem(ItemSO sO)
    {
        items.Add(sO);
        InventoryPanel.Instance.AddItem(sO);
        TipPanel.Instance.Show("你获得了一个新物品: " + sO.itemname);
    }


    //减少物品
    public void RemoveItem(ItemSO sO)
    {
        items.Remove(sO);
    }
}
