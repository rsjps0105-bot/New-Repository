using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class EnemyMove : MonoBehaviour
{
    [Header("移動設定")]
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] float changeInterval = 2f;
    [SerializeField] float moveRange = 3f;

    CharacterController controller;

    float timer;
    float moveDirection; // -1 or 1
    Vector3 startPosition;

    Animator anim;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
        startPosition = transform.position;

        // 初期方向をランダム
        moveDirection = Random.value < 0.5f ? -1f : 1f;
    }

    void Update()
    {
        timer += Time.deltaTime;

        // 一定時間ごとにランダムで方向変更
        if (timer >= changeInterval)
        {
            moveDirection = Random.value < 0.5f ? -1f : 1f;
            timer = 0f;
        }

        Vector3 move = Vector3.right * moveDirection * moveSpeed;
        controller.Move(move * Time.deltaTime);

        // 範囲制限
        float minX = startPosition.x - moveRange;
        float maxX = startPosition.x + moveRange;

        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        transform.position = pos;

        // 端に当たったら必ず内側に戻す
        if (pos.x <= minX || pos.x >= maxX)
        {
            moveDirection *= -1f;
        }

        float animSpeed = Mathf.Abs(moveDirection * moveSpeed);
        anim.SetFloat("MoveSpeed", animSpeed);
    }
}
