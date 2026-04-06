using UnityEngine;
using System.Collections;


public class Dynamite : MonoBehaviour
{
    [SerializeField] GameObject explosionPrefab;
    [SerializeField] GameObject collider;
    [SerializeField] GameObject RadiusPrefab;
    [SerializeField] Renderer radius;

    [SerializeField] Color startColor = new Color(1f, 1f, 1f, 0f);
    [SerializeField] Color endColor = new Color(1f, 0f, 0f, 0.3f);

    [SerializeField] private float speed = 1f;
    SFXManager soundManager;

    private void Awake()
    {
        soundManager = GameObject.Find("SFXManager").GetComponent<SFXManager>();
    }

    private void Start()
    {
        transform.rotation = Quaternion.Euler(0f, 0, 90f);
    }

    private void Update()
    {
        RadiusBlink();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Respawn"))
        {
            StartCoroutine("ObjectDestroyer");
            RadiusPrefab.SetActive(true);
        }

        if (other.CompareTag("Player"))
        {
            ObjectDestroyerPlayer();
        }
    }

    IEnumerator ObjectDestroyer()
    {
        yield return new WaitForSeconds(4f);
        collider.SetActive(true);
        GameObject explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
        ParticleSystem ps = explosion.GetComponent<ParticleSystem>();
        soundManager.PlayDynamite();
        Destroy(explosion, 1f);
        Destroy(transform.parent.gameObject, 0.1f);
    }

    private void ObjectDestroyerPlayer()
    {
        GameObject explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
        ParticleSystem ps = explosion.GetComponent<ParticleSystem>();
        soundManager.PlayDynamite();
        Destroy(explosion, 1f);
        Destroy(transform.parent.gameObject, 0.1f);
    }

    private void RadiusBlink()
    {
        radius.material.color = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time * speed, 1f));
    }
}
