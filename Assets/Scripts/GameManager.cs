using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject stopMenuUI;
    [SerializeField] private GameObject WinUI;
    [SerializeField] private CoinCollectable coin;
    [SerializeField] private float winScore;

    private bool isOver = false;

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
        isOver = true;
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Win()
    {
        isOver = true;
        GetPreferences();
        WinUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void StopGame()
    {
        if (!isOver)
        {
            stopMenuUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void ResumeGame()
    {
        isOver = false;
        stopMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    
}
