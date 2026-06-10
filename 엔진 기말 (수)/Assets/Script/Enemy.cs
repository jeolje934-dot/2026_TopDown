using UnityEngine;

public class Enemy : MonoBehaviour
{
    



    void Start()
    {
        // 생성 되자마자 플레이어 태그를 찾아서 확인
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        
        if (playerObj != null)
        {
            // 플레이어에게 즉시 100 데미지 전달 ( 즉사 판정 )
            PlayerController PlayerControllerScript = playerObj.GetComponent<PlayerController>();
            if (PlayerControllerScript != null)
            {
                PlayerControllerScript.TakeDamge(100);
                Debug.Log("항아리에서 적이 뛰쳐나와 플레이어가 사망했습니다!");
            }

        }
        // 생성 후 바로 사라지게 하려면 아래 주석 해제 (즉사 판정만 하고 사라짐)
        // Destory(gameObject);

    }

    
    void Update()
    {
        
    }
}
