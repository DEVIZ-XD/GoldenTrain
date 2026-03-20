using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject stopMenuUI;
    [SerializeField] private GameObject WinUI;
    [SerializeField] private CoinCollectable coin;
    [SerializeField] private float winScore;

    private void Start()
    {
        Time.timeScale = 1f;
    }

    private void Update()
    {
        if (coin.score == winScore)
        {
            Win();
        }
    }

    private void GetPreferences()
    {
        if (WinUI == null)
        {
            WinUI = GameObject.Find("WinPanel");
        }
        if (coin == null)
        {
            coin = FindFirstObjectByType<CoinCollectable>();
        }
    }
    public void gameOver()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Win()
    {
        GetPreferences();
        WinUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void StopGame()
    {
        stopMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        stopMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    
}
