using UnityEngine;

[CreateAssetMenu(menuName = "Ball/BallData")]
public class BallData : ScriptableObject
{
    [Header("Params")]
    public float baseSpeed = 10f;
    public float gravityScale = 1f;
    public float throwUp = 0.5f;

    [Header("Limits")]
    public float minSpeed = 3f;
    public float maxSpeed = 30f;

    public float minCoolTime = 0.3f;
    public float maxCoolTime = 3f;

    [Header("Advanced")]
    public int extraHorizontalShots = 0;
    public float homingStrength = 0f;
    public float coolTime = 1.5f;

    [Header("Prefab")]
    public Rigidbody ballPrefab;

    // ‹­‰»‚ðŽó‚¯Žæ‚é
    public void ApplyUpgrade(UpgradeCard card)
    {
        switch (card.type)
        {
            case UpgradeType.SpeedUp:
                baseSpeed *= card.value;
                baseSpeed = Mathf.Clamp(baseSpeed, minSpeed, maxSpeed);
                break;

            case UpgradeType.ExtraHorizontalShot:
                extraHorizontalShots += Mathf.RoundToInt(card.value);
                break;

            case UpgradeType.Homing:
                homingStrength += card.value;
                break;

            case UpgradeType.CoolTimeDown:
                coolTime -= card.value;
                coolTime = Mathf.Clamp(coolTime, minCoolTime, maxCoolTime);
                break;
        }
    }
}
