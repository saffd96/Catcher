using UnityEngine;
using UnityEngine.UI;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    #region Variables

    [Header("UI")]
    [SerializeField] private Text scoreLabel;
    [SerializeField] private GameOverView gameOverView;
    [SerializeField] private LivesView livesView;
    [SerializeField] private PauseView pauseView;

    [Header("SET LIVES")]
    [SerializeField] private int lives;

    [Header("Auto play")]
    [SerializeField] private bool isAutoPlay;

    private int totalScore;
    private int maxLives;
    private int currentLives;

    private bool isGamePaused;
    private bool isGameEnded;

    #endregion


    #region Properties

    public bool IsGamePaused
    {
        get => isGamePaused;
        set => isGamePaused = value;
    }
    public bool IsAutoPlay => isAutoPlay;
    private int CurrentLives
    {
        get => currentLives;
        set => currentLives = value;
    }
    private int MaxLives => maxLives;
    private int TotalScore { get; set; }

    #endregion


    #region UnityLifecycle

    private void Start()
    {
        ResetGame();
        Debug.Log($"{CurrentLives}, {maxLives}");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isGameEnded)
        {
            pauseView.PauseToggle();
        }
    }

    #endregion


    #region Public methods

    public void ResetGame()
    {
        maxLives = lives;
        currentLives = maxLives;
        TotalScore = totalScore = 0;

        gameOverView.gameObject.SetActive(false);
        pauseView.gameObject.SetActive(false);
        livesView.Setup(maxLives);
        scoreLabel.text = $"Score: {TotalScore}";
        Debug.Log("ResetGame");
    }

    #endregion


    #region Public Methods

    public void RemoveLive()
    {
        CurrentLives--;

        if (CurrentLives == 0)
        {
            ShowEndScreen();
            Time.timeScale = 0f;
            isGameEnded = true;
        }
        else
        {
            livesView.RemoveLife(CurrentLives);
        }

        livesView.RemoveLife(CurrentLives);
    }

    public void UpdateScore(int score)
    {
        TotalScore = totalScore += score;

        if (totalScore < 0)
        {
            totalScore = 0;
        }

        scoreLabel.text = $"Score: {totalScore}";
    }

    public void AddLive()
    {
        if (CurrentLives != MaxLives)
        {
            CurrentLives++;
            livesView.AddLive();
        }
    }

    #endregion


    #region Private Methods

    private void ShowEndScreen()
    {
        gameOverView.SetTotalScore(totalScore);
        gameOverView.gameObject.SetActive(true);
        livesView.gameObject.SetActive(false);
    }

    #endregion
}
