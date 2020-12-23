using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public GameObject canvas;
    public List<Image> images;
    private int counter=0;
    private void Start()
    {
        if (PlayerPrefs.HasKey("TutorialDone"))
        {
            if (PlayerPrefs.GetInt("ResolutionPreference") == 1)
            {
                SceneManager.LoadScene("MainMenu");
            }
            
        }
        canvas = this.gameObject;
        canvas.GetComponent<Image>().color = new Color(256, 256, 256);
        GameObject.Find("Button").transform.SetParent(canvas.transform);
        Next();

    }
    public void Next()
    {
        if (counter == images.Count)
        {
            PlayerPrefs.SetInt("TutorialDone", 1);
            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            canvas.GetComponent<Image>().sprite = images[counter].GetComponent<Image>().sprite;
            counter++;
        }
    }
}