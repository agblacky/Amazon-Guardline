using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogController : MonoBehaviour
{
    public float attackCooldown;
    private float attackTime;
    public int damageValue;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 11)
        {
            if (attackTime <= Time.time)
            {
                collision.gameObject.GetComponent<HumanController>().ReceiveDamage(damageValue);
                //Cooldown
                attackTime = Time.time + attackCooldown;
            }
        }
    }


}
