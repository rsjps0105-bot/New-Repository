using UnityEngine;

public class ThrownBall : MonoBehaviour
{
    [SerializeField] int damage = 1;
    bool hasHit = false;

    // コライダーを持つ相手にぶつかった時、相手の情報を取得
    void OnCollisionEnter(Collision col)
    {
        // タグによってメソッドから抜けるか判断
        if (
            !col.gameObject.CompareTag("Ground") &&
            !col.gameObject.CompareTag("Player") &&
            !col.gameObject.CompareTag("Enemy")
        ) return;

        // 多段ヒット防止
        if (hasHit) return; 
        hasHit = true;

        // ぶつかった相手が持つ Healthクラスを取得し hp に入れる
        Health hp = col.gameObject.GetComponent<Health>();
        if (hp != null)
        {
            // Healthクラスのメソッド呼び出し
            hp.TakeDamage(damage, DamageSource.Ball);
        }

        Destroy(gameObject, 1f); // 1フレーム後に消える
    }
}
