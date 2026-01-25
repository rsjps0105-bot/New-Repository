using UnityEngine;

public class NormalBall : MonoBehaviour, IThrowable
{
    [SerializeField] BallData originalData;
    BallData runtimeData;

    float lastThrowTime = -999f;

    void Awake()
    {
        // ★ プレイヤー専用コピー
        runtimeData = Instantiate(originalData);
    }

    bool CanThrow()
    {
        return Time.time >= lastThrowTime + runtimeData.coolTime;
    }

    public BallData RuntimeData => runtimeData;

    public void Throw(Vector3 startPosition, Vector3 direction)
    {
        if (!CanThrow()) return;

        const int MAX_SHOTS = 5;

        int totalShots = Mathf.Min(1 + runtimeData.extraHorizontalShots, MAX_SHOTS);
        int horizontalShots = totalShots - 1;

        for (int i = 0; i < totalShots; i++)
        {
            float angle = (i - runtimeData.extraHorizontalShots * 0.5f) * 10f;
            Vector3 dir = Quaternion.Euler(0, angle, 0) * direction;

            Rigidbody rb =
                Instantiate(runtimeData.ballPrefab, startPosition, Quaternion.identity);

            rb.linearVelocity = dir.normalized * runtimeData.baseSpeed;

            // 弾側にデータを渡す
            rb.GetComponent<BallProjectile>()
              ?.Initialize(runtimeData);
        }

        lastThrowTime = Time.time;
    }


}
