using UnityEngine;

public class BottomWall : MonoBehaviour
{
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
}
