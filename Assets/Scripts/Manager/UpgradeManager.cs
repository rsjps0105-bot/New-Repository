using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] NormalBall normalBall;

    [Header("Upgrade Cards")]
    [SerializeField] UpgradeCard[] upgradeCards;

    [Header("UI")]
    [SerializeField] UpgradeSelectUI selectUI;

    public void ApplyRandomUpgrade()
    {
        if (upgradeCards.Length < 2) return;

        Time.timeScale = 0f;
        PauseManager.Instance.SetCursorForUI(true);

        UpgradeCard[] selected = GetRandomTwo();

        selectUI.Show(selected, OnUpgradeSelected);
    }

    void OnUpgradeSelected(UpgradeCard card)
    {
        BallData data = normalBall.RuntimeData;
        data.ApplyUpgrade(card);

        Debug.Log($"[Upgrade Selected] {card.title}");

        selectUI.Hide();
        PauseManager.Instance.SetCursorForUI(false);
        Time.timeScale = 1f;
    }

    UpgradeCard[] GetRandomTwo()
    {
        int a = Random.Range(0, upgradeCards.Length);
        int b;

        do
        {
            b = Random.Range(0, upgradeCards.Length);
        }
        while (b == a);

        return new UpgradeCard[]
        {
            upgradeCards[a],
            upgradeCards[b]
        };
    }
}