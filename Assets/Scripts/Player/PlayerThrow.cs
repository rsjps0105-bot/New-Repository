using UnityEngine;

public class PlayerThrow : MonoBehaviour
{
    [Header("投げる用ボール")]
    [SerializeField] MonoBehaviour ballBehaviour;
    IThrowable ball;

    void Awake()
    {
        ball = ballBehaviour as IThrowable;
    }

    [Header("プレイヤーカメラと手の位置")]
    [SerializeField] Camera playerCamera;
    [SerializeField] Transform holdPoint;

    void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;

        Vector3 dir = playerCamera.transform.forward;

        // 投げる高さを調整
        dir.y += 0.5f;  

        dir.Normalize();

        ball.Throw(holdPoint.position, dir);
    }
}