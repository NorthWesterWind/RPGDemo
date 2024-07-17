using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

/// <summary>
/// �¼�������
/// </summary>
public class EventMgr : MonoBehaviour
{
    public static event Action<Monster> OnMonsterDied;

    public static void MonsterDied(Monster monster)
    {
        OnMonsterDied?.Invoke(monster);
    }

}
