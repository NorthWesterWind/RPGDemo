using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDBMgr : MonoBehaviour
{
    public static ItemDBMgr Instance { get; private set; }

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public ItemDB itemDB;

    /// <summary>
    /// 随机获取到一个物品
    /// </summary>
    /// <returns></returns>
    public ItemSO GetRandomItemSO()
    {
        return itemDB.list[Random.Range(0, itemDB.list.Count)];
    }
 


}
