using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public Text text;
    private void Start()
    {
        text = this.gameObject.GetComponentInChildren<Text>();
    }
    public void Add()
    {
        text.text = Convert.ToString(Convert.ToInt16(text.text) + 25);
    }
    public void Remove(int cost)
    {
        text.text = Convert.ToString(Convert.ToInt16(text.text) - cost);
    }
    public bool checkCurrency(int cost)
    {
        if(Convert.ToInt16(text.text) - cost < 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
