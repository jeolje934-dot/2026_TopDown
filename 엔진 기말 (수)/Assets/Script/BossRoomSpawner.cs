using UnityEngine;
using UnityEngine.Tilemaps;
using System.IO;
using System.Collections.Generic;

public class BossRoomSpawner : MonoBehaviour
{
    public BossRoomData bossData; // 위에서 만든 보스룸 데이터 연결
    public Tilemap groundTilemap;

    void Start()
    {
        string filePath = Application.persistentDataPath + "/BossRoom_Obstacles.json";

        // 데이터 파일이 없으면 새로 생성하고 저장
        if (!File.Exists(filePath))
        {
            SpawnObstacles(filePath);
        }
        else
        {
            // 있으면 불러오기
            string json = File.ReadAllText(filePath);
            RoomSaveData data = JsonUtility.FromJson<RoomSaveData>(json);
            foreach (var b in data.boxes)
            {
                Instantiate(bossData.obstaclePrefab, new Vector3(b.x, b.y, 0), Quaternion.identity, this.transform);
            }
        }
    }

    void SpawnObstacles(string path)
    {
        List<Vector3> allPositions = new List<Vector3>();
        BoundsInt bounds = groundTilemap.cellBounds;

        for (int x = bounds.xMin; x < bounds.xMax; x++)
        {
            for (int y = bounds.yMin; y < bounds.yMax; y++)
            {
                if (groundTilemap.HasTile(new Vector3Int(x, y, 0)))
                    allPositions.Add(groundTilemap.CellToWorld(new Vector3Int(x, y, 0)) + new Vector3(0.5f, 0.5f, 0));
            }
        }

        // 셔플 후 120개 생성
        RoomSaveData data = new RoomSaveData();
        int count = Mathf.Min(bossData.obstacleCount, allPositions.Count);

        for (int i = 0; i < count; i++)
        {
            Vector3 pos = allPositions[Random.Range(0, allPositions.Count)];
            allPositions.Remove(pos); // 겹침 방지

            Instantiate(bossData.obstaclePrefab, pos, Quaternion.identity, this.transform);
            data.boxes.Add(new BoxSaveData { x = pos.x, y = pos.y });
        }

        File.WriteAllText(path, JsonUtility.ToJson(data));
    }
}


