using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

/// <summary>
/// 事件管理类
/// </summary>
public class EventMgr : MonoBehaviour
{
    public static event Action<Monster> OnMonsterDied;

    public static void MonsterDied(Monster monster)
    {
        OnMonsterDied?.Invoke(monster);
    }

}
