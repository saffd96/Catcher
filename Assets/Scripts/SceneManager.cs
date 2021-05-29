using UnityEngine;

public class SceneManager : MonoBehaviour
{
    #region Public methods

    public void ExitGame()
    {
        Application.Quit();
        Debug.LogError("QUIT");
    }

    public void LoadScene(int index)
    {
        Time.timeScale = 1f;
        GameManager.Instance.ResetGame();
        UnityEngine.SceneManagement.SceneManager.LoadScene(index);
        Debug.LogError($"Load Scene {index}");
    }

    #endregion
}
