using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusicHandler : MonoBehaviour
{

    [Header("AudioSource")]
    public AudioSource audioSource;

    [Header("Scene Background Music Set 1")]
    public AudioClip MainMenu;
    public AudioClip BossLevelJogging;
    public AudioClip BrushTeeth;
    public AudioClip CatchCoffee;
    public AudioClip DressGame;
    public AudioClip ZipGame;
    public AudioClip StirAndPour;
    public AudioClip StoryShow;
    // Start is called before the first frame update
    void Start()
    {
        SceneCheck(SceneManager.GetActiveScene().name);
    }

    private void OnLevelWasLoaded(int level)
    {
        SceneCheck(SceneManager.GetActiveScene().name);
    }
    public void SceneCheck(string level)
    {
        switch (level)
        {
            case "MainMenu":
                if (MainMenu != null)
                {
                    audioSource.clip = MainMenu;
                    audioSource.Play();
                }
                else
                {
                    Debug.LogWarning("MainMenu audioclip is null " + audioSource.clip.name + "is playing");
                }
                break;
            case "BrushTeeth":
                if (BrushTeeth != null)
                {
                    audioSource.clip = BrushTeeth;
                    audioSource.Play();
                }
                else
                {
                    Debug.LogWarning("BrushTeeth audioclip is null " + audioSource.clip.name + "is playing");
                }
                break;
            case "CatchCoffee":
                if (CatchCoffee != null)
                {
                    audioSource.clip = CatchCoffee;
                    audioSource.Play();
                }
                else
                {
                    Debug.LogWarning("CatchCoffee audioclip is null " + audioSource.clip.name + "is playing");
                }
                break;
            case "DressGame":
                if (DressGame != null)
                {
                    audioSource.clip = DressGame;
                    audioSource.Play();
                }
                else
                {
                    Debug.LogWarning("DressGame audioclip is null " + audioSource.clip.name + "is playing");
                }
                break;
            case "ZipGame":
                if (ZipGame != null)
                {
                    audioSource.clip = ZipGame;
                    audioSource.Play();
                }
                else
                {
                    Debug.LogWarning("ZipGame audioclip is null " + audioSource.clip.name + "is playing");
                }
                break;
            case "BossLevelJogging":
                if (BossLevelJogging != null)
                {
                    audioSource.clip = BossLevelJogging;
                    audioSource.Play();
                }
                else
                {
                    Debug.LogWarning("BossLevelJogging audioclip is null " + audioSource.clip.name + "is playing");
                }
                break;
            case "StoryShow":
                if (StoryShow != null)
                {
                    audioSource.clip = StoryShow;
                    audioSource.Play();
                }
                else
                {
                    Debug.LogWarning("StoryShow audioclip is null " + audioSource.clip.name + "is playing");
                }
                break;
            case "StirAndPour":
                if (StirAndPour != null)
                {
                    audioSource.clip = StirAndPour;
                    audioSource.Play();
                }
                else
                {
                    Debug.LogWarning("StirAndPur audioclip is null " + audioSource.clip.name + "is playing");
                }
                break;
        }
    }
}