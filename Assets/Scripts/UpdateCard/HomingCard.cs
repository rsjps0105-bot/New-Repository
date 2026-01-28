using UnityEngine;

[CreateAssetMenu(menuName = "Upgrade/Cards/Homing")]
public class HomingCard : UpgradeCard
{
    public float addStrength = 0.2f;

    public override void Apply(BallData data)
    {
        data.homingStrength += addStrength;
        // •K—v‚È‚çãŒÀ‚à‚±‚±‚Å Clamp
        // data.homingStrength = Mathf.Clamp(data.homingStrength, 0f, 1f);
    }
}
