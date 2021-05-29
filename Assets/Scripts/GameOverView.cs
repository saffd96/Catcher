using UnityEngine;
using UnityEngine.UI;

public class GameOverView : MonoBehaviour
{
    #region Variables

    [SerializeField] private Text gameOverText;

    #endregion


    #region Public methods

    public void SetTotalScore(int totalScore)
    {
        gameOverText.text = $"You lose\nYour score: {totalScore}";
    }

    #endregion
}
