using UnityEngine;

public class GameManager : MonoBehaviour {
    public static int EnemyMoveTime = 0;

    private int direction = 1;
    private float timer = 0f;
    public float moveInterval = 0.5f; // �� �ʸ��� �̵����� ����

    void Update() {
        timer += Time.deltaTime;

        if (timer >= moveInterval) {
            timer = 0f;

            EnemyMoveTime += direction;

            if (EnemyMoveTime >= 16 || EnemyMoveTime <= 0) {
                direction *= -1;
            }

            Debug.Log("EnemyMoveTime: " + EnemyMoveTime);
        }
    }
}
