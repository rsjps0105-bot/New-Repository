using UnityEngine;

public class EnemyThrowEventRelay : MonoBehaviour
{
    EnemyThrow enemyThrow;

    void Awake()
    {
        enemyThrow = GetComponentInParent<EnemyThrow>();
    }

    public void OnThrowEvent()
    {
        enemyThrow?.OnThrowEvent();
    }
}
