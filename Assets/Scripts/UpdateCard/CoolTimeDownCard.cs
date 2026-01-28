using UnityEngine;

[CreateAssetMenu(menuName = "Upgrade/Cards/CoolTimeDown")]
public class CoolTimeDownCard : UpgradeCard
{
    public float amount = 0.2f;

    public override void Apply(BallData data)
    {
        data.coolTime -= amount;
        data.coolTime = Mathf.Clamp(data.coolTime, data.minCoolTime, data.maxCoolTime);
    }
}
