using UnityEngine;

public class SfxAudioSource : SingletonMonoBehaviour<SfxAudioSource>
{
    #region Variables

    private AudioSource audioSource;

    #endregion


    #region Unity Lifecycle

    protected override void Awake()
    {
        base.Awake();
        audioSource = FindObjectOfType<SfxAudioSource>().GetComponent<AudioSource>();
    }

    #endregion


    #region Public Methods

    public void PlaySfx(AudioClip audioClip)
    {
        if (audioClip!=null)
        {
            audioSource.PlayOneShot(audioClip);
        }
    }

    #endregion
}
