using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float BodySpeed = 5f;
    [SerializeField] private int Gap = 10;
    [SerializeField] private GameObject BodyPrefab;
    [SerializeField] private GameManager gameManager;
    InputSystem_Actions inputActions;
    [SerializeField] private List<GameObject> BodyParts = new List<GameObject>();
    private List<Vector3> PositionHistory = new List<Vector3>();



    private void Awake()
    {
        inputActions = new InputSystem_Actions();
        inputActions.Enable();
    }
    private void Start()
    {
        
    }

    private void Update()
    {
        GamePause();
    }


    private void FixedUpdate()
    {
        Movement();
        BodyFollow();
    }

    private void Movement()
    {
        Vector2 inputDirection = inputActions.Player.Move.ReadValue<Vector2>();
        Vector3 moveDirection = (transform.up * inputDirection.x);

        transform.position += transform.right * speed * Time.deltaTime;
        transform.Rotate(0, inputDirection.x * rotationSpeed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Respawn"))
        {
            gameManager.gameOver();
        }
        if (other.gameObject.CompareTag("Coin"))
        {
            GrowSnake();
        }
        if (other.gameObject.CompareTag("Rock"))
        {
            if (BodyParts.Count > 0)
            {
                DecreaseSnake();
            }
            //else if (BodyParts.Count == 0)
            //{
            //    gameManager.gameOver();
            //}
        }
    }

    private void GamePause()
    {
        float IsStop = inputActions.UI.Cancel.ReadValue<float>();
        if (IsStop >= 0.5f)
        {
            gameManager.StopGame();
        }
    }

    private void GrowSnake()
    {
        GameObject body = Instantiate(BodyPrefab);
        BodyParts.Add(body);
    }

    private void DecreaseSnake()
    {
        GameObject lastPart = BodyParts[BodyParts.Count - 1];
        BodyParts.Remove(lastPart);

        StartCoroutine(BodyRemove(lastPart));
    }

    IEnumerator BodyRemove(GameObject part)
    {
        yield return new WaitForSeconds(4f);
        Destroy(part);
    }

    private void BodyFollow()
    {
        if (PositionHistory.Count > (BodyParts.Count + 1) * 10f)
        {
            PositionHistory.RemoveAt(PositionHistory.Count - 1);
        }
        PositionHistory.Insert(0, transform.position);
        int index = 1;
        foreach (var body in BodyParts)
        {
            Vector3 point = PositionHistory[Mathf.Min(index * Gap, PositionHistory.Count - 1)];
            Vector3 moveDirection = point - body.transform.position;
            body.transform.position += moveDirection * BodySpeed * Time.deltaTime;
            body.transform.LookAt(point);
            body.transform.Rotate(0, 90f, 0);
            index++;
        }
    }

    private void OnDestroy()
    {
        inputActions.Disable();
    }
}
