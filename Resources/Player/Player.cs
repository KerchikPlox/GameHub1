using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    public int lives = 3;
    public float jumpForce = 4f;
    [SerializeField] private LayerMask ground;
    [SerializeField] private LayerMask spikes;
    [SerializeField] private bool isGrounded = false;
    [SerializeField] private Transform groundCheck;
    public int coins = 0;

    public static Player instance;

    public Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        instance = this;
    }
    public void Damage()
    {
        lives--;
        Health.health.TakingDamage();
        Debug.Log(lives);
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

    private void FixedUpdate()
    {
        CheckGround();
    }

    private void CheckGround()
    {
        isGrounded = Physics2D.OverlapPoint(groundCheck.position, ground | spikes);
    }

}
