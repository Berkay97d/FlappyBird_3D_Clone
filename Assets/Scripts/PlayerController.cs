using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private Rigidbody rb;
    private bool isGameStarted;

    private void Update()
    {
        Jump();
        BalanceVelocity();
    }

    private void OnGameStart()
    {
        StartGravity();
        isGameStarted = true;
    }

    private void OnGameOver()
    {
        StopGravity();
        isGameStarted = false;
    }

    private void OnGameRestart()
    {
        StartGravity();
        isGameStarted = true;
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameEvents.Over();
        }
    }

    private void BalanceVelocity()
    {
        var currentVelocity = new Vector3(rb.velocity.x, 20, rb.velocity.z);
        
        if (rb.velocity.y > 20)
        {
            rb.velocity = currentVelocity;
        }
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
        if (!isGameStarted) return;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce);
        }
    }
    
}
