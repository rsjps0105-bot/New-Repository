using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public static PauseManager Instance;

    [SerializeField] GameObject pausePanel;

    bool isPaused = false;
    bool isUIControl = false; //  UpgradeなどUI表示中か

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        // UI操作中はカーソル制御しない
        if (!isPaused && !isUIControl && Input.GetMouseButtonDown(0))
        {
            LockCursor();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    void Pause()
    {
        isPaused = true;
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        UnlockCursor();
    }

    public void Resume()
    {
        isPaused = false;
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        LockCursor();
    }

    //  UpgradeManager から呼ぶ
    public void SetCursorForUI(bool enable)
    {
        isUIControl = enable;

        if (enable)
            UnlockCursor();
        else
            LockCursor();
    }

    void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void GoTitle()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
            Destroy(player);

        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
