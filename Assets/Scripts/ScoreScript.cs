using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

    public Text textField;
    private int score;

	// Use this for initialization
	void Start () {
        score = 0;
	}
	
	// Update is called once per frame
	void Update () {
        score = score + 1;
        UpdateScore();
	}

    void addScore(int n)
    {
        score = score + n;
        UpdateScore();
    }

    void UpdateScore()
    {
        textField.text = "Score: " + score;
    }
}
