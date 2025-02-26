using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Player.instance.gameObject)
        {
            Player.instance.coins++;
            Debug.Log(Player.instance.coins);
            Destroy(gameObject);
        }
    }
}
