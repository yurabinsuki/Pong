using UnityEngine;

public class BallController : MonoBehaviour
{
private Rigidbody2D rb;
public Vector2 startingVelocity = new Vector2(-5f, 5f);

public GameManager gameManager;

public void ResetBall()
    {
        transform.position = Vector3.zero;
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
        rb.linearVelocity = startingVelocity;     
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Wall"))
        {
            Vector2 newVelocity = rb.linearVelocity;

            newVelocity.y = -newVelocity.y;
            rb.linearVelocity = newVelocity;
        }   

        else if(collision.gameObject.CompareTag("Paddle"))
        {
            rb.linearVelocity = new Vector2 (-rb.linearVelocity.x, rb.linearVelocity.y);
            IncreaseSpeed();
        }

        else if (collision.gameObject.CompareTag("PlayerGoal"))
        {
            gameManager.EnemyScores();
            ResetBall();
        }
        else if (collision.gameObject.CompareTag("EnemyGoal"))
        {
            gameManager.PlayerScores();
            ResetBall();
        }
    }

    private void IncreaseSpeed()
    {
        rb.linearVelocity *= 1.1f;
    }

}
