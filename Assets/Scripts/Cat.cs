using UnityEngine;

public class Cat : MonoBehaviour
{
    #region Variables

    [SerializeField] private float boundary;

    Vector3 catPosition;

    #endregion


    #region Unity Lifecycle

    private void Update()
    {
        if (GameManager.Instance.IsGamePaused) return;

        Vector3 positionInPixels = Input.mousePosition;
        Vector3 positionInWorld = Camera.main.ScreenToWorldPoint(positionInPixels);

        catPosition = positionInWorld;

        catPosition.y = transform.position.y;
        catPosition.z = 0;

        catPosition.x = Mathf.Clamp(catPosition.x, -boundary, boundary);
        transform.position = catPosition;
    }

    #endregion
}
