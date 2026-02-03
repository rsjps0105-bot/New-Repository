using UnityEngine;

public class GameStartGate : MonoBehaviour
{
    [SerializeField] GameObject howToPanel;

    void Start()
    {
        // シーン1に入ったらまず説明表示＆停止
        howToPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    void Update()
    {
        if (howToPanel.activeSelf && Input.GetKeyDown(KeyCode.Space))
        {
            howToPanel.SetActive(false);
            Time.timeScale = 1f; // ゲーム開始
        }
    }
}
