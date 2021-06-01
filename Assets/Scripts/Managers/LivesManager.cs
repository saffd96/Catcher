using UnityEngine;

public class LivesManager : MonoBehaviour
{
    #region Variables

    [SerializeField] private LivesView livesView;

    [Header("SET LIVES")]
    [SerializeField] private int lives;

    #endregion


    #region Properties

    private int MaxLives { get; set; }
    public int CurrentLives { get; private set; }

    #endregion


    #region Public Methods

    public void Reset()
    {
        MaxLives = lives;
        CurrentLives = MaxLives;
        livesView.Setup(MaxLives);
    }

    public void RemoveLive()
    {
        CurrentLives--;
    }

    public void UpdateLivesImages()
    {
        livesView.RemoveLife(CurrentLives);
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
}
