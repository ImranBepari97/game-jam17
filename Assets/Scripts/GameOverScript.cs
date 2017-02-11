using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public Texture gameOverTexture;

    void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 36;
        style.fontStyle = FontStyle.Bold;
        style.alignment = TextAnchor.MiddleCenter;

        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), gameOverTexture);
        GUI.color = new Color(0,0,0);
        GUI.Label(new Rect(Screen.width / 2 - 35, Screen.height / 2 - 35, 150, 25), "You have failed to stop the revolution at Jesters",style);

        style.fontSize = 12;
        style.fontStyle = FontStyle.Normal;

        if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2, 150, 25), "Try Again"))
        {
            SceneManager.LoadScene("Main");
        }
        if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2 + 25, 150, 25), "Quit"))
        {
            Application.Quit();
        }
    }
}
