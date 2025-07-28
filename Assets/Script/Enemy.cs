using UnityEngine;

public class Enemy : MonoBehaviour {
    private Vector3 basePosition;

    void Start() {
        basePosition = transform.position;
    }

    void Update() {
        int offsetPixel = GameManager.EnemyMoveTime -8;
        float offsetWorld = offsetPixel / 10f; 
        transform.position = basePosition + new Vector3(offsetWorld, 0f, 0f);

    }
}
