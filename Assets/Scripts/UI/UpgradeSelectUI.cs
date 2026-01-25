using UnityEngine;
using UnityEngine.UI;
using System;

public class UpgradeSelectUI : MonoBehaviour
{
    [SerializeField] Button[] buttons; // 2ŒÂ
    [SerializeField] Text[] titleTexts;

    UpgradeCard[] currentCards;
    Action<UpgradeCard> onSelected;

    public void Show(UpgradeCard[] cards, Action<UpgradeCard> onSelect)
    {
        gameObject.SetActive(true);

        currentCards = cards;
        onSelected = onSelect;

        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i;

            titleTexts[i].text = cards[i].title;

            buttons[i].onClick.RemoveAllListeners();
            buttons[i].onClick.AddListener(() =>
            {
                onSelected?.Invoke(currentCards[index]);
            });
        }
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
