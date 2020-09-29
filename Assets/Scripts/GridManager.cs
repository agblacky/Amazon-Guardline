using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public Sprite sprite;
    public float[,] Grid;
    int vertical, horizontal, columns, rows;
    // Start is called before the first frame update
    void Start()
    {
        vertical = (int)Camera.main.orthographicSize;
        horizontal = vertical * (Screen.width / Screen.height);
        columns = horizontal * 2;
        rows = vertical * 2;
        Grid = new float[columns, rows];
        for(int i = 0; i < columns; i++)
        {
            for(int j = 0; j < rows; j++)
            {
                Grid[i, j] = UnityEngine.Random.Range(0.0f, 1.0f);
                SpawnTile(i, j, Grid[i, j]);
            }
        }
    }
    private void SpawnTile(int x, int y, float value)
    {
        GameObject g = new GameObject("X: " + x + "Y: " + y);
        g.transform.position = new Vector3(x - (horizontal - 0.5f), y - (vertical - 0.5f));
        var s = g.AddComponent<SpriteRenderer>();
        s.sprite = sprite;
        s.color = new Color(value, value, value);
    }

}
