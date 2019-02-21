﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script to keep track of various game information
/// </summary>
public class GameInfo : MonoBehaviour
{

    //Represents the game info that is stored across all scenes
    public static GameInfo instance;

    private bool gameStart = false;
    private bool gameOver = false;
    private bool paused = false;

    public bool GameStart
    {
        get { return gameStart; }
        set { gameStart = value; }
    }

    public bool GameOver
    {
        get { return gameOver; }
        set { gameOver = value; }
    }

    public bool Paused
    {
        get { return paused; }
        set { paused = value; }
    }

    void Awake()
    {
        //If there is not already a GameInfo object, set it to this
        if (instance == null)
        {
            //Make sure we keep running when clicking off the screen
            Application.runInBackground = true;

            instance = this;
        }
        else if (instance != this)
        {
            //Ensures that there are no duplicate objects being made every time the scene is loaded
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start()
    {
        gameStart = instance.gameStart;
        gameOver = instance.gameOver;
        paused = instance.paused;
    }

    // Update is called once per frame
    void Update()
    {
        //Temporary automatic restart
        //We will not be using this for the final build
        if (gameOver)
        {
            Invoke("RestartScene", 2.0f);
            gameOver = false;
        }
    }

    /// <summary>
    /// Temporary method to reload the scene.
    /// We probably won't use this for the final build.
    /// </summary>
    private void RestartScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
