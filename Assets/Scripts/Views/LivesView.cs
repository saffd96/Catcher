using UnityEngine;

public class LivesView : MonoBehaviour
{
    #region Variables

    [SerializeField] private GameObject livePrefab;
    [SerializeField] private GameObject canvasGameObject;

    private GameObject[] livesImages;

    #endregion


    #region Public methods

    public void Setup(int livesCount)
    {
        if (livesImages == null)
        {
            livesImages = new GameObject[livesCount];

            for (var i = 0; i < livesImages.Length; i++)
            {
                CreateLifes(i);
            }
        }
        else
        {
            ResetLives();
        }
    }

    private void ResetLives()
    {
        for (var i = 0; i < livesImages.Length; i++)
        {
            SetActiveLife(true, i);
        }
    }

    public void AddLive()
    {
        for (int i = 0; i < livesImages.Length; i++)
        {
            if (livesImages[i] == null)
            {
                SetActiveLife(true, i);

                break;
            }
        }
    }

    public void RemoveLife(int currentLifes)
    {
        if (currentLifes >= 0)
        {
            SetActiveLife(false, currentLifes);
        }
    }

    #endregion


    #region Private methods

    private void CreateLifes(int i)
    {
        livesImages[i] = Instantiate(livePrefab, new Vector3(5f + 50 * i - 1, -5f), Quaternion.identity);
        livesImages[i].transform.SetParent(canvasGameObject.transform, false);
    }

    private void SetActiveLife(bool isActive, int i)
    {
        livesImages[i].SetActive(isActive);
    }

    #endregion
}
