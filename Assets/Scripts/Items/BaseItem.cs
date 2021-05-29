using UnityEngine;

public class BaseItem : MonoBehaviour
{
    #region Variables

    [SerializeField] private int score;

    #endregion


    #region Unity Lifecycle

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(Tags.Cat))
        {
            ApplyEffect();
            Destroy(gameObject);
        }
    }

    #endregion


    #region Private Methods

    protected virtual void ApplyEffect()
    {
        GameManager.Instance.UpdateScore(score);
    }

    #endregion
}
