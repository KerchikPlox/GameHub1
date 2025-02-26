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
        hearts[Player.instance.lives].SetActive(false);
    }

    public void Healing()
    {
        hearts[Player.instance.lives - 1].SetActive(true);
    }
}
