using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    public int lives = 3;
    public float jumpForce = 4f;
    [SerializeField] private LayerMask ground;
    [SerializeField] private LayerMask spikes;
    [SerializeField] private Transform groundCheck;
    public int coins = 0;

    public static Player instance;

    public Rigidbody2D rb;
    public BoxCollider2D boxCollider;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        instance = this;
    }
    public void Damage()
    {
        lives--;
        Health.health.TakingDamage();
        if (lives == 0)
        {
            StartCoroutine(Death.instance.Dying());
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Horizontal")) Move();
    }

    private void Move() 
    {
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
    }

}
