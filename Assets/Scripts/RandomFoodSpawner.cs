using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFoodSpawner : MonoBehaviour
{
    public GameObject food;
    private float screenX;
    private float screenY;
    GameObject canvas;
    public float coolDown;
    private void Start()
    {
        canvas = GameObject.Find("Canvas");
    }
    void Update()
    {
        if (!(gameObject.GetComponent<CoolDown>().isCooldown))
        {
            //Shuffle Position
            screenX = Mathf.CeilToInt(Random.Range(canvas.GetComponent<RectTransform>().rect.width / -3, canvas.GetComponent<RectTransform>().rect.width / 3));
            screenY = Mathf.CeilToInt(Random.Range(-1* canvas.GetComponent<RectTransform>().rect.height / 4, (canvas.GetComponent<RectTransform>().rect.height * 2) / 4));

            //Instantiate Object
            var clone = Instantiate(food, new Vector2(0,0), food.transform.rotation);
            clone.transform.SetParent(canvas.transform);
            clone.transform.localPosition = new Vector2(screenX, screenY);
            gameObject.GetComponent<CoolDown>().setCoolDown(this.coolDown);
        }
    }
}
