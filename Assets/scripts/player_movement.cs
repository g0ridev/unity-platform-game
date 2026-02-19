using UnityEngine;

public class player_movement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.linearVelocity = new Vector2(horizontalInput * speed, body.linearVelocity.y);

        // Flip player when facing left/right
        if (horizontalInput > 0.01f)
            transform.localScale = new Vector3(0.2f, 0.2f, 1f);  // Flip left, keep size 0.2
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-0.2f, 0.2f, 1f);   // Flip right, keep size 0.2

        if (Input.GetKey(KeyCode.Space))
            body.linearVelocity = new Vector2(body.linearVelocity.x, speed);
    }
}
