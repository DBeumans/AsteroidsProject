using UnityEngine;
using System.Collections;

public class HighScore : MonoBehaviour {


    float Score_Highscore1;
    float Score_Highscore2;
    float Score_Highscore3;
    float Score_Highscore4;
    float Score_Highscore5;

    float Wave_Highscore1;
    float Wave_Highscore2;
    float Wave_Highscore3;
    float Wave_Highscore4;
    float Wave_Highscore5;

    float Score;
    float Wave;


	void Start ()
    {
        //Get player prefs data
        Score = PlayerPrefs.GetFloat("Score");
        Wave = PlayerPrefs.GetFloat("Wave");
        GetScore();
	}
	
	
	void Update () {
	
	}

    void GetScore()
    {
        //check is score is groter dan highscore1,2,3,4 of 5
        if(Score > Score_Highscore1)
        {
            Score_Highscore1 = Score;
        }
        else if(Score > Score_Highscore2)
        {
            Score_Highscore2 = Score;
        }
        else if (Score > Score_Highscore3)
        {
            Score_Highscore3 = Score;
        }
        else if (Score > Score_Highscore4)
        {
            Score_Highscore4 = Score;
        }
        else if (Score > Score_Highscore5)
        {
            Score_Highscore5 = Score;
        }
        else
        {
            Debug.Log("Geenplaats");
        }
    }
}
