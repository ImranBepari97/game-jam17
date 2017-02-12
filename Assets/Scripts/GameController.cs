using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    [SerializeField]
    public int score;
    public int wave;

    [SerializeField]
    public int revolution;
    public int maxRevolution;

    [SerializeField]
    public float revolutionGain;
    [SerializeField]
    Text scoreText;
    Text waveText;


	// Use this for initialization
	void Start () {
        wave = 0;
        score = 0;
        revolution = 0;
        StartCoroutine(addRevolution());
	}
	
    void updateWave()
    {
        //updatewave method
    }

	// Update is called once per frame
	void Update () {
        
        scoreText.text = "Score: " + score;
        waveText.text = "Wave: " + wave;
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
