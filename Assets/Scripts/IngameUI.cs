using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        //Restart
    }
    public void ReturnToMainMenu()
    {
        //Close Scene Open Scene
    }
}
