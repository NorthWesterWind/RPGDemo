using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InteractObject : MonoBehaviour
{
  private NavMeshAgent agent;
    private bool isInteracted;
    // Update is called once per frame
    void Update()
    {
        if(agent != null && isInteracted == false && agent.pathPending == false)
        {
            if (agent.remainingDistance <= 2  )
            {
                Interact();
                isInteracted = true;
            }
               

        }
    }
   
    public void OnClick(NavMeshAgent agent )
    {
        //TODO :交互操作

        this.agent = agent;
        //移动到可交互物体面前
        agent.stoppingDistance = 2;
        agent.SetDestination(transform.position);
        isInteracted = false;
    }

    


    //提供给子类重写交互逻辑
    protected virtual void Interact()
    {

    }
}
