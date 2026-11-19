using UnityEngine;
using UnityEngine.InputSystem;

public class ProjectileScript : MonoBehaviour
{
    public float speed;
    Rigidbody2D rigidBoby2D;
    bool isLaunched;

    public float maxRange;

    void Start()
    {
        rigidBoby2D = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        rigidBoby2D.linearVelocity = Vector2.up * speed;

        if (transform.position.y > maxRange)
        {
            Destroy(gameObject);
        }
    }
}
