using System.Collections.Generic;
using System.Diagnostics;
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
    public bool isClassic;
    public bool isWall;
    public bool isDestroy;
    private void Update()
    {
        if (humans.Count > 0)
        {
            toAttack = humans.First();
        }
        if (toAttack != null)
        {
            if (isClassic)
            {
                if (attackTime <= Time.time)
                {
                    //Create Bullet
                    GameObject bulletInstance = Instantiate(bullet, transform);
                    //Inherit damage
                    bulletInstance.GetComponent<Bullet>().damageValue = this.damageValue;
                    //Cooldown
                    attackTime = Time.time + attackCooldown;
                }
            }
            else if (isDestroy)
            {
                if (transform.position.x >= toAttack.transform.position.x - 400)
                {
                    toAttack.GetComponent<HumanController>().ReceiveDamage(damageValue);
                    //After attacking, gameobject is beeing destroyed
                    Destroy(this.gameObject);
                    //Empty parent container
                    gameObject.transform.parent.GetComponent<ObjectContainer>().isfull = false;
                }
            }
            else if (isWall)
            {
                //Wall Code
            }


        }
        
    }
}
