using UnityEngine;
using UnityEngine.UI;

public class UIManager : SingletonMonoBehaviour<UIManager>
{
    #region Variables

    [Header("UI")]
    [SerializeField] private Text scoreLabel;
    [SerializeField] private GameOverView gameOverView;
    [SerializeField] private PauseView pauseView;

    #endregion


    #region Unity Lifecycle

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !GameManager.Instance.IsGameEnded)
        {
            pauseView.PauseToggle();
        }
    }

    #endregion


    #region Public Methods

    public void Reset()
    {
        gameOverView.gameObject.SetActive(false);
        pauseView.gameObject.SetActive(false);
        scoreLabel.text = $"Score: {GameManager.Instance.TotalScore}";
    }

    public void UpdateScore(int score)
    {
        GameManager.Instance.TotalScore += score;

        if (GameManager.Instance.TotalScore < 0)
        {
            GameManager.Instance.TotalScore = 0;
        }

        scoreLabel.text = $"Score: {GameManager.Instance.TotalScore}";
    }

    public void ShowEndScreenUI()
    {
        gameOverView.SetTotalScore(GameManager.Instance.TotalScore);
        gameOverView.gameObject.SetActive(true);
    }

    #endregion
}
