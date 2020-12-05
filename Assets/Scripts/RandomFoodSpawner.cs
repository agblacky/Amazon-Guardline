using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFoodSpawner : MonoBehaviour
{
    public GameObject food;
    private float screenX;
    private float screenY;
    void Update()
    {
        if (!(gameObject.GetComponent<CoolDown>().isCooldown))
        {
            //Shuffle Position
            screenX = Mathf.CeilToInt(Random.Range(Screen.width/-3, Screen.width / 3));
            screenY = Mathf.CeilToInt(Random.Range(-1*Screen.height / 4, (Screen.height * 2) / 4));

            //Instantiate Object
            var clone = Instantiate(food, new Vector2(0,0), food.transform.rotation);
            clone.transform.SetParent(GameObject.Find("Canvas").transform);
            clone.transform.localPosition = new Vector2(screenX, screenY);
            gameObject.GetComponent<CoolDown>().setCoolDown();
        }
    }
}
