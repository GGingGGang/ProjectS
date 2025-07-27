using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 10f;
    public float fireRate = 0.2f;
    private float nextFireTime = 0f;

    //// Start is called once before the first execution of Update after the MonoBehaviour is created
    //void Start()
    //{

    //}

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.A) && Time.time >= nextFireTime) {
            Shoot();
            nextFireTime = Time.time + fireRate;

        }
        /*
        */
    }

    void Shoot() {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null) {
            rb.linearVelocity = Vector2.up * bulletSpeed;
        }
    }
}
