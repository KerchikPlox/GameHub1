using System.Collections;
using UnityEngine;

public class Boost : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Player.instance.gameObject)
        {
            Player.instance.StartCoroutine(ReturnJumpForce());
            BoostBar.boostbar.StartCoroutine(BoostBar.boostbar.DecreaseBar());
            Destroy(gameObject);
        }
    }
    private IEnumerator ReturnJumpForce()
    {
        Player.instance.jumpForce = 540f;
        yield return new WaitForSeconds(5f);
        Player.instance.jumpForce = 320f;
    }
}
