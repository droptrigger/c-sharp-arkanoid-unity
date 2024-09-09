using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singleton

    private static GameManager _instance;

    public static GameManager Instance => _instance;

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

    public GameObject gameOverScreen;

    public GameObject victoryScreen;

    public GameObject startScreen;

    public GameObject pauseScreen;

    public int AvailibleLives = 3;

    public int Lives { get; set; }

    public bool IsGameStarted { get; set; }

    public static event Action<int> OnLiveLost;

    private void Start()
    {
        this.Lives = this.AvailibleLives;
        Screen.SetResolution(960, 540, false);
        Ball.OnBallDeath += OnBallDeath;
        Brick.OnBrickDestruction += OnBrickDestruction;
        startScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Quit()
    {
        Application.Quit();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && this.IsGameStarted)
        {
            if (Time.timeScale == 0f)
            {
                pauseScreen.SetActive(false);
                Time.timeScale = 1f;
            }
            else
            {
                pauseScreen.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }

    public void StopPause()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1f;
    }

    private void OnBrickDestruction(Brick obj)
    {
        if (BrickManager.Instance.RemainingBricks.Count <= 0)
        {
            BallManager.Instance.ResetBalls();
            GameManager.Instance.IsGameStarted = false;
            BrickManager.Instance.LoadNextLevel(); 
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void StartGame()
    {
        startScreen.SetActive(false);
        Time.timeScale = 1f;
    }

    private void OnBallDeath(Ball obj)
    {
        if (BallManager.Instance.Balls.Count <= 0) 
        {
            this.Lives--;

            if (this.Lives < 1)
            {
                gameOverScreen.SetActive(true);
                Time.timeScale = 0f;
            }
            else
            {
                OnLiveLost?.Invoke(this.Lives);
                BallManager.Instance.ResetBalls();
                IsGameStarted = false;
                //BrickManager.Instance.LoadLevel(BrickManager.Instance.CurrentLevel);
            }
        }
    }

    private void OnDisable()
    {
        Ball.OnBallDeath -= OnBallDeath;
    }

    internal void ShowVictoryScreen()
    {
        victoryScreen.SetActive(true);
        Time.timeScale = 0f;
    }
}
