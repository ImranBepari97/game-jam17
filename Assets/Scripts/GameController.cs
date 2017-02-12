using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    [SerializeField]
    public int score;
    [SerializeField]
    public int wave;

    [SerializeField]
    public int revolution;
    public int maxRevolution;

    [SerializeField]
    public float revolutionGain;
    [SerializeField]
    public float waveGain;
    [SerializeField]
    Text scoreText;
    [SerializeField]
    Text waveText;

    [SerializeField]
    Slider revolutionBar;

	// Use this for initialization
	void Start () {
        wave = 0;
        score = 0;
        revolution = 0;
        StartCoroutine(addRevolution());
        StartCoroutine(updateWave());
        revolutionBar.maxValue = maxRevolution;
        revolutionBar.value = revolution;
	}
	
  

	// Update is called once per frame
	void Update () {
        revolutionBar.value = revolution;
        scoreText.text = "Score: " + score;
        waveText.text = "Wave: " + wave;
        if(revolution >= maxRevolution)
        {
            endGame();
        }
	}

    void addWave()
    {
        if(score >= wave * 5)
        {
            wave++;
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

    IEnumerator updateWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(waveGain);
            addWave();
        }
    }
}
