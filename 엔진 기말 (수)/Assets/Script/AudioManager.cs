using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class AudioManager : MonoBehaviour
{
    public AudioMixer audioMixer;     // 'Audio' 를 하나 만드세요!
    public Slider volumeSlider;

    public void SetVolume(float volume)
    {
        // Master는 AudioMixer의 그룹 이름
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
    }

}
