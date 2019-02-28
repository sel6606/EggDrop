using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour {

    public GameObject howToPanel;
    public GameObject pausePanel;
    public GameObject gameOverPanel;
    public GameObject scoreTextHolder;
    public TextMeshProUGUI scoreText;
    public GameObject scoreTextHolder2;
    public TextMeshProUGUI scoreText2;
    public float score;

	// Use this for initialization
	void Start () {
        score = 0;
        scoreText = scoreTextHolder.GetComponent<TextMeshProUGUI>();
        scoreText2 = scoreTextHolder2.GetComponent<TextMeshProUGUI>();
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            togglePause();
        }

        scoreText.SetText("You fell: {0} meters!", score);
        scoreText2.SetText("Distance: {0}m", score);
    }

    public void loadGame()
    {
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }

    public void loadMenu()
    {
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
        if (!pausePanel.activeInHierarchy)
        {
            pausePanel.SetActive(true);
        }
        else
        {
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
    }
}
