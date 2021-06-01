using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    #region Variables

    [SerializeField] private UIManager uiManager;
    [SerializeField] private LivesManager livesManager;
    [SerializeField] private HelperManager helperManager;

    [Header("Auto play")]
    [SerializeField] private bool isAutoPlay;

    #endregion


    #region Properties

    public bool IsAutoPlay => isAutoPlay;
    public bool IsGameEnded { get; private set; }
    public bool IsGamePaused { get; set; }
    public int TotalScore { get; set; }

    #endregion


    #region UnityLifecycle

    private void Start()
    {
        ResetGame();
    }

    #endregion


    #region Public methods

    public void ResetGame()
    {
        TotalScore = 0;

        CheckForNull();

        uiManager.Reset();
        livesManager.Reset();
        helperManager.Reset();

        Debug.Log("ResetGame");
    }

    public void RemoveLive()
    {
        livesManager.RemoveLive();

        if (livesManager.CurrentLives == 0)
        {
            ShowEndScreen();
            Time.timeScale = 0f;
            IsGameEnded = true;
        }

        livesManager.UpdateLivesImages();
    }

    public void UpdateScore(int score)
    {
        uiManager.UpdateScore(score);
    }

    public void AddLive()
    {
        livesManager.AddLive();
    }

    #endregion


    #region Private Methods

    private void ShowEndScreen()
    {
        uiManager.ShowEndScreenUI();
    }

    private void CheckForNull()
    {
        if (uiManager == null)
        {
            uiManager = FindObjectOfType<UIManager>();
        }

        if (livesManager == null)
        {
            livesManager = FindObjectOfType<LivesManager>();
        }
    }

    #endregion
}
