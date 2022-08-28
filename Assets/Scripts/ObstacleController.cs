using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacles;
    [SerializeField] private float speed;
    
    private List<Vector3> obstaclePositions;

    
    
    private void Start()
    {
        obstaclePositions = DetectPositions();
    }


    private void Update()
    {
        MoveObstacles();
    }

    private List<Vector3> DetectPositions()
    {
        List<Vector3> positions = new List<Vector3>();

        var obstacle1 = obstacles[0].transform.position;
        var obstacle2 = obstacles[1].transform.position;
        var obstacle3 = obstacles[2].transform.position;
        
        positions.Add(obstacle1);
        positions.Add(obstacle2);
        positions.Add(obstacle3);

        return positions;
    }

    private void MoveObstacles()
    {
        foreach (var obstacle in obstacles)
        {
            obstacle.transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
    }

    
}
