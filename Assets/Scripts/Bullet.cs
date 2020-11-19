using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float movementSpeed;
    public int damageValue;
    private void Update()
    {
        //Give Bullet Movement Speed 
        transform.Translate(new Vector3(movementSpeed, 0, 0));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 11)
        {
            //Call Human damage function when colliding
            collision.gameObject.GetComponent<HumanController>().ReceiveDamage(damageValue);
            Destroy(this.gameObject);
        }
    }
}
