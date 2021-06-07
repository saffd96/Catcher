using UnityEngine;

public class Cat : SingletonMonoBehaviour<Cat>
{
    #region Variables

    [SerializeField] private float boundary;

    private BoxCollider2D boxCollider2D;

    #endregion


    #region Unity Lifecycle

    protected override void Awake()
    {
        base.Awake();

        var xOffsetInPixels = Screen.width;
        var vectorOffsetX = new Vector3(xOffsetInPixels, 0, 0);
        var xOffsetInWorld = Camera.main.ScreenToWorldPoint(vectorOffsetX);

        boxCollider2D = GetComponent<BoxCollider2D>();

        boundary = xOffsetInWorld.x - boxCollider2D.size.x / 2;
    }

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
