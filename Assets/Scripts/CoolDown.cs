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
        try
        {
            image.fillAmount = 0;
        }
        catch (System.Exception)
        {

        }

        
    }

    private void Update()
    {
        if (isCooldown)
        {
            try
            {
                image.fillAmount -= 1 / coolDown * Time.deltaTime;

                if (image.fillAmount <= 0)
                {
                    image.fillAmount = 0;
                    isCooldown = false;
                }
            }
            catch (System.Exception)
            {

            }
            counter -= 1 / coolDown * Time.deltaTime;
            if (counter <= 0)
            {
                isCooldown = false;
            }

        }
    }
    public void setCoolDown()
    {
        isCooldown = true;
        counter = 1;
        try
        {
            image.fillAmount = counter;
        }
        catch (System.Exception)
        {

        }

            
    }
}
