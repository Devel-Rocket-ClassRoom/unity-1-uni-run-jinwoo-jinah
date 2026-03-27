using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    public float width;

    void Update()
    {
        if (transform.position.x < -width)
        {
            transform.position += new Vector3(width *2, 0, 0);
        }
    }
}
