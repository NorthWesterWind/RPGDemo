using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

//����������
public class ScytheWeapon : Weapon
{
    private  Animator animator;

    public  int atkValue = 50;

    private void Start()
    {
      animator = GetComponent<Animator>();
    }

    private void Update()
    {
        
    }
    public override void Atk()
    {
        animator.SetTrigger("Atk");
    }

    private void OnTriggerEnter(Collider other)
    {
        //��⹥��������
        if(other.tag == "monster")
        {
            //��������
            other.GetComponent<Monster>().Wound(atkValue);  
        }
    }
}
