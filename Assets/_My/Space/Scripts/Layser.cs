using UnityEngine;

public class Layser : MonoBehaviour
{

    public Vector2 direction = Vector2.up;
    float speed = 15;
    new Rigidbody2D rigidbody2D;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.linearVelocity = direction * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
