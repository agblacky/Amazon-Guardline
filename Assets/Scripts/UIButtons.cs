using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtons : MonoBehaviour
{
    private GameObject canvas;
    public GameObject uiPrefab;
    private void Start()
    {
        canvas = GameObject.Find("Canvas");
    }
    public void CheckUI()
    {
        canvas.GetComponent<IngameUI>().CheckUI();
    }
    public void RestartGame()
    {
        canvas.GetComponent<IngameUI>().RestartGame();
    }
    public void ReturnToMainMenu()
    {
        canvas.GetComponent<IngameUI>().ReturnToMainMenu();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void LoadScene()
    {
        SceneManager.LoadScene("Game");
    }
    public void Options()
    {
        Instantiate(this.uiPrefab, transform);
    }
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void Tutorial()
    {
        PlayerPrefs.SetInt("TutorialDone", 0);
        SceneManager.LoadScene("Tutorial");
    }
}
