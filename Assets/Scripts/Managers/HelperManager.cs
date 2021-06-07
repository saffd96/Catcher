using UnityEngine;

public class HelperManager : SingletonMonoBehaviour<HelperManager>
{
    #region Variables

    [SerializeField] private Spawner spawner;
    [SerializeField] private DetectionZone detectionZone;
    [SerializeField] private BottomWall bottomWall;

    #endregion


    #region Public Methods

    public void Reset()
    {
        CheckForNull();

        spawner.Reset();
        bottomWall.Reset();
        detectionZone.Reset();
    }

    #endregion


    #region Private Methods

    private void CheckForNull()
    {
        if (detectionZone == null)
        {
            detectionZone = FindObjectOfType<DetectionZone>();
        }

        if (spawner == null)
        {
            spawner = FindObjectOfType<Spawner>();
        }

        if (bottomWall == null)
        {
            bottomWall = FindObjectOfType<BottomWall>();
        }
    }

    #endregion
}
