using UnityEngine;

public class BGMPlayer : MonoBehaviour
{
    public AudioClip bgmClip; // 배경음악 파일 넣는 곳

    void Start()
    {
        // 1. AudioSource 추가
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();

        // 2. 설정
        audioSource.clip = bgmClip;
        audioSource.loop = true; // 무한 반복
        audioSource.playOnAwake = true; // 시작 시 자동 재생

        // 3. 재생
        audioSource.Play();
    }
}

