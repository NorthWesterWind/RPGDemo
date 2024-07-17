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
        //TODO :��������

        this.agent = agent;
        //�ƶ����ɽ���������ǰ
        agent.stoppingDistance = 2;
        agent.SetDestination(transform.position);
        isInteracted = false;
    }

    


    //�ṩ��������д�����߼�
    protected virtual void Interact()
    {

    }
}
