using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Foodscript : MonoBehaviour
{
    private Text text;
    private void Start()
    {
        //Get text from all GameObjects
        text = GameObject.Find("FoodcounterText").GetComponent<Text>();
        //Add button event listener
        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(Add);
    }

    public void Add()
    {
        text.text = Convert.ToString(Convert.ToInt16(text.text) + 50);
        Destroy(this.gameObject);
    }
    
}
