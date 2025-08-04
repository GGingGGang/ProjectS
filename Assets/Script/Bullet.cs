using UnityEngine;

public class Bullet : MonoBehaviour {
    void OnBecameInvisible() {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        // �� ���ֿ� ������
        if (collision.CompareTag("Enemy")) {
            // �� ������Ʈ ����
            Destroy(collision.gameObject);

            // �Ѿ� ����
            Destroy(gameObject);
        }
    }
}   