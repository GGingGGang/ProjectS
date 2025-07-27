using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    new Rigidbody2D rigidbody2D;
    const float moveSpeed = 12; // Speed of the enemy

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }

   public void EnemyMove(Vector2 direction, float distance)
    {
        rigidbody2D.linearVelocity = moveSpeed * direction;

        StartCoroutine(WaitToStopMove(distance));
    }

    IEnumerator WaitToStopMove(float wait)
    {
        yield return new WaitForSeconds(wait);
        
        rigidbody2D.linearVelocity = Vector2.zero;
    }
}
