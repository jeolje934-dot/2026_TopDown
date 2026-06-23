using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // 적 프리팹
    public Transform player;       // 생성된 적에게 플레이어 정보 전달용
    public float spawnInterval = 3.0f; // 3초마다 생성

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }

    void SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        // 생성된 적에게 플레이어 위치 알려주기
        enemy.GetComponent<EnemyController>().player = player;
    }
}



