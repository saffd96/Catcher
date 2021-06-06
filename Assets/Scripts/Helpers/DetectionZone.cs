using UnityEngine;

public class DetectionZone : MonoBehaviour
{
    #region Variables

    [SerializeField] private Cat cat;

    private BoxCollider2D boxCollider2D;

    #endregion


    #region Public Methods

    public void Reset()
    {
        var xOffsetInPixels = Screen.width;
        var vectorOffsetX = new Vector3(xOffsetInPixels, 0, 0);
        var xOffsetInWorld = Camera.main.ScreenToWorldPoint(vectorOffsetX);
        var yOffset = 0.1f;
        boxCollider2D = GetComponent<BoxCollider2D>();
        boxCollider2D.size = new Vector2(xOffsetInWorld.x * 2, yOffset);

        if (cat == null)
        {
            cat = FindObjectOfType<Cat>();
            Debug.Log("cat = FindObjectOfType<Cat>();");
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!GameManager.Instance.IsAutoPlay) return;

        var contactPoint = other.transform.position;
        var catTransform = cat.transform;

        if (other.gameObject.CompareTag(Tags.GoodItem) || other.gameObject.CompareTag(Tags.GoodPowerUp))
        {
            catTransform.position = new Vector3(contactPoint.x, catTransform.position.y, 0);
        }
        else if (other.gameObject.CompareTag(Tags.BadPowerUp))
        {
            catTransform.position = new Vector3(-contactPoint.x, catTransform.position.y, 0);
        }
    }

    #endregion
}
