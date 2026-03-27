using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid;    

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dead"))
        {
            // 죽음
            GameObject.Destroy(gameObject);
        }
    }
}
