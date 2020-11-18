using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Foodscript : MonoBehaviour
{
    public Text text;
    private void Start()
    {
        text = GameObject.Find("FoodcounterText").GetComponent<Text>();
        Instantiate(text, transform);
        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(Add);
    }

    public void Add()
    {
        text.text = Convert.ToString(Convert.ToInt16(text.text) + 50);
        Destroy(this.gameObject);
    }
    
}
