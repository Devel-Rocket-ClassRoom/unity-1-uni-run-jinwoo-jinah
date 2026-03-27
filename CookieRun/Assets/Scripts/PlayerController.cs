using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid;
    BoxCollider2D playerCollider;
    Animator animator;

    public float jumpForce;
    public int jumpCount = 0;

    private bool isGrounded;
    private bool isSliding;

    private bool isDead;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();

        isGrounded = true;
        isSliding = false;
        isDead = false;

        animator.SetBool("isGrounded", isGrounded);
        animator.SetBool("isSliding", isSliding);
        animator.SetBool("isDead", isDead);
    }

    void Update()
    {
        if (isDead) return;

        if (Input.GetKeyDown(KeyCode.UpArrow) && !isSliding && jumpCount < 2)
        {
            rigid.linearVelocity = Vector2.zero;
            rigid.AddForceY(jumpForce, ForceMode2D.Impulse);
            jumpCount++;
        }

        else if (Input.GetKeyUp(KeyCode.UpArrow) && rigid.linearVelocity.y > 0)
        {
            rigid.linearVelocity *= 0.5f;
        }

        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            playerCollider.size = new Vector2(playerCollider.size.x, 0.6f);
            playerCollider.offset = new Vector2(playerCollider.offset.x, playerCollider.offset.y -0.3f);
            isSliding = true;
            animator.SetBool("isSliding", true);
        }

        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            playerCollider.size = new Vector2(playerCollider.size.x, 1.2f);
            playerCollider.offset = new Vector2(playerCollider.offset.x, playerCollider.offset.y +0.3f);
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

        else if (collision.CompareTag("Coin"))
        {
            // 점수 올리기 + 에너지 회복
            collision.gameObject.SetActive(false);  // 코인 비활성화
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

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Floor"))
        {
            isGrounded = false;
            animator.SetBool("isGrounded", false);
        }
    }
}
