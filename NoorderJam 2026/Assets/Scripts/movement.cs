using UnityEngine;

public class movement : MonoBehaviour
{
public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public Vector2 groundCheckSize = new Vector2(0.5f, 0.1f);

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool jumpPressed;
    private bool jumpHeld;

    private SpriteRenderer player_spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        player_spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(move * moveSpeed, rb.linearVelocity.y);

        isGrounded = IsGrounded();

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            jumpPressed = true;
            jumpHeld = true;
        }
        if (Input.GetButtonUp("Jump"))
        {
            jumpHeld = false;
        }

        if (move > 0)
        {
            player_spriteRenderer.flipX = false;
        }
        else if (move < 0)
        {
            player_spriteRenderer.flipX = true;
        }
    }

    void FixedUpdate()
    {
        if (jumpPressed)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            jumpPressed = false;
        }
        if (!jumpHeld && rb.linearVelocity.y > 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
        }
    }

    bool IsGrounded()
    {
        return Physics2D.BoxCast(groundCheck.position, groundCheckSize, 0f, Vector2.down, 0.1f, groundLayer);
    }
    }

