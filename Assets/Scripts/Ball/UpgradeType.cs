using UnityEngine;

public enum UpgradeType
{
    SpeedUp,            // 速度アップ
    ExtraHorizontalShot,// 水平方向に弾を1球追加
    Homing,             // 少しホーミング
    CoolTimeDown        // クールタイム短縮
}


[CreateAssetMenu(menuName = "Upgrade/BallUpgradeCard")]
public class UpgradeCard : ScriptableObject
{
    public string title;
    [TextArea] public string description;

    public UpgradeType type;
    public float value;
}

