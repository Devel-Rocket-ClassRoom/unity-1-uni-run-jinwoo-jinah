using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid;
    BoxCollider2D collider;
    Animator animator;

    public float jumpForce;
    public int jumpCount = 0;

    private bool isGrounded;
    private bool isSliding;

    private bool isDead;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();

        animator = GetComponent<Animator>();

        isGrounded = true;
        isSliding = false;
        isDead = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && !isSliding && jumpCount < 2)
        {
            rigid.linearVelocity = Vector2.zero;
            rigid.AddForceY(jumpForce, ForceMode2D.Impulse);
            jumpCount++;
            isGrounded = false;
            animator.SetBool("isGrounded", false);
        }

        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            collider.size = new Vector2(collider.size.x, 0.6f);
            collider.offset = new Vector2(collider.offset.x, collider.offset.y -0.3f);
            isSliding = true;
            animator.SetBool("isSliding", true);
        }

        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            collider.size = new Vector2(collider.size.x, 1.2f);
            collider.offset = new Vector2(collider.offset.x, collider.offset.y +0.3f);
            isSliding = false;
            animator.SetBool("isSliding", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dead"))
        {
            isDead = true;
            animator.SetBool("isDead", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Floor"))
        {
            jumpCount = 0;
            isGrounded = true;
            animator.SetBool("isGrounded", true);
        }
    }
}
