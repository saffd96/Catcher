using UnityEngine;

public class Cat : MonoBehaviour
{
    #region Variables

    [SerializeField] private float boundary;

    #endregion


    #region Unity Lifecycle

    private void Update()
    {
        if (GameManager.Instance.IsGamePaused)
        {
            return;
        }

        if (!GameManager.Instance.IsGamePaused && !GameManager.Instance.IsAutoPlay)
        {
            MoveCatWithMouse();
        }
    }

    #endregion


    #region Private Methods

    private void MoveCatWithMouse()
    {
        Vector3 positionInPixels = Input.mousePosition;
        Vector3 positionInWorld = Camera.main.ScreenToWorldPoint(positionInPixels);
        
        var catPosition = positionInWorld;

        catPosition.y = transform.position.y;
        catPosition.z = 0;

        catPosition.x = Mathf.Clamp(catPosition.x, -boundary, boundary);
        transform.position = catPosition;
    }

    #endregion
}
