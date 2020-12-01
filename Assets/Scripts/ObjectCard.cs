using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ObjectCard : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public GameObject object_Drag;
    public GameObject object_Game;
    public Canvas canvas;
    private GameObject objectDragInstance;
    public GameManager gamemanager;
    public int cost;
    private Text text;
    public int coolDown;
    private float wait;
    public bool isCooldown=false;

    private void Start()
    {
        gamemanager = GameManager.instance;
        text = GameObject.Find("FoodcounterText").GetComponent<Text>();
    }
    private void Update()
    {
        if (isCooldown)
        {
            if (wait <= Time.time)
            {
                isCooldown = false;                
            }
        }
        
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (!isCooldown)
        {
            objectDragInstance.transform.position = Input.mousePosition;
        }
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!isCooldown)
        {
            objectDragInstance = Instantiate(object_Drag, canvas.transform);
            objectDragInstance.transform.position = Input.mousePosition;
            objectDragInstance.GetComponent<ObjectDragging>().card = this;

            gamemanager.draggingObject = objectDragInstance;
        }
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!isCooldown)
        {
            if (text.GetComponent<Shop>().checkCurrency(this.cost))
            {
                if (gamemanager.PlaceObject())
                {
                    text.GetComponent<Shop>().Remove(this.cost);
                    wait = Time.time + coolDown;
                    isCooldown = true;
                }
            }

            gamemanager.draggingObject = null;
            Destroy(objectDragInstance);
            
        }
    }
}
