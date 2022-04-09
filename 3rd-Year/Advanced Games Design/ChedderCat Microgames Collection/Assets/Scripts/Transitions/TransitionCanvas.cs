using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class TransitionCanvas : MonoBehaviour
{
    public Animator anim;
    public float TimeUntilShow;
    public float TimeUntilHide;
    public float StartImageOnScreenDuration;
    [Header("Values")]
    public MinigameHandler handler;
    public MinigameAction action;
    public int Points;
    public string sceneName;
    public bool isFreeplay;
    public bool PointsSet = false;
    [Header("Display Values")]
    public TextMeshProUGUI PointsText;
    public TextMeshProUGUI LivesText;
    public TextMeshProUGUI WonLostText;
    public Image StartImage;
    public Image EndImage;
    public Image Battery1;
    public Image Battery2;
    public Image Battery3;

    public void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
        StartCoroutine(DelayedStart());
    }

    public void SetValues()
    {
        string load = File.ReadAllText(Application.dataPath + sceneName + ".sussy");
        MinigameAction.minigameData loaded = JsonUtility.FromJson<MinigameAction.minigameData>(load);

        if (PointsSet == false)
        {
            PointsSet = true;
            Points = handler.points + Points;
        }
        if (isFreeplay == true)
        {
            if (loaded.FreeplayScore < Points)
            {
                loaded.FreeplayScore = Points;
            }
        }
        else
        {
            if (loaded.gameScore < Points)
            {
                loaded.gameScore = Points;
            }
        }
        DisplayLives();
        SetText();
    }

    IEnumerator DelayedStart() // Delay start
    {
        while(true)
        {
            Time.timeScale = 0;
            yield return new WaitForSecondsRealtime(StartImageOnScreenDuration);
            StartImage.gameObject.SetActive(false);
            Time.timeScale = 1;
            yield break;
        }
    }

    private void SetText()
    {
        PointsText.text = "Points: " + Points;
        LivesText.text = "Lives: " + handler.lives;
    }
    public void DisplayLives()
    {
        switch (handler.lives)
        {
            case 1:
                Battery1.gameObject.SetActive(true);
                Battery2.gameObject.SetActive(false);
                Battery3.gameObject.SetActive(false);
                break;
            case 2:
                Battery1.gameObject.SetActive(true);
                Battery2.gameObject.SetActive(true);
                Battery3.gameObject.SetActive(false);
                break;
            case 3:
                Battery1.gameObject.SetActive(true);
                Battery2.gameObject.SetActive(true);
                Battery3.gameObject.SetActive(true);
                break;
        }
    }


    public void ShowTransition()
    {
        StartCoroutine(TimerShow());
    }

    public void HideTransition()
    {
        StartCoroutine(TimerHide());
    }

    IEnumerator TimerShow() // End Screen
    {
        //EndImage.gameObject.SetActive(true);
        yield return new WaitForSeconds(TimeUntilShow);
        anim.SetBool("Show", true);
        yield return new WaitForSeconds(.5f);
      //  EndImage.gameObject.SetActive(false);
        HideTransition();
        yield break;
    }

    IEnumerator TimerHide()  // Start Screen
    {
        while(true)
        {
            yield return new WaitForSeconds(TimeUntilHide);
            anim.SetBool("Show", false);
            yield break;
        }
    }
}
