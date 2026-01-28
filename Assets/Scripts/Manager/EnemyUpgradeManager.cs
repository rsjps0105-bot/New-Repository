using UnityEngine;
using System.Collections.Generic;

public class EnemyUpgradeManager : MonoBehaviour
{
    [Header("Enemy Target")]
    [SerializeField] EnemyNormalBall[] initialEnemies; // ‹ó‚Å‚àOK

    [Header("Upgrade Cards")]
    [SerializeField] UpgradeCard[] upgradeCards;

    public static EnemyUpgradeManager Instance;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void ApplyEnemyUpgrade(EnemyNormalBall enemy)
    {
        if (upgradeCards == null || upgradeCards.Length == 0) return;

        var card = upgradeCards[Random.Range(0, upgradeCards.Length)];
        enemy.AddUpgrade(card);
    }
}
