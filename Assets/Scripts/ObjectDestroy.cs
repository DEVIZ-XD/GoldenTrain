using UnityEngine;
using System.Collections;

public class ObjectDestroy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Respawn"))
        {
            StartCoroutine("ObjectDestroyer");
        }
    }

    IEnumerator ObjectDestroyer()
    {
        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
    }
}
