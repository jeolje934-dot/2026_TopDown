using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject settingPanel;

    [Header("오디오 소스 연결")]
    public AudioSource bgmAudioSource;
    public AudioSource playerAudioSource;
    public AudioSource uiAudioSource;

    [Header("슬라이더 연결")]
    public Slider bgmSlider;
    public Slider playerSlider;
    public Slider uiSlider;

    void Start()
    {
        // 1. 게임 시작 시 저장된 볼륨값 불러오기 (없으면 기본값 1.0)
        bgmSlider.value = PlayerPrefs.GetFloat("BGMVolume", 1.0f);
        playerSlider.value = PlayerPrefs.GetFloat("PlayerVolume", 1.0f);
        uiSlider.value = PlayerPrefs.GetFloat("UIVolume", 1.0f);

        // 2. 슬라이더가 움직일 때마다 함수를 호출하도록 설정
        bgmSlider.onValueChanged.AddListener(SetBGMVolume);
        playerSlider.onValueChanged.AddListener(SetPlayerVolume);
        uiSlider.onValueChanged.AddListener(SetUIVolume);
    }

    // 3. 볼륨 조절 시 저장 기능 추가
    public void SetBGMVolume(float value)
    {
        if (bgmAudioSource != null) bgmAudioSource.volume = value;
        PlayerPrefs.SetFloat("BGMVolume", value);
    }

    public void SetPlayerVolume(float value)
    {
        if (playerAudioSource != null) playerAudioSource.volume = value;
        PlayerPrefs.SetFloat("PlayerVolume", value);
    }

    public void SetUIVolume(float value)
    {
        if (uiAudioSource != null) uiAudioSource.volume = value;
        PlayerPrefs.SetFloat("UIVolume", value);
    }

    // 기존 함수들...
    public void StartGame() { SceneManager.LoadScene("Room1"); }
    public void ToggleSettings() { settingPanel.SetActive(!settingPanel.activeSelf); }
    public void QuitGame() { Application.Quit(); }
}








