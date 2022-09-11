using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    [SerializeField] private GameObject InGamePanel;
    [SerializeField] private GameObject BeforeGamePanel;
    [SerializeField] private GameObject GameOverPanel;


    private void OnGameStart()
    {
        DeactivateBeforeGame();
        ActivateInGame();
    }

    private void OnGameRestart()
    {
        DeactivateGameOver();
        ActivateInGame();
    }

    private void OnGameOver()
    {
        DeactivateInGame();
        ActivateGameOver();
        
    }

    private void OnEnable()
    {
        GameEvents.OnGameStart += OnGameStart;
        GameEvents.OnGameRestart += OnGameRestart;
        GameEvents.OnGameOver += OnGameOver;
    }

    private void OnDisable()
    {
        GameEvents.OnGameStart -= OnGameStart;
        GameEvents.OnGameRestart -= OnGameRestart;
        GameEvents.OnGameOver -= OnGameOver;
    }

    private void ActivateInGame()
    {
        InGamePanel.SetActive(true);
    }
    
    private void DeactivateInGame()
    {
        InGamePanel.SetActive(false);
    }
    
    
    private void ActivateBeforeGame()
    {
        BeforeGamePanel.SetActive(true);
    }
    
    private void DeactivateBeforeGame()
    {
        BeforeGamePanel.SetActive(false);   
    }
    
    
    private void ActivateGameOver()
    {
        GameOverPanel.SetActive(true);
    }
    
    private void DeactivateGameOver()
    {
        GameOverPanel.SetActive(false);
    }

    public void StartGame()
    {
        GameEvents.Start();
    }

    public void RestartGame()
    {
        GameEvents.Restart();
    }
    
    
    
}
