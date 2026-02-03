using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] UpgradeManager upgradeManager;

    [Header("UI")]
    [SerializeField] Text killCountText;   //  常時表示用
    [SerializeField] GameObject ResultPanel;
    [SerializeField] TextMeshProUGUI resultText;
    [SerializeField] TextMeshProUGUI pressText;

    bool isGameEnd = false;
    int killCount = 0;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        Time.timeScale = 1f;

        resultText.gameObject.SetActive(false);
        pressText.gameObject.SetActive(false);

        killCount = 0;
        UpdateKillText();
    }

    void Update()
    {
        if (!isGameEnd) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GoTitle();
        }
    }

    public void GoTitle()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
            Destroy(player);

        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void OnCharacterDead(Health dead, DamageSource source)
    {
        if (isGameEnd) return;

        if (dead.CompareTag("Enemy") && source != DamageSource.Car)
        {
            killCount++;
            UpdateKillText();

            Debug.Log("Kill : " + killCount);

            // 例：3キルごとに強化
            if (killCount % 5 == 0)
            {
                upgradeManager?.ApplyRandomUpgrade();
            }
        }
        else if (dead.CompareTag("Player"))
        {
            EndGame();
        }
    }

    void EndGame()
    {
        isGameEnd = true;
        Time.timeScale = 0f;

        ResultPanel.SetActive(true);
        resultText.text = $"{killCount} enemies defeated";
        resultText.gameObject.SetActive(true);
        pressText.text = "Press to Title";
        pressText.gameObject.SetActive(true);
    }

    void UpdateKillText()
    {
        if (killCountText != null)
        {
            killCountText.text = $"KILL : {killCount}";
        }
    }
}
