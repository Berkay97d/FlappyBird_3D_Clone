using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class GameEvents
{
    public static UnityAction OnGameStart;
    public static UnityAction OnGameOver;
    public static UnityAction OnGameRestart;
    public static UnityAction OnOvercomeObstacle;

    private const string HighScoreKey = "HighScoreKey";
    private const int DefaultHighScoreValue = 0;

    public static int Highscore
    {
        get => PlayerPrefs.GetInt(HighScoreKey, DefaultHighScoreValue);
        set
        {
            var newScore = value;

            if (newScore > Highscore)
            {
                PlayerPrefs.SetInt(HighScoreKey, newScore);
            }
        }
    }
    
    
    public static void Start()
    {
        OnGameStart?.Invoke();
    }
    
    public static void Over()
    {
        OnGameOver?.Invoke();
    }
    
    public static void Restart()
    {
        OnGameRestart?.Invoke();
    }
    
    public static void OvercomeObstacle()
    {
        OnOvercomeObstacle?.Invoke();
    }
    
}
