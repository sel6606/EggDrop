using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    public GameObject howToPanel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void loadGame()
    {
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
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
}
