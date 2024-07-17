using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    public Image icon;
    public Text txtName;
    public Text txtType;

    private ItemSO m_itemSO;
    /// <summary>
    /// 初始化物品信息显示
    /// </summary>
    /// <param name="sprite"></param>
    /// <param name="name"></param>
    /// <param name="type"></param>
    public void InitItem(ItemSO itemSO)
    {
        icon.sprite = itemSO.icon;
        txtName.text = itemSO.itemname;
        string type = "";
        switch (itemSO.itemtype)
        {
            case E_Itemtype.Weapon:
                type = "武器";
                break;
            case E_Itemtype.Consumable:
                type = "消耗品";
                break;
        }
        txtType.text = type;
        m_itemSO = itemSO;
    }

    public void OnClick()
    {
        //将自身的ItemSo传递出去
        InventoryPanel.Instance.onClick(m_itemSO , this);
        InventoryPanel.Instance.deatalUI.gameObject.SetActive(true);
    }
}
