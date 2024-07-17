using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : InteractObject
{
    public ItemSO itemSO;

    //���¿�ʰȡ��Ʒ�����߼�
    protected override void Interact()
    {
        InventoryManager.Instance.AddItem(itemSO);
        Destroy(this.gameObject);
    }
}
