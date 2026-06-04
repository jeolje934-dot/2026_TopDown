using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 9.0f;  //이동 속도
    private Rigidbody2D rb;
    private Vector2 movement;



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
