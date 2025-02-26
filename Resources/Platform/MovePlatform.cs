using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float distance = 2f;
    [SerializeField] private float speed = 2f;

    [SerializeField] private Vector3 startPosition;
    [SerializeField] private bool movingRight = true;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        if (movingRight)
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            if (transform.position.x >= startPosition.x + distance)
            {
                movingRight = false;
            }
        }
        else
        {
            transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
            if (transform.position.x <= startPosition.x - distance)
            {
                movingRight = true;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Player.instance.gameObject && (collision.relativeVelocity.y < -0.2f))
        {
            Player.instance.rb.AddForce(transform.up * Player.instance.jumpForce, ForceMode2D.Impulse);
        }
    }
}
