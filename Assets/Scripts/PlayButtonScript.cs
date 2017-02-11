using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButtonScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void playGame()
    {
        SceneManager.LoadScene("Main");
    }

    void quitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

    void showInstructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    void goBack()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
