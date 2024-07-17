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
    /// ��ʼ����Ʒ��Ϣ��ʾ
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
                type = "����";
                break;
            case E_Itemtype.Consumable:
                type = "����Ʒ";
                break;
        }
        txtType.text = type;
        m_itemSO = itemSO;
    }

    public void OnClick()
    {
        //�������ItemSo���ݳ�ȥ
        InventoryPanel.Instance.onClick(m_itemSO , this);
        InventoryPanel.Instance.deatalUI.gameObject.SetActive(true);
    }
}
