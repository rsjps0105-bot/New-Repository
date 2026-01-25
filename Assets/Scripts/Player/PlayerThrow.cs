using UnityEngine;

public class PlayerThrow : MonoBehaviour
{
    [Header("投げる用ボール")]
    [SerializeField] NormalBall ballPrefab; // Prefab に手元ボールや投げる用ボールをセット

    [Header("プレイヤーカメラと手の位置")]
    [SerializeField] Camera playerCamera;
    [SerializeField] Transform holdPoint;

    void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;

        Vector3 dir = playerCamera.transform.forward;

        // カメラが実際より少し上を見ている補正
        dir.y += 0.5f;   // ← ここを調整（0.1〜0.4くらい）

        dir.Normalize();

        ballPrefab.Throw(holdPoint.position, dir);
    }
}