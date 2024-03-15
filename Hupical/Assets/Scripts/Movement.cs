using UnityEditor.Search;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // move stats var
    public static float moveSpeed = 5f;
    public float showSPD;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    // flip player on direction
    private bool facingRight = true;

    //rb and jump vars
    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {

        showSPD = moveSpeed;
        // Player movement
        float horizontalInput = Input.GetAxis("Horizontal");

        if(horizontalInput != 0)
        {

            rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        }

        else
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }



        // Player jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }

        //Turn player according to move direction
        if ((horizontalInput < 0 && facingRight) || (horizontalInput > 0 && !facingRight))
        {
            Flip();
        }   

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ground")
        {
            isGrounded = true;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    
}
