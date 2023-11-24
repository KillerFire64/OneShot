using UnityEngine;
using System.Collections;

public class BallMovement : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private bool canChangeDirection = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed, 0);
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * speed, rb.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (canChangeDirection)
        {
            StartCoroutine(ChangeDirectionCoroutine());
        }
    }

    IEnumerator ChangeDirectionCoroutine()
    {
        canChangeDirection = false;

        rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);

        yield return new WaitForSeconds(1);

        canChangeDirection = true;
    }
}
