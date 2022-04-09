using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StoryImages : MonoBehaviour
{
    [Header("Images")]
    public Image ImageShown;
    public List<Sprite> StoryImagesList;
    private int internalCounter;

    [Header("Wait's")]
    public float TimeOnScreen;
    public float TimeUntilShow;

    [Header("Bools")]
    public bool DontShow;

    [Header("Move To Next Minigame")]
    public MinigameAction action;
    // Start is called before the first frame update
    void Start()
    {
        if (DontShow == false)
        {
            StartStory();
        }
    }

    public void StartStory()
    {
        StartCoroutine(StaggerImages());
    }

    IEnumerator StaggerImages()
    {
        while(true)
        {
            if (DontShow == true)
            {
                Debug.Log("Manually Stopped by DontShow bool");
                yield break;
            }

            yield return new WaitForSeconds(TimeUntilShow);

            if (internalCounter >= StoryImagesList.Count)
            {
                action.WinMicrogame();

                Debug.Log("End of images, hop into microgame");
                yield break;
            }

            ImageShown.sprite = StoryImagesList[internalCounter];
            yield return new WaitForSeconds(TimeOnScreen);
            internalCounter++;
        }
    }
}
