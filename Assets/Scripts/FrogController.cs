using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogController : MonoBehaviour
{
    public float attackCooldown;
    private float attackTime;
    public int damageValue;
    private bool isAttacking;
    private List<Collider2D> collisions;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 11)
        {
            this.collisions.Add(collision);
            isAttacking = true; //fa´lss das nicht geht, in eine Liste setzen, welche angegriffen werden
        }
            
    }

    private void Update()
    {
        if (isAttacking)
        {

            if (attackTime <= Time.time)
            {
                foreach(Collider2D collision in collisions)
                {
                    collision.gameObject.GetComponent<HumanController>().ReceiveDamage(damageValue);
                    
                }
                //Cooldown
                attackTime = Time.time + attackCooldown;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collisions.Remove(collision);
        isAttacking = false;
    }

}
