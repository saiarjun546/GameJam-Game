using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Speed of the player
    public float moveSpeed = 5f;

    // Ground detection variables
    public Transform GroundCheck;
    public float GroundDistance = 0.2f;
    public LayerMask GroundMask;

    // Jumping variables
    public float jumpForce = 3f;

    private bool isGrounded = true;

    // Rigidbody2D component
    private Rigidbody2D rb;

    // Movement direction
    private Vector2 moveDirection;

    void Start()
    {
        // Get the Rigidbody2D component on the player object
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get input for horizontal (left/right) movement
        float moveX = Input.GetAxisRaw("Horizontal");  // A/D or Arrow keys

        // Handle horizontal movement
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

        // Ground detection using a small sphere at the player's feet
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, GroundDistance, GroundMask);

        // Jumping based on Y-axis input (W or Up Arrow)
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (isGrounded) // Ensure the player is grounded before jumping
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Jumping effect
            }
        }
    }
}
