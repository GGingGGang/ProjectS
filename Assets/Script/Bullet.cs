using UnityEngine;

public class Bullet : MonoBehaviour {
    void OnBecameInvisible() {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        // 적 유닛에 맞으면
        if (collision.CompareTag("Enemy")) {
            // 적 오브젝트 제거
            Destroy(collision.gameObject);

            // 총알 제거
            Destroy(gameObject);
        }
    }
}   