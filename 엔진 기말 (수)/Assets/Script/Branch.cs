using UnityEngine;

public class Branch : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().EquipBranch();
            Destroy(gameObject); // ³ª¹µ°¡Áö ¸ÔÀ¸¸é »ç¶óÁü 

        }
    }




    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}




