using UnityEngine;

public class Platform : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Player.instance.gameObject && (collision.relativeVelocity.y < -0.2f))
        {
            Debug.Log("ןאüגûכ");
            Player.instance.rb.AddForce(transform.up * Player.instance.jumpForce, ForceMode2D.Impulse);
        }
    }
}
