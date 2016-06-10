using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {

    /*
    ******************************************

    Plaatsen worden bepaald door het aantal waves die je behaald, hoger de wave, hoger de plaats in de leaderboard.

    ******************************************
    */

    [SerializeField]
    Text PointsText;
    [SerializeField]
    Text WaveText1;
    [SerializeField]
    Text WaveText2;

    float Score_Highscore1;

    float Wave_Highscore1;

    float Score;
    float Wave;


	void Start ()
    {
        //Get player prefs data
        Score = PlayerPrefs.GetFloat("Score");
        Wave = PlayerPrefs.GetFloat("Wave");
        GetScore();

	}
	
	
	void Update ()
    {
        WaveText1.text = Wave_Highscore1.ToString();
        PointsText.text = Score_Highscore1.ToString();
	}

    void GetScore()
    {

    }
}
