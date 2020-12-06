using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IngameUI : MonoBehaviour
{
    public GameObject UIPrefab;
    public KeyCode key;
    private GameObject uiInstance;
    private void Update()
    {
        if (Input.GetKeyDown(key))
        {
            CheckUI();
        }

    }
    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
    }
    public void CheckUI()
    {
        if (uiInstance)
        {
            Destroy(uiInstance);
            ResumeGame();
        }
        else
        {
            uiInstance = Instantiate(UIPrefab, transform);
            PauseGame();
        }
    }
    public void RestartGame()
    {
        //Start New Scene
        LoadScene("Game");

    }
    public void ReturnToMainMenu()
    {
        //Start New Scene
        LoadScene("MainMenu");
    }
    void KillScene()
    {
        Application.Quit();
    }
    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
        //Quit current scene
        KillScene();
        //Resume Game
        ResumeGame();
    }
}
