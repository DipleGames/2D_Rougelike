using UnityEngine;

public class AudioManager : SingleTon<AudioManager>
{
    public AudioSource audioSource;

    [SerializeField] private AudioClip[] _sfxs;
    [SerializeField] private AudioClip[] _bgms;

    void Start()
    {
        PlayBGM();
    }

    void PlaySFX()
    {

    }
    
    void PlayBGM()
    {
        audioSource.clip = _bgms[0];

        if (audioSource.clip != null)
            audioSource.Play();
    }
}
