using UnityEngine;

public class BallProjectile : MonoBehaviour
{
    BallData data;
    Transform target;

    public void Initialize(BallData data)
    {
        this.data = data;

        if (data.homingStrength > 0)
            target = FindNearestEnemy();
    }

    void FixedUpdate()
    {
        if (data == null || data.homingStrength <= 0 || target == null)
            return;

        Rigidbody rb = GetComponent<Rigidbody>();
        Vector3 currentVelocity = rb.linearVelocity;

        // ターゲット方向
        Vector3 dir = (target.position - transform.position).normalized;

        // 現在速度の大きさ
        float speed = currentVelocity.magnitude;

        // 方向を少し補正
        Vector3 newDir = Vector3.Lerp(currentVelocity.normalized, dir, data.homingStrength * 0.1f);

        rb.linearVelocity = newDir.normalized * speed;
    }

    Transform FindNearestEnemy()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        float minDist = float.MaxValue; // 無限距離に設定しておく
        Transform nearest = null;

        foreach (var e in enemies)
        {
            float d = Vector3.Distance(transform.position, e.transform.position);
            if (d < minDist)
            {
                minDist = d;
                nearest = e.transform;
            }
        }
        return nearest;
    }
}