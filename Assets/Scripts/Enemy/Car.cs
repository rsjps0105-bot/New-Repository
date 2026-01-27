using UnityEngine;

public class Car : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }


    // プレイヤー、敵に当たった時ダメージ
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger hit: " + other.name);

        if (other.CompareTag("Player") || other.CompareTag("Enemy"))
        {
            Health health = other.GetComponentInParent<Health>();
            if (health != null)
            {
                health.TakeDamage(99, DamageSource.Car);
            }
        }
    }
}


