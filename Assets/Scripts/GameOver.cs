using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverUI;
    private GameObject canvas;
    private void Start()
    {
        canvas = GameObject.Find("Canvas");
        float screenX = canvas.GetComponent<RectTransform>().rect.width/-2-50;
        gameObject.transform.localPosition = new Vector2(screenX,0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Instantiate UI
        Instantiate(gameOverUI, canvas.transform);
        //Pause Game
        PauseGame();
    }
    void PauseGame()
    {
        canvas.GetComponent<IngameUI>().PauseGame();
    }
}
