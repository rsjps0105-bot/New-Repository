using UnityEngine;

[CreateAssetMenu(menuName = "Upgrade/Cards/SpeedUp")]
public class SpeedUpCard : UpgradeCard
{
    public float multiplier = 1.2f;

    public override void Apply(BallData data)
    {
        data.baseSpeed *= multiplier;
        data.baseSpeed = Mathf.Clamp(data.baseSpeed, data.minSpeed, data.maxSpeed);
    }
}
