using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    #region Singleton

    private static BallManager _instance;

    public static BallManager Instance => _instance;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    #endregion

    [SerializeField]
    private Ball ballPrefab;

    private Ball initialBall;

    private Rigidbody2D initialBallRb;

    public float initialBallSpeed = 350;

    private float upY = 0.32f; // how much is the ball raised above the platform if the gra has not started

    public List<Ball> Balls { get; set; }

    private void Start()
    {
        InitBall();
    }

    private void Update()
    {
        if (!GameManager.Instance.IsGameStarted)
        {
            // Align ball position to the platform position
            Vector3 platformPosition = Platform.Instance.gameObject.transform.position;
            Vector3 ballPosition = new Vector3(platformPosition.x, platformPosition.y + upY, 0);
            initialBall.transform.position = ballPosition;

            if (Input.GetMouseButtonDown(0) & GameManager.Instance.startScreen.activeSelf == false|| Input.GetButtonDown("Jump"))
            {
                initialBallRb.isKinematic = false;
                initialBallRb.AddForce(new Vector2(0, initialBallSpeed));
                GameManager.Instance.IsGameStarted = true;
            }
        }
    }

    private void InitBall()
    {
        Vector3 platformPosition = Platform.Instance.gameObject.transform.position;
        Vector3 startingPosition = new Vector3(platformPosition.x, platformPosition.y + upY, 0);
        initialBall = Instantiate(ballPrefab, startingPosition, Quaternion.identity);
        initialBallRb = initialBall.GetComponent<Rigidbody2D>();

        this.Balls = new List<Ball>
        {
            initialBall
        };
    }

    public void ResetBalls()
    {
        foreach (var ball in this.Balls.ToList())
        {
            Destroy(ball.gameObject);
        }

        InitBall();
    }

    public void SpawnBalls(Vector3 position, int count)
    {
        for (int i = 0; i < count; i++)
        {
            Ball spawnedBall = Instantiate(ballPrefab, position, Quaternion.identity) as Ball;

            Rigidbody2D spawnedBallRb = spawnedBall.GetComponent<Rigidbody2D>();
            spawnedBallRb.isKinematic = false;
            spawnedBallRb.AddForce(new Vector2(i, initialBallSpeed));
            this.Balls.Add(spawnedBall);
        }
    }
}
