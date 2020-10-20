using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : MonoBehaviour
{
    public GameObject bullet;
    public List<GameObject> humans;
    public GameObject toAttack;
    public float attackCooldown;
    private float attackTime;
    public int damageValue;
    public bool isAttacking;
    private void Update()
    {
        if (humans.Count > 0 && isAttacking == false)
        {
            isAttacking = true;
            //toAttack=GetComponent<SpawnPoint>().humans
        }
        else if (humans.Count == 0 && isAttacking == true)
        {
            isAttacking = false; 
        }
        if (toAttack != null)
        {
            if (attackTime <= Time.time)
            {
                GameObject bulletInstance = Instantiate(bullet, transform);
                bulletInstance.GetComponent<Bullet>().damageValue = this.damageValue;
                attackTime = Time.time + attackCooldown;
            }
        }
    }
}
