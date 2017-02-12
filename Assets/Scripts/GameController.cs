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

    [SerializeField]
    Slider revolutionBar;

	// Use this for initialization
	void Start () {
        wave = 0;
        score = 0;
        revolution = 0;
        StartCoroutine(addRevolution());
        revolutionBar.maxValue = maxRevolution;
        revolutionBar.value = revolution;
	}
	
    void updateWave()
    {
        //updatewave method
        if (score >= wave * 5)
        {
            wave++;
        }
    }

	// Update is called once per frame
	void Update () {
        revolutionBar.value = revolution;
        scoreText.text = "Score: " + score;
        waveText.text = "Wave: " + score;
        if(revolution >= maxRevolution)
        {
            endGame();
        }
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
