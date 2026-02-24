// using UnityEngine;

// public class player_movement : MonoBehaviour
// {
//     [SerializeField] private float speed;
//     private Rigidbody2D body;
//     public Animator animator;  // Animation Setup

//     void Start()
//     {
//         body = GetComponent<Rigidbody2D>();
//     }

//     void Update()
//     {
//         float horizontalInput = Input.GetAxis("Horizontal");
//         body.linearVelocity = new Vector2(horizontalInput * speed, body.linearVelocity.y);

//         // Flip player when facing left/right
//         if (horizontalInput > 0.01f)
//             transform.localScale = new Vector3(0.2f, 0.2f, 1f);  // Flip left, keep size 0.2
//         else if (horizontalInput < -0.01f)
//             transform.localScale = new Vector3(-0.2f, 0.2f, 1f);   // Flip right, keep size 0.2

//         if (Input.GetKey(KeyCode.Space))
//             body.linearVelocity = new Vector2(body.linearVelocity.x, speed);


//     animator.SetFloat("yVelocity", body.linearVelocity.y);
//         animator.SetFloat("magnitude", body.linearVelocity.magnitude);
//     }
// }
//
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;
    public float jumpForce = 7f;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    public Animator animator;  // Animation Setup
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float moveInput = 0f;

        // Horizontal input
        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
            moveInput = -1f;
        else if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
            moveInput = 1f;

        // Apply movement
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // Flip sprite based on direction
        if (moveInput < 0)
            sr.flipX = true;
        else if (moveInput > 0)
            sr.flipX = false;

        // Jump
        if (Keyboard.current.spaceKey.wasPressedThisFrame && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
        animator.SetFloat("yVelocity", rb.linearVelocity.y);
        animator.SetFloat("magnitude", rb.linearVelocity.magnitude);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = false;
    }
}
