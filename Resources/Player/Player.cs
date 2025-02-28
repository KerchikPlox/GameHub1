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
    [SerializeField] private float moveInput;
    private Coroutine boostCoroutine;
    public int coins = 0;

    public static int control;
    public static Player instance;

    public Rigidbody2D rb;
    public BoxCollider2D boxCollider;

    public Joystick joystick;

    private void Awake()
    {
        if (control == 3)
        {
            joystick.gameObject.SetActive(true);
        }
        
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

    void Update()
    {
        Move();
    }

    private void Move()
    {
        moveInput = 0;
        if (control == 1) moveInput = Input.GetAxis("Horizontal");
        else if (control == 2 && SystemInfo.supportsGyroscope) moveInput = Input.acceleration.x;
        else if (control == 3) moveInput = joystick.Horizontal;

        Vector3 dir = transform.right * moveInput;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
    }

    public void ActivateBoost()
    {
        if (boostCoroutine != null)
        {
            StopCoroutine(boostCoroutine);
        }
        boostCoroutine = StartCoroutine(ReturnJumpForce());
    }

    private IEnumerator ReturnJumpForce()
    {
        jumpForce = 540f;
        yield return new WaitForSeconds(5f);
        jumpForce = 320f;
    }
}
