using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 玩家拾取物品类
/// </summary>
public class PlayerPick : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Interactable")
        {
            PickableObject obj = collision.collider.GetComponent<PickableObject>();
            if(obj != null)
            {
                InventoryManager.Instance.AddItem(obj.itemSO);
                 
            }
            else
            {
                return;
            }
        }
    }
}
