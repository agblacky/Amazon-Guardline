using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanController : MonoBehaviour
{
    public int health;
    public int damage;
    private float movementSpeed;
    private bool isColliding;
    private float damageCooldown=1.0f;
    private AudioSource audioSource;
    public Animator animator;
    private void Start()
    {
        //Calculate Movement speed according to screen resolution
        movementSpeed = GameObject.Find("Canvas").GetComponent<RectTransform>().rect.width / -100;
        audioSource = gameObject.GetComponent<AudioSource>();
    }
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
            //Start attacking routine
            StartCoroutine(Attack(collision));
            isColliding = true;
        }
    }
    IEnumerator Attack(Collider2D collision)
    {
        if (collision != null)
        {
            animator.SetBool("Attack", true);
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
        audioSource.Play();
    }
    public void SetAnimation()
    {
        animator.SetBool("Attack", false);
    }
}
