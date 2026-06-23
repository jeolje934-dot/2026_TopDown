using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // --- 설정 값 ---
    public float moveSpeed = 9.0f;
    public LayerMask boxLayer; // 인스펙터에서 'Box' 레이어를 체크하세요!
    public AudioClip breakSound; // 효과음 파일 (인스펙터에서 드래그해서 넣으세요)

    // --- 변수 ---
    private Vector2 movement;
    private AudioSource audioSource;

    void Start()
    {
        // 1. 플레이어에 AudioSource 컴포넌트를 가져오거나 없으면 새로 추가합니다.
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        // 1. 이동 입력
        movement.x = 0;
        movement.y = 0;

        if (Input.GetKey(KeyCode.W)) movement.y = 1;
        if (Input.GetKey(KeyCode.S)) movement.y = -1;
        if (Input.GetKey(KeyCode.A)) movement.x = -1;
        if (Input.GetKey(KeyCode.D)) movement.x = 1;

        movement = movement.normalized;

        // 2. 공격 입력
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }

    void Attack()
    {
        Vector2 dir = movement == Vector2.zero ? Vector2.right : movement;

        // 플레이어 중심점에서 앞쪽으로 1.2f 거리만큼 레이저를 쏩니다.
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, 1.2f, boxLayer);

        // --- 디버그용 선 그리기 (빨간색) ---
        // Scene 창에서 빨간색 선이 상자에 닿는지 확인하세요!
        Debug.DrawRay(transform.position, dir * 1.2f, Color.red, 1.0f);

        if (hit.collider != null)
        {
            Debug.Log("상자 감지 성공: " + hit.collider.name);

            // 1. 파괴 전 효과음 재생
            if (audioSource != null && breakSound != null)
            {
                audioSource.PlayOneShot(breakSound);
            }

            // 2. 상자 파괴
            Destroy(hit.collider.gameObject);
        }
        else
        {
            Debug.Log("상자 감지 실패");
        }
    }

    void FixedUpdate()
    {
        // 이동 (Rigidbody2D를 안 쓰신다면 transform.position으로 직접 이동)
        transform.position += (Vector3)movement * moveSpeed * Time.fixedDeltaTime;
    }
}