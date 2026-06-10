using Unity.VisualScripting;
using UnityEngine;

public class Pot : MonoBehaviour
{
    public int health = 3;  // 항아리 체력
    public GameObject branchPrefab; // 나뭇가지 프리팹
    public GameObject enemyPrefab;  // 적 프리팹

    public void TakeDamge()
    {
        health--;
        if (health <= 0) BreakPot(); 
    }

    private void BreakPot()
    {
        float chance = Random.Range(0f, 100f);

        if (chance < 35f)  // 35%로 나뭇가지 드랍
        {
            if (branchPrefab != null) Instantiate(branchPrefab, transform.position, Quaternion.identity);
        }
        else if (chance < 72f) // 나머지 37%로 적 생성됨 
        {
            if (enemyPrefab != null) Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            {
                // 적 생성
                Instantiate(enemyPrefab, transform.position, Quaternion.identity);

            }
        }
        Destroy(gameObject); // 항아리를 파괴한다
    }


    void Start()
    {
        
    }

   
    void Update()
    {
        
    }
}
