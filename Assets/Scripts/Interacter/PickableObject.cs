using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : InteractObject
{
    public ItemSO itemSO;

    //重下可拾取物品交互逻辑
    protected override void Interact()
    {
        InventoryManager.Instance.AddItem(itemSO);
        Destroy(this.gameObject);
    }
}
