using UnityEngine;

[CreateAssetMenu(menuName = "Upgrade/Cards/ExtraHorizontalShot")]
public class ExtraHorizontalShotCard : UpgradeCard
{
    public int addShots = 1;

    public override void Apply(BallData data)
    {
        data.extraHorizontalShots += addShots;
    }
}
