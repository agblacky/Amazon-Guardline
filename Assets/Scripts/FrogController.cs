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
    List<Collider2D> collisions = new List<Collider2D>();


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 11)
        {
            this.collisions.Add(collision);
            isAttacking = true;
        }
            
    }

    private void Update()
    {
        if (collisions.Count == 0)
        {
            isAttacking = false;
        }
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
    }

}
