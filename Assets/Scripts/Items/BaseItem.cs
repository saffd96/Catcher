using UnityEngine;

public class BaseItem : MonoBehaviour
{
    #region Variables

    [SerializeField] private int score;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private AudioClip deathAudioClip;

    #endregion


    #region Unity Lifecycle

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag(Tags.Cat)) return;

        ApplyEffect();
        Destroy(gameObject);
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
        SfxAudioSource.Instance.PlaySfx(deathAudioClip);
        GameManager.Instance.UpdateScore(score);
    }

    #endregion
}
