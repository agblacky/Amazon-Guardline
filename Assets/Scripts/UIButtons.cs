using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtons : MonoBehaviour
{
    private GameObject canvas;
    private void Start()
    {
        canvas = GameObject.Find("Canvas");
    }
    public void CheckUI()
    {
        canvas.GetComponent<IngameUI>().CheckUI();
    }
    void RestartGame()
    {
        canvas.GetComponent<IngameUI>().RestartGame();
    }
    void ReturnToMainMenu()
    {
        canvas.GetComponent<IngameUI>().ReturnToMainMenu();
    }
    public void LoadScene()
    {
        SceneManager.LoadScene("Game");
        //Quit current scene
        Application.Quit();
    }
}
