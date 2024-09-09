using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI Level;
    public TextMeshProUGUI Lives;

    public int Score { get; set; }

    private void Awake()
    {
        Brick.OnBrickDestruction += OnBrickDestruction;
        BrickManager.OnLevelLoaded += OnLevelLoaded;
        GameManager.OnLiveLost += OnLiveLost;
    }

    private void Start()
    {
        OnLiveLost(GameManager.Instance.AvailibleLives);
    }

    private void OnLiveLost(int reLives)
    {
        Lives.text = $"∆»«Õ≈…: {reLives}";
    }

    private void OnLevelLoaded()
    {
        UpdateLvlText();
        UpdateScoreText(0);
    }

    private void UpdateScoreText(int v)
    {
        this.Score += v;
        string scoreString = this.Score.ToString().PadLeft(3, '0');
        ScoreText.text = $@"—◊≈“: {scoreString}";
    }

    private void OnBrickDestruction(Brick obj)
    {
        UpdateScoreText(10);
    }

    private void UpdateLvlText()
    {
        Level.text = $@"{BrickManager.Instance.CurrentLevel + 1}/{BrickManager.Instance.LevelsData.Count}";
    }

    private void OnDisable()
    {
        Brick.OnBrickDestruction -= OnBrickDestruction;
        BrickManager.OnLevelLoaded -= OnLevelLoaded;
    }
}
