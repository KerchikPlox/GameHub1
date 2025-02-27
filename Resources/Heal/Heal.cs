using UnityEngine;

public class Heal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Player.instance.gameObject)
        {
            if (Player.instance.lives < 3)
            {
                Player.instance.lives++;
                Health.health.Healing();
            }
            else {
                Debug.Log("Максимальное здоровье!");
            }
            Destroy(gameObject);
        }
    }
}
