using UnityEngine;

public class Spikes : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Player.instance.gameObject && (collision.relativeVelocity.y < -0.2f))
        {
            Player.instance.rb.AddForce(transform.up * Player.instance.jumpForce, ForceMode2D.Impulse);
            Player.instance.Damage();
        }
    }
}
