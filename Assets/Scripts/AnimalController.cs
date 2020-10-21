﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AnimalController : MonoBehaviour
{
    public GameObject bullet;
    public List<GameObject> humans;
    public GameObject toAttack;
    public float attackCooldown;
    private float attackTime;
    public int damageValue;
    private void Update()
    {
        if (humans.Count > 0)
        {
            toAttack = humans.First();
        }
        if (toAttack != null)
        {
            if (attackCooldown == 0)
            {
                toAttack.GetComponent<HumanController>().ReceiveDamage(damageValue);
                //Gameobject has to be destroyed after killing the first enemy in list
            }
            else if (attackTime <= Time.time)
            {
                GameObject bulletInstance = Instantiate(bullet, transform);
                bulletInstance.GetComponent<Bullet>().damageValue = this.damageValue;
                attackTime = Time.time + attackCooldown;
            }
        }
    }
}