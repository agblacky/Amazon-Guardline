using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardCooldown : MonoBehaviour
{
    public bool isCooldown { get; set; }
    public float coolDown;
    public Image image;
    private void Start()
    {
        image.fillAmount = 0;
    }

    private void Update()
    {
        if (isCooldown)
        {
            image.fillAmount -= 1 / coolDown * Time.deltaTime;
            
            if (image.fillAmount <= 0)
            {
                image.fillAmount = 0;
                isCooldown = false;
            }
        }
    }
    public void setCoolDown()
    {
        isCooldown = true;
        image.fillAmount = 1;
    }
}
