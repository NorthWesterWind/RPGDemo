using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskNPCObject : InteractObject
{
    public GameTask gameTask;

    public string NPCname;

    //不同状态时 NPC的对话内容
    public List<string> InTaskExecuting;
    public List<string> InTaskCompleted;
    public List<string> InTaskEnd;

    private void Start()
    {
        gameTask.state = E_GameTaskState.Waiting;
    }
    protected override void Interact()
    {
        switch (gameTask.state)
        {

            case E_GameTaskState.Waiting:

                DialogPanel.Instance.InfoList = gameTask.dialogs;
                DialogPanel.Instance.ShowPanel(NPCname, OnDialogOver);
                break;
            case E_GameTaskState.Executing:
                DialogPanel.Instance.InfoList = InTaskExecuting;
                DialogPanel.Instance.ShowPanel(NPCname);
                break;
            case E_GameTaskState.Completed:
                DialogPanel.Instance.InfoList = InTaskCompleted;
                DialogPanel.Instance.ShowPanel(NPCname, OnDialogOver);
                break;
            case E_GameTaskState.End:
                DialogPanel.Instance.InfoList = InTaskEnd;
                DialogPanel.Instance.ShowPanel(NPCname);
                break;
            default:
                break;
        }


    }

    public void OnDialogOver()
    {
        switch(gameTask.state)
        {
            case E_GameTaskState.Waiting:
                gameTask.OnStart();
                InventoryManager.Instance.AddItem(gameTask.startitemSO);
                TipPanel.Instance.Show("你接到了一个新的任务");
                break;
            case E_GameTaskState.Completed:
                gameTask.End();
                InventoryManager.Instance.AddItem(gameTask.enditemSO);
                TipPanel.Instance.Show("任务完成!");
                break;
            default :
                break;
        }
    }
}
