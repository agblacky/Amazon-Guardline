using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanController : MonoBehaviour
{
    public int Health;
    public int Damage;
    public float movementSpeed;
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
}
