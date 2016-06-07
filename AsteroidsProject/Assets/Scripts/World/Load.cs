using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Load : MonoBehaviour {

    [SerializeField]
    Text ScoreText;
    [SerializeField]
    Text WaveText;
    [SerializeField]
    Text TimeText;


    public float score;
    public float wave;
    public float minutes, seconds;
	// Use this for initialization
	void Start ()
    {
        score = PlayerPrefs.GetFloat("Score");
        wave = PlayerPrefs.GetFloat("Wave");
        minutes = PlayerPrefs.GetFloat("Minutes");
        seconds = PlayerPrefs.GetFloat("Seconds");
        Debug.Log(minutes);
        Debug.Log(seconds);

	}

    void Update()
    {
        ScoreText.text = "Score: " + score.ToString();
        WaveText.text = "Wave: " + wave.ToString();
        TimeText.text = "You Survived For: " + minutes.ToString() + "m : " + seconds.ToString() + "s";
    }
	

}
