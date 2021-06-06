using UnityEngine;
using System.Collections;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    #region Variables

    [Header("Managers")]
    [SerializeField] private UIManager uiManager;
    [SerializeField] private LivesManager livesManager;
    [SerializeField] private HelperManager helperManager;

    [Header("Audio")]
    [SerializeField] private AudioClip deathSound;

    [Header("Auto play")]
    [SerializeField] private bool isAutoPlay;

    [Header("DEV")]
    [SerializeField] private BaseItem[] sceneItems;

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
        DeleteItemsOnScene();

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
            StartCoroutine(LoseGame(0.1f, deathSound));
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

        if (helperManager == null)
        {
            helperManager = FindObjectOfType<HelperManager>();
        }
    }

    private void DeleteItemsOnScene()
    {
        sceneItems = FindObjectsOfType<BaseItem>();

        foreach (var item in sceneItems)
        {
            Destroy(item.gameObject);
        }
    }

    #endregion


    #region Coroutines

    IEnumerator LoseGame(float seconds, AudioClip sfx)
    {
        yield return new WaitForSeconds(seconds);

        SfxAudioSource.Instance.PlaySfx(sfx);
        ShowEndScreen();
        Time.timeScale = 0f;
        IsGameEnded = true;
    }

    #endregion
}
