using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering;

public class Dynamite : MonoBehaviour
{
    [SerializeField] GameObject explosionPrefab;
    [SerializeField] GameObject collider;
    [SerializeField] GameObject RadiusPrefab;
    [SerializeField] Renderer radius;

    [SerializeField] Color startColor = new Color(1f, 1f, 1f, 0f);
    [SerializeField] Color endColor = new Color(1f, 0f, 0f, 0.3f);

    [SerializeField] private float speed = 1f;

    private void Awake()
    {
        
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
        Destroy(explosion, 1f);
        Destroy(gameObject, 0.1f);
    }

    private void ObjectDestroyerPlayer()
    {
        collider.SetActive(true);
        GameObject explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
        ParticleSystem ps = explosion.GetComponent<ParticleSystem>();
        Destroy(explosion, 1f);
        Destroy(gameObject);
    }

    private void RadiusBlink()
    {
        radius.material.color = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time * speed, 1f));
    }
}
