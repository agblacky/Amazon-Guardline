using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    private GameObject canvas;
    private void Start()
    {
        canvas = GameObject.Find("Canvas");
    }
    public void RestartGame()
    {
        canvas.GetComponent<IngameUI>().RestartGame();
    }
    public void ReturnToMainMenu()
    {
        canvas.GetComponent<IngameUI>().ReturnToMainMenu();
    }
}
