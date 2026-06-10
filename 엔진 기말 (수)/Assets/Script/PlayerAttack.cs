using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public PlayerController player; // PlayerController 스크립트 연결

    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))  // Space 누를 시 공격한다
        {
            Attack();
        }
    }

    void Attack()
    {
        // 공격 범위 내의 오브젝트 탐지  
        Collider2D[] hitObjects = Physics2D.OverlapCircleAll(transform.position, 1.0f);

        foreach (Collider2D hit in hitObjects )
        {
            if (hit.CompareTag("Pot"))
            {
                Pot pot = hit.GetComponent<Pot>();
                if (pot != null)
                {
                    // 1. 나뭇가지가 없을 때: 항아리 데미지 + 플레이어 체력 -100
                    if (!player.hasBranch)
                    {
                        pot.TakeDamge();
                        player.TakeDamge(100);  // 플레이어 100 데미지 받음 (즉사)
                        Debug.Log("맨손으로 때려서 죽었습니다!");
                    }

                    // 2.나뭇가지가 있을 때: 항아리 데미지만 줌
                    else
                    {
                        pot.TakeDamge();
                        Debug.Log("나뭇가지로 항아리를 쳤습니다");

                    }
                }
            }
        }
    }
}

