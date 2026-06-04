using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class PotManager : MonoBehaviour
{
    public GameObject potPrefab;
    public Tilemap groundTilemap;

    public int totalPots = 15;
    public int minPerRoom = 2;
    public int maxPerRoom = 6;
    public float minDistance = 1.2f;

    private List<Vector3> spawnedPositions = new List<Vector3>();
    private int[] potsInRoom = new int[4]; // 방별로 생성된 개수 추적

    void Start()
    {
        SpawnPots();
    }

    void SpawnPots()
    {
        BoundsInt bounds = groundTilemap.cellBounds;
        int totalSpawned = 0;

        // 1. [최소 2개 보장] 각 방에 강제로 2개씩 생성
        for (int room = 0; room < 4; room++)
        {
            for (int i = 0; i < minPerRoom; i++)
            {
                if (TrySpawnInRoom(room, bounds)) totalSpawned++;
            }
        }

        // 2. [나머지 채우기] 총 15개가 될 때까지 최대 6개 제한 지키며 생성
        int safetyCounter = 0;
        while (totalSpawned < totalPots && safetyCounter < 5000)
        {
            int room = Random.Range(0, 4);
            if (potsInRoom[room] < maxPerRoom) // 여기서 6개 제한 확실히 체크!
            {
                if (TrySpawnInRoom(room, bounds)) totalSpawned++;
            }
            safetyCounter++;
        }
    }

    bool TrySpawnInRoom(int roomIndex, BoundsInt bounds)
    {
        for (int i = 0; i < 50; i++) // 구역당 최대 50번 시도
        {
            // 4등분 구역 계산
            int xSize = bounds.size.x / 2;
            int ySize = bounds.size.y / 2;
            int xStart = bounds.xMin + ((roomIndex % 2 == 0) ? 0 : xSize);
            int yStart = bounds.yMin + ((roomIndex >= 2) ? 0 : ySize);

            int randomX = Random.Range(xStart, xStart + xSize);
            int randomY = Random.Range(yStart, yStart + ySize);
            Vector3Int cellPos = new Vector3Int(randomX, randomY, 0);

            if (groundTilemap.HasTile(cellPos))
            {
                Vector3 worldPos = groundTilemap.CellToWorld(cellPos) + new Vector3(0.5f, 0.5f, 0);

                // 겹침 체크
                bool isOverlapping = false;
                foreach (Vector3 pos in spawnedPositions)
                {
                    if (Vector3.Distance(worldPos, pos) < minDistance) { isOverlapping = true; break; }
                }

                if (!isOverlapping)
                {
                    Instantiate(potPrefab, worldPos, Quaternion.identity);
                    spawnedPositions.Add(worldPos);
                    potsInRoom[roomIndex]++; // 방별 카운트 증가
                    return true;
                }
            }
        }
        return false;
    }
}




