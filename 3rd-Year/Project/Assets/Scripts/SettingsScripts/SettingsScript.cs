using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Audio;
public class SettingsScript : MonoBehaviour  //heavily edited from https://www.youtube.com/watch?v=YOaYQrN1oYQ
{
    [Header("Audio Mixers")]
    public AudioMixer MainAudioMixer;

    [Header("Fullscreen bool")]
    public bool FullScreenPublicBool;

    // Start is called before the first frame update
    void Start()
    {
        FullScreenToggle(FullScreenPublicBool);
    }

    public void ChangeQualityLevel(int value)
    {
        QualitySettings.SetQualityLevel(value, true);
    }

    public void FullScreenToggle(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        FullScreenPublicBool = isFullscreen;
    }

    public void MainVolumeChange(float volume)
    {
        MainAudioMixer.SetFloat("BackgroundAudio", volume);
    }
    public void SFXVolumeChange(float volume)
    {
        MainAudioMixer.SetFloat("SFXAudio", volume);
    }
}
