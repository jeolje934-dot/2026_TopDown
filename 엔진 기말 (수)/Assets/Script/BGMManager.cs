using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public static BGMManager instance;
    public AudioSource audioSource;
    public AudioClip forestBGM; // 숲 맵 음악
    public AudioClip dungeonBGM; // 던전 맵 음악

    void Awake()
    {
        // 씬이 바뀌어도 이 오브젝트는 사라지지 않게 합니다.
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayBGM(string mapName)
    {
        if (mapName == "Forest") audioSource.clip = forestBGM;
        else if (mapName == "Dungeon") audioSource.clip = dungeonBGM;

        audioSource.loop = true; // 무한 반복
        audioSource.Play();
    }
}



