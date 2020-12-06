using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastWall : MonoBehaviour
{
    private bool isTriggered;
    private GameObject canvas;
    private void Start()
    {
        isTriggered = false;
        canvas = GameObject.Find("Canvas");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("test");
        
        if (collision.gameObject.layer == 11)
        {
            isTriggered = true;
            Debug.Log("Human Damage");
            //Call Human damage function when colliding
            collision.gameObject.GetComponent<HumanController>().ReceiveDamage(1000);
        }
    }
    private void Update()
    {
        if (isTriggered)
        {
            Debug.Log("UpdateTrigger");
            transform.position = transform.position + new Vector3(20 * Time.deltaTime, 0, 0);
            if(transform.position.x == canvas.GetComponent<RectTransform>().rect.width)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
