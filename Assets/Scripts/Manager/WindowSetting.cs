using UnityEngine;

public class WindowSetting : MonoBehaviour
{
    void Awake()
    {
        // FPSを60に固定
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;

        // ウィンドウサイズ（画面の約1/4）
        Screen.SetResolution(1280, 720, false);
    }
}