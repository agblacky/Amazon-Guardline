using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantController : MonoBehaviour
{
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

}
