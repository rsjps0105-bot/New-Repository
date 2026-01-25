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

    //void ApplyEnemyUpgrade()
    //{
    //    if (upgradeCards == null || upgradeCards.Length == 0) return;

    //    UpgradeCard card = upgradeCards[Random.Range(0, upgradeCards.Length)];
    //    enemyAppliedUpgrades.Add(card);

    //    // Šù‚É‚¢‚é“G‚·‚×‚Ä‚É“K—p
    //    EnemyNormalBall[] enemies = FindObjectsOfType<EnemyNormalBall>();
    //    foreach (var enemy in enemies)
    //    {
    //        enemy.RuntimeData.ApplyUpgrade(card);
    //    }

    //    Debug.Log($"[Enemy Upgrade] {card.title}");
    //}

    // š Spawn ‚ÉŒÄ‚Ô
    //public void ApplyUpgradesToEnemy(EnemyNormalBall enemy)
    //{
    //    foreach (var card in enemyAppliedUpgrades)
    //    {
    //        enemy.RuntimeData.ApplyUpgrade(card);
    //    }
    //}
}
