using UnityEngine;
using UnityEngine.SceneManagement;


public class Portal : MonoBehaviour
{

    [Header("이동 설정")]
    public string targetSceneName;   // 이동할 씬 이름

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 닿은 대상의 태그가 "Player"인지 확인
        if (collision.CompareTag("Player"))
        {
            // 씬 이름이 비어있지 않다면 이동을 실행
            if (!string.IsNullOrEmpty(targetSceneName))
            {
                SceneManager.LoadScene(targetSceneName);
            }
            else
            {
                Debug.LogWarning("이동할 씬 이름이 설정되지 않았습니다.");
            }
        }
    }
    void Start()
    {

    }


    void Update()
    {

    }
}


