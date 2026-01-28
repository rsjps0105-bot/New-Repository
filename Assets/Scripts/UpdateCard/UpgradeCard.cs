using UnityEngine;

public abstract class UpgradeCard : ScriptableObject
{
    public string title;
    [TextArea] public string description;

    // カード自身が強化処理を持つ
    public abstract void Apply(BallData data);
}
