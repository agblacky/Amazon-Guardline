using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;

public class AnimalController : MonoBehaviour
{
    public int health;
    public GameObject bullet;
    public List<GameObject> humans;
    public GameObject toAttack;
    public int damageValue;
    public bool isClassic;
    public bool isDestroy;
    public float coolDown;
    public Animator animator;
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
                if (!(gameObject.GetComponent<CoolDown>().isCooldown))
                {
                    animator.SetBool("Attack", true);
                    //Create Bullet
                    GameObject bulletInstance = Instantiate(bullet, transform);
                    //Inherit damage
                    bulletInstance.GetComponent<Bullet>().damageValue = this.damageValue;
                    //Cooldown
                    gameObject.GetComponent<CoolDown>().setCoolDown(this.coolDown);
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


        }
        
    }
    public void ReceiveDamage(int damage)
    {
        if (this.health - damage <= 0)
        {
            //Destroy Gameobject if smaller or equal than zero
            Destroy(this.gameObject);
        }
        else
        {
            //Receive damage if not below zero
            this.health -= damage;
        }
    }
    public void SetAnimation()
    {
        animator.SetBool("Attack", false);
    }
}
