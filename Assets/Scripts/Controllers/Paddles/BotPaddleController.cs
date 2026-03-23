using UnityEngine;

public class BotPaddleController : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float limitY = 4.5f;
    [SerializeField] private Transform ball;

    void Update()
    {
        if (ball == null) return;

        float targetY = Mathf.Clamp(ball.position.y, -limitY, limitY);

        Vector2 targetPosition = new Vector2(transform.position.x, targetY);

        transform.position = Vector2.MoveTowards(
            transform.position,
            targetPosition,
            speed * Time.deltaTime
        );
    }
}