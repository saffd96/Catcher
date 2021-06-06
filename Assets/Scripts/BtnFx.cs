using UnityEngine;

public class BtnFx : MonoBehaviour
{
    #region Variables

    [SerializeField] private AudioClip howerFx;
    [SerializeField] private AudioClip clickFx;

    #endregion


    #region Public Methods

    public void HoverSound()
    {
        SfxAudioSource.Instance.PlaySfx(howerFx);
    }

    public void ClickSound()
    {
        SfxAudioSource.Instance.PlaySfx(clickFx);
    }

    #endregion
}
