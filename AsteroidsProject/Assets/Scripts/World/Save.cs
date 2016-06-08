﻿using UnityEngine;
using System.Collections;


public class Save : MonoBehaviour {

    ScoreHandler _scorehandler;
    Timer _timer;
    WaveManager _wavemanager;

    

    float Score;
    float Wave;
    float Minutes, Seconds;
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

        PlayerPrefs.SetFloat("Score", Score);
        PlayerPrefs.SetFloat("Wave", Wave);
        PlayerPrefs.SetFloat("Seconds", Seconds);
        PlayerPrefs.SetFloat("Minutes", Minutes);
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetFloat("Score"));
        Debug.Log(PlayerPrefs.GetFloat("Wave"));
        Debug.Log(PlayerPrefs.GetFloat("Seconds"));
        Debug.Log(PlayerPrefs.GetFloat("Minutes"));
        SaveCompleted = true;


    }
	
}
