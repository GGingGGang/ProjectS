using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Linq;


public class GameManager : MonoBehaviour {
    public static int EnemyMoveTime = 0;

    private int direction = 1;
    private float timer = 0f;
    public float moveInterval = 0.5f; // �� �ʸ��� �̵����� ����

    public GameObject enemyPrefab; // Inspector���� Enemy ������ �巡��

    private List<Vector2> spawnPoints = new List<Vector2>();
    private List<Vector2> usedPoints = new List<Vector2>();
    
    void Start() {
        InitSpawnPoints();
        SpawnEnemies(5); // ���ϴ� �� ��ŭ ���� ����
    }
    void Update() {
        timer += Time.deltaTime;
        int enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (timer >= moveInterval) {
            timer = 0f;

            EnemyMoveTime += direction;

            if (EnemyMoveTime >= 16 || EnemyMoveTime <= 0) {
                direction *= -1;
            }

            Debug.Log("EnemyMoveTime: " + EnemyMoveTime);
        }

        if (enemyCount < 1) {
            SpawnEnemies(30);
        }
    }


    void InitSpawnPoints() {
        for (float x = -3.325f; x <= 3.325f; x += 0.5f) {
            for (float y = 1f; y <= 3f; y += 1f) {
                spawnPoints.Add(new Vector2(x, y));
            }
        }
    }

    void SpawnEnemies(int count) {
        usedPoints.Clear();

        for (int i = 0; i < count; i++) {
            Vector2 point = GetRandomAvailablePoint();
            if (point != Vector2.zero) {
                Instantiate(enemyPrefab, point, Quaternion.Euler(0, 0, 180)); // 180�� ȸ��
                usedPoints.Add(point);
            }
        }
    }

    Vector2 GetRandomAvailablePoint() {
        List<Vector2> available = spawnPoints.Except(usedPoints).ToList();
        if (available.Count == 0) return Vector2.zero;

        int rand = Random.Range(0, available.Count);
        return available[rand];
    }

}
