using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBoxData", menuName = "Data/BoxData")]

[System.Serializable]
public class BoxSaveData
{
    public float x, y; // 상자 위치
}

[System.Serializable]
public class RoomSaveData
{
    public List<BoxSaveData> boxes = new List<BoxSaveData>();
}

public class BoxData : ScriptableObject
{
    public GameObject boxPrefab; // 상자 프리팹
    public int spawnCount = 15;  // 방마다 생성할 상자 개수
}


