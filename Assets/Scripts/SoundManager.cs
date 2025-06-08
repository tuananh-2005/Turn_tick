using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [Header("Audio Sources")]
    public AudioSource musicSource;

    [Header("Audio Clips")]
    public AudioClip clickSound;
    public AudioClip bellSound;
    public AudioClip winSound;
    public AudioClip loseSound;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void PlayClick()
    {
        if (clickSound != null)
            AudioSource.PlayClipAtPoint(clickSound, Camera.main.transform.position);
    }

    public void PlayBell()
    {
        if (bellSound != null)
            AudioSource.PlayClipAtPoint(bellSound, Camera.main.transform.position);
    }

    public void PlayWin()
    {
        if (winSound != null)
            AudioSource.PlayClipAtPoint(winSound, Camera.main.transform.position);
    }

    public void PlayLose()
    {
        if (loseSound != null)
            AudioSource.PlayClipAtPoint(loseSound, Camera.main.transform.position);
    }

    public void SetMusicVolume(float volume)
    {
        if (musicSource != null)
            musicSource.volume = volume;
    }
}



