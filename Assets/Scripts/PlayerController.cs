using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private Rigidbody rb;
    

    private void Update()
    {
        Jump();
    }

    private void OnGameStart()
    {
        StartGravity();
    }

    private void OnGameOver()
    {
        StopGravity();
    }

    private void OnGameRestart()
    {
        StartGravity();
    }

    private void OnEnable()
    {
        GameEvents.OnGameStart += OnGameStart;
        GameEvents.OnGameOver += OnGameOver;
        GameEvents.OnGameRestart += OnGameRestart;
    }

    private void OnDisable()
    {
        GameEvents.OnGameStart -= OnGameStart;
        GameEvents.OnGameOver -= OnGameOver;
        GameEvents.OnGameRestart -= OnGameRestart;
    }

    private void StartGravity()
    {
        rb.useGravity = true;
    }

    private void StopGravity()
    {
        rb.useGravity = false;
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce);
            
        }
    }
    
}
