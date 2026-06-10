using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 9.0f;  //이동 속도
    private Rigidbody2D rb;
    private Vector2 movement;

    public int hp = 100;  // 플레이어 hp 100
    public bool hasBranch = false; // 나뭇가지 소지 여부

    public void TakeDamge(int amout)
    {
        hp -= amout;
        Debug.Log("플레이어 체력: " + hp);
        if (hp <= 0)
            Debug.Log("플레이어 사밍");

    }
    // 나뭇가지를 획득했을 때 호출할 함수
    public void EquipBranch()
    {
        hasBranch = true;
        Debug.Log("나뭇가지를 장착했습니다!");
    }


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    
    void Update()
    {
        //입력 감지
        movement.x = 0;
        movement.y = 0;


        if (Input.GetKey(KeyCode.W)) movement.y = 1;      // 위
        if (Input.GetKey(KeyCode.S)) movement.y = -1;     // 아래
        if (Input.GetKey(KeyCode.A)) movement.x = -1;     // 왼쪽
        if (Input.GetKey(KeyCode.D)) movement.x = 1;      // 오른쪽 

        //  대각선 이동시 속도가 빨라지는 것 방지 (정규화)
        movement = movement.normalized;
 
    }

    private void FixedUpdate()
    {
        //물리 엔진을 통한 이동
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
