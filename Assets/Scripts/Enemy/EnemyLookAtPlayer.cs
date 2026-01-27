using UnityEngine;
using static UnityEngine.GraphicsBuffer;

// 敵の視点操作
public class EnemyLookAtPlayer : MonoBehaviour
{
    Transform player;   
    public Transform model;   
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    void LateUpdate()
    {
        if (player == null) return;

        Vector3 dir = player.position - model.position;
        dir.y = 0f; // ← 上下は無視（重要）

        if (dir.sqrMagnitude > 0.001f)
        {
            model.rotation = Quaternion.LookRotation(dir);
        }
    }
}
