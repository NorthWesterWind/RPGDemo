using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������Ʒ��������
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
 
    //������Ʒ
    public void AddItem(ItemSO sO)
    {
        items.Add(sO);
        InventoryPanel.Instance.AddItem(sO);
        TipPanel.Instance.Show("������һ������Ʒ: " + sO.itemname);
    }


    //������Ʒ
    public void RemoveItem(ItemSO sO)
    {
        items.Remove(sO);
    }
}
