﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectContainer : MonoBehaviour
{
    public bool isfull;
    public GameManager gamemanager;
    public Image backgroundimage;
    public SpawnPoint spawnPoint;
    private void Start()
    {
        gamemanager = GameManager.instance;
    }
    //Visualize current container which you hover on with a character in hand
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (gamemanager.draggingObject != null && isfull == false)
        {
            gamemanager.currentContainer = this.gameObject;
            backgroundimage.enabled = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        gamemanager.currentContainer = null;
        backgroundimage.enabled = false;
    }
}
