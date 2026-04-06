using Unity.VisualScripting;
using UnityEngine;

public class FallingObjects : MonoBehaviour
{
    [SerializeField] GameObject fallingObject;
    [SerializeField] private float height;

    private void Start()
    {
        InvokeRepeating("SpawnObject", 1f, 1f);
    }

    private void SpawnObject()
    {
        Vector3 position = new Vector3(Random.Range(-18, 18), height, Random.Range(-18, 18));
        Instantiate(fallingObject, position, Quaternion.identity);
    }
}
