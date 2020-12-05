using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolDown : MonoBehaviour
{
    public bool isCooldown { get; set; }
    public float coolDown;
    public Image image;
    private float counter;
    private void Start()
    {
        if (image)
        {
            image.fillAmount = 0;
        }
        
    }

    private void Update()
    {
        if (isCooldown)
        {
            if (image)
            {
                image.fillAmount -= 1 / coolDown * Time.deltaTime;

                if (image.fillAmount <= 0)
                {
                    image.fillAmount = 0;
                    isCooldown = false;
                }
            }
            else
            {
                counter -= 1 / coolDown * Time.deltaTime;
                if (counter <= 0)
                {
                    isCooldown = false;
                }
            }

        }
    }
    public void setCoolDown()
    {
        isCooldown = true;
        counter = 1;
        if (image)
        {
            image.fillAmount = counter;
        }
            
    }
}
