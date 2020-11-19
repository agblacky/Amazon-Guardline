using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantController : MonoBehaviour
{
    private int health = 700;
    public GameObject food;
    public float attackCooldown;
    private float attackTime;
    private void Update()
    {
        if (attackTime <= Time.time)
        {
            Instantiate(food,transform);
            //Cooldown
            attackTime = Time.time + attackCooldown;
        }
    }
    public void ReceiveDamage(int damage)
    {
        if (this.health - damage <= 0)
        {
            Destroy(this.gameObject);
        }
        else
        {
            this.health -= damage;
        }
    }

}
