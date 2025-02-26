using System.Collections;
using UnityEngine;

public class Boost : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Player.instance.gameObject)
        {
            Player.instance.StartCoroutine(ReturnJumpForce());
            Destroy(gameObject);
        }
    }
    private IEnumerator ReturnJumpForce()
    {
        Player.instance.jumpForce = 640f;
        yield return new WaitForSeconds(5f);
        Player.instance.jumpForce = 320f;
    }
}
