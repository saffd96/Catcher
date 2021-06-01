using UnityEngine;

public class SceneManager : MonoBehaviour
{
    #region Public methods

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
        Debug.LogError("QUIT");
#endif
    }

    public void LoadScene(int index)
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(index);
        Debug.LogError($"Load Scene {index}");
    }

    #endregion
}
