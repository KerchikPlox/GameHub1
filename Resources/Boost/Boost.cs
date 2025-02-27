using UnityEngine;

public class Boost : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Player.instance.gameObject)
        {
            Player.instance.ActivateBoost();

            BoostBar.boostbar.StopAllCoroutines();
            BoostBar.boostbar.StartCoroutine(BoostBar.boostbar.DecreaseBar());

            Destroy(gameObject);
        }
    }
}