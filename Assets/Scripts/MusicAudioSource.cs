using UnityEngine;

public class MusicAudioSource : SingletonMonoBehaviour<MusicAudioSource>
{
    
    #region Variables

    private AudioSource audioSource;

    #endregion
    
    #region Unity Lifecycle

    protected override void Awake()
    {
        base.Awake();
        audioSource = FindObjectOfType<MusicAudioSource>().GetComponent<AudioSource>();
    }

    #endregion
}
