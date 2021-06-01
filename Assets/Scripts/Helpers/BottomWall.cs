using UnityEngine;

public class BottomWall : MonoBehaviour
{
    #region Variables

    private BoxCollider2D boxCollider2D;
    private int yOffset = 3;

    #endregion


    #region Unity Lifecycle

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(Tags.GoodItem))
        {
            GameManager.Instance.RemoveLive();
        }

        Destroy(other.gameObject);
    }

    #endregion


    #region Public Methods

    public void Reset()
    {
        var xOffsetInPixels = Screen.width;
        var vectorOffsetX = new Vector3(xOffsetInPixels, 0, 0);
        var xOffsetInWorld = Camera.main.ScreenToWorldPoint(vectorOffsetX);

        boxCollider2D = GetComponent<BoxCollider2D>();
        boxCollider2D.size = new Vector2(xOffsetInWorld.x * 2, yOffset);
    }

    #endregion
}
