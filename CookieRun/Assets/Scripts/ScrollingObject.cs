using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    public float speed = 10f;
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>(); 
    }

    void Update()
    {
        if (gameManager.isGameOver) return;
        transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
    }
}
