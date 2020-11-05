using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanController : MonoBehaviour
{
    public int health;
    public int damage;
    private float movementSpeed=0.065f;
    private bool isColliding;
    private void Update()
    {
        if (!isColliding)
        {
            transform.Translate(new Vector3(movementSpeed * -1, 0, 0));
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            isColliding = true;
        }
    }
    public void ReceiveDamage(int damage)
    {
        if (this.health - damage <= 0)
        {
            transform.parent.GetComponent<SpawnPoint>().humans.Remove(this.gameObject);
            Destroy(this.gameObject);
        }
        else{
            this.health = this.health - damage;
        }
    }
}
