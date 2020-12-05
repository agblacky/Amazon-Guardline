using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogController : MonoBehaviour
{
    public int damageValue;
    private bool isAttacking;
    List<Collider2D> collisions = new List<Collider2D>();


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 11)
        {
            //Add enemies to attacklist on collision
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
            if (!(gameObject.GetComponent<CoolDown>().isCooldown))
            {
                //Damage all enemies in list
                foreach (Collider2D collision in collisions)
                {
                    collision.gameObject.GetComponent<HumanController>().ReceiveDamage(damageValue);
                }
                //Cooldown
                gameObject.GetComponent<CoolDown>().setCoolDown();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Remove exiting objects from attacklist
        collisions.Remove(collision);
    }

}
