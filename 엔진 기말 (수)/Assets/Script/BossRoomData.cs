using UnityEngine;

[CreateAssetMenu(fileName = "BossRoomData", menuName = "Data/BossRoomData")]
public class BossRoomData : ScriptableObject
{
    public GameObject obstaclePrefab; // 돌 장벽 프리팹
    public int obstacleCount;         // 120개
}


