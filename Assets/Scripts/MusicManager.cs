using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    private static MusicManager Instance;
    private AudioSource audioSource;
    public AudioClip backgroundMusic;
    [SerializeField] private Slider musicSlider;



    private void Start()
    {
        if (backgroundMusic != null)
        {
            PlayBackgroundMusic(backgroundMusic);
        }

        musicSlider.onValueChanged.AddListener(delegate { SetVolume(musicSlider.value); });
    }

    public static void SetVolume(float volume)
    {
        Instance.audioSource.volume = volume;
    }

    public static void PlayBackgroundMusic(AudioClip audioClip = null)
    {
        if (Instance.audioSource.clip != audioClip)
        {
            Instance.audioSource.clip = audioClip;
        }
        if(Instance.audioSource.clip != null)
        {
            Instance.audioSource.Play();
        }
    }
}
