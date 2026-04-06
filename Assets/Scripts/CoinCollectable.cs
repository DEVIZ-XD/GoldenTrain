using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollectable : MonoBehaviour
{
    public int score = 0;
    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] Slider degreeSlider;
    [SerializeField] private float waterDegree = 20f;
    [SerializeField] private float coalDegree = 20f;
    [SerializeField] private float minDistance = -18f;
    [SerializeField] private float maxDistance = 18f;

    SFXManager soundManager;

    private void Awake()
    {
        soundManager = GameObject.Find("SFXManager").GetComponent<SFXManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            score++;
            soundManager.PlayCoin();
            scoreText.text = "Score " + score.ToString();
            var position = new Vector3(Random.Range(minDistance, maxDistance), 6, Random.Range(minDistance, maxDistance));
            other.transform.position = position;
        }

        if (other.gameObject.CompareTag("Water"))
        {
            degreeSlider.value -= waterDegree;
            soundManager.PlayWater();
            var position = new Vector3(Random.Range(minDistance, maxDistance), 6, Random.Range(minDistance, maxDistance));
            other.transform.position = position;
        }

        if (other.gameObject.CompareTag("Coal"))
        {
            degreeSlider.value += coalDegree;
            soundManager.PlayCoal();
            var position = new Vector3(Random.Range(minDistance, maxDistance), 6, Random.Range(minDistance, maxDistance));
            other.transform.position = position;
        }

        if (other.gameObject.CompareTag("Rock"))
        {
            if (score > 0)
            {
                score--;
                scoreText.text = "Score " + score.ToString();
            }
        }

        if (other.gameObject.CompareTag("Dynamite"))
        {
            if (score > 0)
            {
                score--;
                scoreText.text = "Score " + score.ToString();
            }
        }

    }


}
