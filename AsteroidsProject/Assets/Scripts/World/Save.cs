using UnityEngine;
using System.Collections.Generic;


public class Save : MonoBehaviour {

    ScoreHandler _scorehandler;
    Timer _timer;
    WaveManager _wavemanager;
    // naam > points > wave > hours > minutes > seconds


    int[] player_points;
    int[] player_wave;
    int[] player_hours;
    int[] player_minutes;
    int[] player_seconds;

    float playerMoney;
    float Score;
    float Wave;
    float Minutes, Seconds, Hours;
    public bool SaveCompleted;

    void Start ()
    {

        
        _wavemanager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<WaveManager>();
        _timer = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<Timer>();
        _scorehandler = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<ScoreHandler>();
	}
    public void SaveFile()
    {
       
        Score = _scorehandler.Score;
        Wave = _wavemanager.waveCounter;
        Minutes = _timer.minutes;
        Seconds = _timer.seconds;
        Hours = _timer.hours;

        playerMoney += Score;
        Debug.Log(playerMoney);

        PlayerPrefs.SetFloat("Score", Score);
        PlayerPrefs.SetFloat("Wave", Wave);
        PlayerPrefs.SetFloat("Seconds", Seconds);
        PlayerPrefs.SetFloat("Minutes", Minutes);
        PlayerPrefs.SetFloat("Hours", Hours);
        PlayerPrefs.SetFloat("PlayerMoney", playerMoney);
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetFloat("Score"));
        Debug.Log(PlayerPrefs.GetFloat("Wave"));
        Debug.Log(PlayerPrefs.GetFloat("Seconds"));
        Debug.Log(PlayerPrefs.GetFloat("Minutes"));
        Debug.Log(PlayerPrefs.GetFloat("Hours"));
        Debug.Log(PlayerPrefs.GetFloat("PlayerMoney"));

        

        SaveCompleted = true;


    }
	
}
