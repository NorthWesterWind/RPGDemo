using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 任务状态
/// </summary>
public enum E_GameTaskState
{
    Waiting,
    Executing,
    Completed,
    End
}
[CreateAssetMenu]
public class GameTask : ScriptableObject
{
    public E_GameTaskState state;
    public List<string> dialogs;

    //任务开始时提供的物品
    public ItemSO startitemSO;
    //任务结束提供的奖励
    public ItemSO enditemSO;

    public int monsterCount = 10;
    public int currentCount = 0;

    //任务开始时
    public void OnStart()
    {
        currentCount = 0;
        state = E_GameTaskState.Executing;
        EventMgr.OnMonsterDied += onMonsterDied;
    }


    private void onMonsterDied( Monster monster)
    {
        if(state == E_GameTaskState.Completed)
            return;

        currentCount++;
        if(currentCount >= monsterCount)
        {
            state = E_GameTaskState.Completed;
            TipPanel.Instance.Show("目标数已达成");
        }
            
    }
    //任务结束  移除监听的函数
    public void End()
    {
        state = E_GameTaskState.End;
        EventMgr.OnMonsterDied -= onMonsterDied;
    }
}
