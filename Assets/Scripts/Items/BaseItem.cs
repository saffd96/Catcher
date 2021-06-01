using UnityEngine;

public class BaseItem : MonoBehaviour
{
    #region Variables

    [SerializeField] private int score;
    [SerializeField] private Rigidbody2D rb;

    #endregion


    #region Properties

    public Rigidbody2D Rb => rb;

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


    #region Public Methods

    public void SetGravity(float gravityScale)
    {
        rb.gravityScale = gravityScale;
    }

    #endregion


    #region Private Methods

    protected virtual void ApplyEffect()
    {
        GameManager.Instance.UpdateScore(score);
    }

    #endregion
}
