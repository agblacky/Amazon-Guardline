using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IngameUI : MonoBehaviour
{
    public GameObject UIPrefab;
    public GameObject UIWin;
    public KeyCode key;
    private GameObject uiInstance;
    private GameObject spawnercontainer;
    public GameObject spawner1;
    public GameObject spawner2;
    public GameObject spawner3;
    public GameObject spawner4;
    public GameObject spawner5;
    private bool gameWon;
    private AudioSource audioSource;
    private void Start()
    {
        spawnercontainer = GameObject.Find("Spawner");
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(key))
        {
            CheckUI();
        }
        if (spawnercontainer.GetComponent<HumanSpawner>().counter == spawnercontainer.GetComponent<HumanSpawner>().humans.Count && spawner1.GetComponent<SpawnPoint>().humans.Count==0&& spawner2.GetComponent<SpawnPoint>().humans.Count == 0 && spawner3.GetComponent<SpawnPoint>().humans.Count == 0 && spawner4.GetComponent<SpawnPoint>().humans.Count == 0 && spawner5.GetComponent<SpawnPoint>().humans.Count == 0)
        {
            if (!(gameWon))
            {
                PauseGame();
                Instantiate(UIWin, transform);
                gameWon = true;
            }
        }

    }
    public void PauseGame()
    {
        audioSource.Play();
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
    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
        //Resume Game
        ResumeGame();
    }
}
