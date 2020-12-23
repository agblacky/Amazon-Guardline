using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantController : MonoBehaviour
{
    private int health = 700;
    public GameObject food;
    public float coolDown;
    private void Update()
    {
        if (!(gameObject.GetComponent<CoolDown>().isCooldown))
        {
            //Instantiate Food
            var clone = Instantiate(food, gameObject.transform.position, food.transform.rotation);
            clone.transform.SetParent(gameObject.transform);
            //Cooldown
            gameObject.GetComponent<CoolDown>().setCoolDown(this.coolDown);
        }
    }
    public void ReceiveDamage(int damage)
    {
        if (this.health - damage <= 0)
        {
            //Destroy Gameobject if smaller or equal than zero
            gameObject.transform.parent.GetComponent<ObjectContainer>().isfull = false;
            Destroy(this.gameObject);
        }
        else
        {
            //Receive damage if not below zero
            this.health -= damage;
        }
    }

}
