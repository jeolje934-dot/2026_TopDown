using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f; // 최대 체력
    public float currentHealth;    // 현재 체력

    void Start()
    {
        currentHealth = maxHealth;
    }

    // 데미지를 입는 함수 (다른 스크립트에서 호출함)
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        Debug.Log(gameObject.name + " 남은 체력: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log(gameObject.name + " 사망!");
        Destroy(gameObject); // 일단 삭제로 처리
    }
}



