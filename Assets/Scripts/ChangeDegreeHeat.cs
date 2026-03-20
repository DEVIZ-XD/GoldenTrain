using UnityEngine;
using UnityEngine.UI;

public class ChangeDegreeHeat : MonoBehaviour
{
    [SerializeField] private Slider degreeSlider;
    [SerializeField] GameManager gameManager;
    [SerializeField] private float degree = 8f;
    private bool gameEnded = false;

    private void Start()
    {
        degreeSlider.value = 50f;
    }

    private void Update()
    {
        if (gameEnded) return;

        degreeSlider.value += degree * Time.deltaTime;
        if (degreeSlider.value >= 100f)
        {
            gameEnded = true;
            gameManager.gameOver();
        }
    }
}
