using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ����״̬
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

    //����ʼʱ�ṩ����Ʒ
    public ItemSO startitemSO;
    //��������ṩ�Ľ���
    public ItemSO enditemSO;

    public int monsterCount = 10;
    public int currentCount = 0;

    //����ʼʱ
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
            TipPanel.Instance.Show("Ŀ�����Ѵ��");
        }
            
    }
    //�������  �Ƴ������ĺ���
    public void End()
    {
        state = E_GameTaskState.End;
        EventMgr.OnMonsterDied -= onMonsterDied;
    }
}
