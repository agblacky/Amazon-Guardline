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
        
        if (collision.gameObject.layer == 11)
        {
            isTriggered = true;
            //Call Human damage function when colliding
            collision.gameObject.GetComponent<HumanController>().ReceiveDamage(1000);
        }
    }
    private void Update()
    {
        if (isTriggered)
        {
            transform.position = transform.position + new Vector3(300 * Time.deltaTime, 0, 0);
            if(transform.position.x == canvas.GetComponent<RectTransform>().rect.width)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
