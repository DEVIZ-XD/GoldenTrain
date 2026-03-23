using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Dynamite : MonoBehaviour
{
    [SerializeField] GameObject explosionPrefab;
    [SerializeField] GameObject collider;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Respawn"))
        {
            StartCoroutine("ObjectDestroyer");
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
}
