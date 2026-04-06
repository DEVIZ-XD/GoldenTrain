using UnityEngine;

public class CollisionSound : MonoBehaviour
{
    [SerializeField] AudioSource objectSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            objectSound.Play();
        }
    }
}
