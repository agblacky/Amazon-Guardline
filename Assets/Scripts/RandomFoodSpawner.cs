using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFoodSpawner : MonoBehaviour
{
    public GameObject food;
    private int time;
    private float spawnTime;
    private float screenX;
    private float screenY;
    private Vector2 pos;
    void Update()
    {
        
        if (spawnTime <= Time.time)
        {
            time = Mathf.CeilToInt(Random.Range(15.0f, 30.0f));
            spawnTime = Time.time + time;

            //Shuffle Position
            screenX = Random.Range(126.0f, 1340.0f);
            screenY = Random.Range(56.0f, 590.0f);

            pos = new Vector2(screenX, screenY);

            //Instantiate Object
            var clone = Instantiate(food, pos, food.transform.rotation);
            clone.transform.SetParent(GameObject.Find("Canvas").transform);
        }
    }
}
