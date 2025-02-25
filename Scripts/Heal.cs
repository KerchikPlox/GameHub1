using UnityEngine;

public class Heal : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Player.instance.gameObject)
        {
            if (Player.instance.lives < 3)
            {
                Player.instance.lives++;
                Debug.Log(Player.instance.lives);
                Health.health.Healing();
            }
            else {
                Debug.Log("Максимальное здоровье!");
            }
            Destroy(gameObject);
        }
    }
}
