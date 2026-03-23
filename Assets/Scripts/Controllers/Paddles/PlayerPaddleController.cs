using UnityEngine;

public class PlayerPaddleController : MonoBehaviour
{
    public enum PlayerID
    {
        PlayerOne,
        PlayerTwo
    }

    [Header("Player Settings")]
    [SerializeField] private PlayerID playerID;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float limitY = 4.5f;

    [Header("References")]
    public GameManager gameManager;

    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        float moveInput = 0f;

        if (playerID == PlayerID.PlayerOne)
        {
            moveInput = Input.GetAxis("Vertical"); 
        }
        else
        {
            moveInput = Input.GetAxis("Vertical2"); 
        }

        Vector3 newPosition = transform.position + moveInput * speed * Time.deltaTime * Vector3.up;
        newPosition.y = Mathf.Clamp(newPosition.y, -limitY, limitY);

        transform.position = newPosition;
    }
}