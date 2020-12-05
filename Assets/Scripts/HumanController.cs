using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanController : MonoBehaviour
{
    public int health;
    public int damage;
    private float movementSpeed=-10;
    private bool isColliding;
    private float damageCooldown=1.0f;
    private void Update()
    {
        if (!isColliding)
        {
            transform.position = transform.position + new Vector3(movementSpeed * Time.deltaTime, 0, 0);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            StartCoroutine(Attack(collision));
            isColliding = true;
        }
        else if (collision.gameObject.layer == 13)
        {
            //LastWall
        }
    }
    IEnumerator Attack(Collider2D collision)
    {
        if (collision != null)
        {
            if (!collision.gameObject.GetComponent<PlantController>())
            {
                collision.gameObject.GetComponent<AnimalController>().ReceiveDamage(damage);
            }
            else
            {
                collision.gameObject.GetComponent<PlantController>().ReceiveDamage(damage);
            }
            yield return new WaitForSeconds(damageCooldown);
            StartCoroutine(Attack(collision));
        }
        else
        {
            isColliding = false;
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
            this.health -= damage;
        }
    }
}
