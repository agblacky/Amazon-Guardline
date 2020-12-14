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
    public float coolDown;

    private void Start()
    {
        gamemanager = GameManager.instance;
        //Get Shop
        text = GameObject.Find("FoodcounterText").GetComponent<Text>();
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (!(gameObject.GetComponent<CoolDown>().isCooldown))
        {
            if (text.GetComponent<Shop>().checkCurrency(this.cost))
            {
                //Object follows curser on drag
                objectDragInstance.transform.position = Input.mousePosition;
            }
                
        }
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!((gameObject.GetComponent<CoolDown>().isCooldown)))
        {
            if (text.GetComponent<Shop>().checkCurrency(this.cost))
            {
                //Create instance of gameobject on click
                objectDragInstance = Instantiate(object_Drag, canvas.transform);
                objectDragInstance.transform.position = Input.mousePosition;
                objectDragInstance.GetComponent<ObjectDragging>().card = this;

                gamemanager.draggingObject = objectDragInstance;
            }
                
        }
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //If cooldown
        if (!((gameObject.GetComponent<CoolDown>().isCooldown)))
        {
            if (text.GetComponent<Shop>().checkCurrency(this.cost))
            {
                if (gamemanager.PlaceObject())
                {
                    //Substract cardcost from shop
                    text.GetComponent<Shop>().Remove(this.cost);
                    //Set Cardcooldown
                    gameObject.GetComponent<CoolDown>().setCoolDown(this.coolDown);
                }
                gamemanager.draggingObject = null;
                Destroy(objectDragInstance);
            }
            

            
            
        }
    }
}
