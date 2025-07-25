using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float moveSpeed = 5f;
    public float screenHalfWidthInWorldUnits = 3.6f;

    private float spriteHalfWidth;

    void Start() {
        spriteHalfWidth = GetComponent<SpriteRenderer>().bounds.extents.x;
    }

    void Update() {
        float inputX = Input.GetAxisRaw("Horizontal");
        Vector3 movement = new Vector3(inputX, 0, 0) * moveSpeed * Time.deltaTime;
        transform.position += movement;

        float clampedX = Mathf.Clamp(transform.position.x, -screenHalfWidthInWorldUnits + spriteHalfWidth, screenHalfWidthInWorldUnits - spriteHalfWidth);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }
}
