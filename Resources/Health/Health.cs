using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private GameObject[] hearts;
    public static Health health;

    private void Awake()
    {
        health = this;
    }
    public void TakingDamage()
    {
        hearts[Player.instance.lives].GetComponent<Animator>().SetBool("Destroy", true);
        StartCoroutine(DestroyHeart());
    }

    public void Healing()
    {
        hearts[Player.instance.lives - 1].SetActive(true);
        hearts[Player.instance.lives - 1].GetComponent<Animator>().SetBool("Appear", true);
        StartCoroutine(WaitForAppear());
    }

    private IEnumerator DestroyHeart()
    {
        yield return new WaitForSeconds(0.8f);
        hearts[Player.instance.lives].SetActive(false);
    }

    private IEnumerator WaitForAppear()
    {
        yield return new WaitForSeconds(0.37f);
        hearts[Player.instance.lives - 1].GetComponent<Animator>().SetBool("ToIdle", true);
        hearts[Player.instance.lives - 1].GetComponent<Animator>().SetBool("Appear", false);
        hearts[Player.instance.lives].GetComponent<Animator>().SetBool("Destroy", false);
    }
}
