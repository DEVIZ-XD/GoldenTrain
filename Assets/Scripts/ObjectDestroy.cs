using UnityEngine;
using System.Collections;

public class ObjectDestroy : MonoBehaviour
{
    SFXManager soundManager;

    private void Awake()
    {
        soundManager = GameObject.Find("SFXManager").GetComponent<SFXManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Respawn"))
        {
            soundManager.PlayRock();
            StartCoroutine("ObjectDestroyer");
        }
    }

    IEnumerator ObjectDestroyer()
    {
        yield return new WaitForSeconds(4f);
        Destroy(transform.parent.gameObject);
    }
}
