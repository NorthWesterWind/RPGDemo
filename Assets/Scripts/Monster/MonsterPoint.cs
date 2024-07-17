using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPoint : MonoBehaviour
{

    public GameObject MonsterObj;

    private float offTime = 5;
    private float time;

    private int num = 10;
    private int currentnum;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currentnum <num)
        {
            time += Time.deltaTime;
            if (time > offTime)
                MakeMonster();
        }
      
    }

    public void MakeMonster()
    {
        currentnum++;
        GameObject.Instantiate(MonsterObj, this.transform.position + Vector3.right * 3, Quaternion.identity);
        time = 0;
    }
}
