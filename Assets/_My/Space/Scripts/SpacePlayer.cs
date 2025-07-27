using UnityEngine;
using UnityEngine.InputSystem;

public class SpacePlayer : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    [SerializeField] float moveSpeed = 4; // Speed of the player
    [SerializeField] GameObject spawnPosition;

    [SerializeField] float leftLimit = -5;
    [SerializeField] float rightLimit = 5;

    Animator animator;

    [SerializeField] GameObject laser;
    float fireDelay = 0.3f; // Delay between shots  
    float fireTimer; // Timer to track when the next shot can be fired
    bool triggerPull = false;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        transform.position = spawnPosition.transform.position; // Set initial position to spawn position
    }

    // Update is called once per frame
    void Update()
    {
        if (fireTimer > 0)
        {
            fireTimer -= Time.deltaTime;
        }
        else if (triggerPull)
        {
            triggerPull = false; // Reset trigger pull after shooting
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        // Clamp the player's position within the specified limits
        Vector2 playerPosition = transform.position;

        if (playerPosition.x > rightLimit)
        {
            playerPosition.x = rightLimit;
        }
        else if (playerPosition.x < leftLimit)
        {
            playerPosition.x = leftLimit;
        }

        transform.position = playerPosition;
    }

    public void OnMove(InputValue inputValue)
    {
        float input = inputValue.Get<Vector2>().x;
        if(input > 0)
        {             
            animator.SetBool("Right", true);
            animator.SetBool("Left", false);
        }
        else if(input < 0)
        {
            animator.SetBool("Left", true);
            animator.SetBool("Right", false);
        }

        if ((Mathf.Abs(input) > 0))
        {
           rigidbody2D.linearVelocity = input * Vector2.right * moveSpeed;
        }
        else
        {
            rigidbody2D.linearVelocity = Vector2.zero;
            animator.SetBool("Left", false);
            animator.SetBool("Right", false);
        }
    }
    public void OnShoot()
    {
        triggerPull = true;
    }
    public void Shoot()
    {
        fireTimer = fireDelay;

        GameObject laserObj = Instantiate(laser);
    }

}
