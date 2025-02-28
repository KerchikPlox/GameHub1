using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private BoxCollider2D coll;

    public static Death instance;
    private void Awake()
    {
        coll = GetComponent<BoxCollider2D>();
        instance = this;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Player.instance.gameObject)
        {
            Player.instance.rb.AddForce(transform.up * 360f, ForceMode2D.Impulse);
            StartCoroutine(Dying());    
        }
    }

    public IEnumerator Dying()
    {
        anim.SetBool("Dead", true);
        coll.enabled = false;
        Player.instance.enabled = false;
        Player.instance.boxCollider.enabled = false;
        FollowPlayer.instance.enabled = false;
        yield return new WaitForSeconds(2.8f);
        SceneManager.LoadScene("Game");
    }
}
