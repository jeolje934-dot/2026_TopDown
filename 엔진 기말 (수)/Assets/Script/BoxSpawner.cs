using UnityEngine;
using UnityEngine.Tilemaps;
using System.IO;
using System.Collections.Generic;

public class BoxSpawner : MonoBehaviour
{
    public BoxData boxData;   // BoxData 타입의 데이터 상자(변수)를 선언
    public Tilemap groundTilemap;

    void Start()
    {
        string filePath = Application.persistentDataPath + "/" + gameObject.scene.name + "_" + gameObject.name + ".json";   // 데이터가 저장될 전체 경로와 파일 이름을 만드는 코드

        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            RoomSaveData data = JsonUtility.FromJson<RoomSaveData>(json);
            foreach (var b in data.boxes)
            {
                Instantiate(boxData.boxPrefab, new Vector3(b.x, b.y, 0), Quaternion.identity, this.transform);
            }
        }
        else
        {
            SpawnAndSave(filePath);
        }
    }


    // 타일맵에서 랜덤한 위치 리스트를 가져오는 핵심 함수
    List<Vector3> GetRandomPositions()
    {
        List<Vector3> allPositions = new List<Vector3>();
        BoundsInt bounds = groundTilemap.cellBounds;

        for (int x = bounds.xMin; x < bounds.xMax; x++)
        {
            for (int y = bounds.yMin; y < bounds.yMax; y++)
            {
                Vector3Int localPlace = new Vector3Int(x, y, 0);
                if (groundTilemap.HasTile(localPlace))
                {
                    allPositions.Add(groundTilemap.CellToWorld(localPlace) + new Vector3(0.5f, 0.5f, 0));
                }
            }
        }

        // 셔플
        for (int i = 0; i < allPositions.Count; i++)
        {
            int randomIndex = Random.Range(i, allPositions.Count);
            Vector3 temp = allPositions[i];
            allPositions[i] = allPositions[randomIndex];
            allPositions[randomIndex] = temp;
        }

        // 15개만 리턴
        int count = Mathf.Min(boxData.spawnCount, allPositions.Count);
        return allPositions.GetRange(0, count);
    }

    void SpawnAndSave(string path)
    {
        List<Vector3> positions = GetRandomPositions();
        RoomSaveData data = new RoomSaveData();

        foreach (var pos in positions)
        {
            Instantiate(boxData.boxPrefab, pos, Quaternion.identity, this.transform);
            data.boxes.Add(new BoxSaveData { x = pos.x, y = pos.y });
        }

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(path, json);
    }
}



