using  System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] GameObject[] enemyLinUp = new GameObject[6];
    List<List<GameObject>> fleetList;
    int numColumn = 7;

    float enemyMoveTimer = 1;
    float stepDealay = 2;

    float vStep = 0.05f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnFleet();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsEnemymoveTime())
            return;

        MoveFleet(Vector2.down, vStep);
    }

    private void spawnFleet()
    {
        fleetList = new List<List<GameObject>>();
        
        for(int i = 0; i < numColumn; i++)
        {
            List<GameObject> column = new List<GameObject>();

            for(int j = 0; j < enemyLinUp.Length; j++)
            {
                GameObject enemy = Instantiate(enemyLinUp[j]);
                column.Add(enemy);
                PositionEnmey(enemy, i, j);
            }

            fleetList.Add(column);
        }
    }

    private void PositionEnmey(GameObject enemy, int column, int row)
    {
        float offsetX = 1;
        float offsetY = 1;

        float startX = transform.position.x + 0.5f + (-offsetX * (float)numColumn / 2);
        float startY = transform.position.y + (offsetY * 9);

        float posX = startX + (float)column * offsetX;
        float posY = startY - (float)row * offsetY;

        enemy.transform.position = new Vector2(posX, posY);
    }
    private bool IsEnemymoveTime()
    {
        bool result = false;

        enemyMoveTimer -= Time.deltaTime;
        if (enemyMoveTimer > 0)
        {
            result = true;
        }

        return result;
    }

    private void MoveFleet(Vector2 direction, float distance)
    {
        for(int i = 0; i < fleetList.Count; i++)
        {
            List<GameObject> column = fleetList[i];

            for (int j = 0; j < fleetList[i].Count; j++)
            {
               GameObject enemy = column[j];
                if (!enemy.activeInHierarchy)
                {
                    continue;
                }

                enemy.GetComponent<Enemy>().EnemyMove(direction, distance);
            }
        }
        enemyMoveTimer = stepDealay;
    }
}
