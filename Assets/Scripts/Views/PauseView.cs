using UnityEngine;

public class PauseView : MonoBehaviour
{
    #region Public Methods

    public void PauseToggle()
    {
        GameManager.Instance.IsGamePaused = !GameManager.Instance.IsGamePaused;

        Time.timeScale = GameManager.Instance.IsGamePaused ? 0f : 1f;

        gameObject.SetActive(GameManager.Instance.IsGamePaused);
    }

    #endregion
}
