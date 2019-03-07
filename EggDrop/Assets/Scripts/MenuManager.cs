using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour {

    public GameObject howToPanel;
    public GameObject pausePanel;
    public GameObject gameOverPanel;
    public GameObject selectPanel;
    public GameObject scoreTextHolder;
    public TextMeshProUGUI scoreText;
    public GameObject scoreTextHolder2;
    public TextMeshProUGUI scoreText2;
    public int currentScene; //0 - main menu, 1 - main scene
    public float score;

	// Use this for initialization
	void Start () {
        score = 0;

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (currentScene == 1)
        {
            score = GameInfo.instance.DistanceFallen;
            scoreText2.SetText("Distance: {0}m", score);
        }
    }

    public void loadGame()
    {
        GameInfo.instance.GameOver = false;
        GameInfo.instance.ResetDistance();
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }

    public void loadMenu()
    {
        GameInfo.instance.Paused = false;
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void toggleHowTo()
    {
        if (!howToPanel.activeInHierarchy)
        {
            howToPanel.SetActive(true);
        }
        else
        {
            howToPanel.SetActive(false);
        }
    }

    public void togglePause()
    {
        GameInfo.instance.Paused = !GameInfo.instance.Paused;
        if (!pausePanel.activeInHierarchy)
        {
            pausePanel.SetActive(true);
        }
        else
        {
            if (howToPanel.activeInHierarchy)
            {
                howToPanel.SetActive(false);
            }
            pausePanel.SetActive(false);
        }
    }

    public void toggleGameOver()
    {
        if (!gameOverPanel.activeInHierarchy)
        {
            gameOverPanel.SetActive(true);
        }
        else
        {
            gameOverPanel.SetActive(false);
        }

        scoreText.SetText("You fell: {0} meters!", score);
    }

    public void toggleSelect()
    {
        if (!selectPanel.activeInHierarchy)
        {
            selectPanel.SetActive(true);
        }
        else
        {
            selectPanel.SetActive(false);
        }
    }
}
