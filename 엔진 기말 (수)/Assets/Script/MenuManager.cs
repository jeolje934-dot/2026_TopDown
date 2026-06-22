using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject settingPanel;

    [Header("오디오 소스 연결")]
    public AudioSource bgmAudioSource;      // 배경음악 스피커
    public AudioSource playerAudioSource;   // 플레이어 발소리 스피커
    public AudioSource uiAudioSource;       // UI 소리 스피커

    [Header("슬라이더 연결")]
    public Slider bgmSlider;
    public Slider playerSlider;
    public Slider uiSlider;

    // 1. 시작하기
    public void StartGame()
    {
        SceneManager.LoadScene("Room1");
    }

    // 2. 설정 창 열기/닫기
    public void ToggleSettings()
    {
        settingPanel.SetActive(!settingPanel.activeSelf);
    }

    // 3. 나가기
    public void QuitGame()
    {
        Application.Quit();
    }

    // 4. 슬라이더로 볼륨 조절 (여기가 핵심입니다!)
    public void SetBGMVolume(float value)
    {
        if (bgmAudioSource != null) bgmAudioSource.volume = value;
    }

    public void SetPlayerVolume(float value)
    {
        if (playerAudioSource != null) playerAudioSource.volume = value;
    }

    public void SetUIVolume(float value)
    {
        if (uiAudioSource != null) uiAudioSource.volume = value;
    }
}




