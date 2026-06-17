using UnityEngine;

public class GameUI : MonoBehaviour
{
    public GameObject startPanel;  // 여기에 StartPanel을 넣으세요
    public GameObject settingPanel; // 여기에 SettingPanel을 넣으세요

    void Start()
    {
        // 명확하게 시작 화면만 켜고, 설정 화면은 끄기
        if (startPanel != null) startPanel.SetActive(true);
        if (settingPanel != null) settingPanel.SetActive(false);

        Time.timeScale = 0f;
    }

    public void StartGame()
    {
        // 시작 화면만 끄고, 설정 화면은 건드리지 않음
        if (startPanel != null) startPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
