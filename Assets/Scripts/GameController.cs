using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    [SerializeField]
    public int score;

    [SerializeField]
    public int revolution;
    public int maxRevolution;

    [SerializeField]
    public float revolutionGain;
    [SerializeField]
    Text scoreText;


	// Use this for initialization
	void Start () {
        score = 0;
        revolution = 0;
        StartCoroutine(addRevolution());
	}
	
	// Update is called once per frame
	void Update () {
        
        scoreText.text = "Score: " + score;
	}

    void endGame()
    {
        SceneManager.LoadScene("GameOver");
    }

    IEnumerator addRevolution()
    {
        while (true)
        {
            yield return new WaitForSeconds(revolutionGain);
            revolution++;
        }
    }
}
