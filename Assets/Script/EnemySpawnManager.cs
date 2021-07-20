using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static EnemySpawnManager Instance;
    public GameObject[] EnemyType;
    private int level = 0;
    List<GameObject> EnemyList = new List<GameObject>();
    WaitUntil waitUntilNoEnemy;
    Quaternion spawnRotation;
    float spawnPositionX = 2.5f;
    float spawnPositionY1 = 6.19f;
    float spawnPositionY2 = 12.28f;

    private void Awake() {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    void Start()
    {
        spawnRotation.eulerAngles = new Vector3(0, 0, 180);
        // waitUntilNoEnemy = new WaitUntil(NoEnemy);
        waitUntilNoEnemy = new WaitUntil(() => EnemyList.Count == 0);
        StartCoroutine("EnemySpawnLoop");
    }
    bool NoEnemy()
    {
        return EnemyList.Count == 0;
    }
    IEnumerator EnemySpawnLoop()
    {
        while(true)
        {
            yield return waitUntilNoEnemy;
            level++;
            var temp = level;
            Debug.Log(level);
            while(temp > 0)
            {
                var tempEnemyType = Random.Range(0, EnemyType.Length);
                while(temp - (tempEnemyType + 1) < 0)
                {
                    tempEnemyType = Random.Range(0, EnemyType.Length);
                }
                temp -= tempEnemyType + 1;
                SpawnEnemy(tempEnemyType);
            }
        }
    }
    void SpawnEnemy(int enemyType)
    {
            var spawnPosition = new Vector3(Random.Range(-spawnPositionX, spawnPositionX), Random.Range(spawnPositionY1, spawnPositionY2));
            EnemyList.Add(Instantiate(EnemyType[enemyType], spawnPosition, spawnRotation));
    }
    public void RemoveFromList(GameObject enemy) => EnemyList.Remove(enemy);
}
