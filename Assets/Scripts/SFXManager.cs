using UnityEngine;
using UnityEngine.Audio;

public class SFXManager : MonoBehaviour
{
    private static SFXManager Instance;
    [SerializeField] AudioSource dynamiteSound;
    [SerializeField] AudioSource rockSound;
    [SerializeField] AudioSource coinSound;
    [SerializeField] AudioSource waterSound;
    [SerializeField] AudioSource coalSound;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayDynamite()
    {
        dynamiteSound.Play();
    }

    public void PlayRock()
    {
        rockSound.Play();
    }

    public void PlayCoin()
    {
        coinSound.Play();
    }

    public void PlayWater()
    {
        waterSound.Play();
    }

    public void PlayCoal()
    {
        coalSound.Play();
    }
}
