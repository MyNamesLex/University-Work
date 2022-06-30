using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GivenAnswer : MonoBehaviour
{
    [Header("Toggle Objects")]
    public GameObject AnswerPrompt;

    [Header("Path")]
    public GameObject ChosenPiece;
    public GameObject[] LastRow;

    [Header("Player")]
    public Player player;
    public bool isLeft;
    public bool isRight;
    public bool isMid;

    public bool isLeftWrong;
    public bool isRightWrong;
    public bool isMidWrong;

    [Header("Board")]
    public Board board;
    public QuestionManager questionManager;
    public TimelineManager timelineManager;

    [Header("Spawns")]
    public GameObject Spawn;
    public GameObject NewSpawn;

    [Header("Info To Player")]
    public CorrectIncorrect ci;

    [Header("Divider")]
    public GameObject LeftDivider;
    public GameObject RightDivider;
    public GameObject MidDivider;

    [Header("Timeline")]
    public GameObject LeftTimeline;
    public GameObject RightTimeline;
    public GameObject MidTimeline;
    public void OnClick(GameObject g)
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // ENABLE MOVEMENT //
        player.FreezePlayer();


        // REMOVE DIVIDER //

        if (isMid && isMidWrong == false)
        {
            Spawn.transform.position = NewSpawn.transform.position;
            Spawn.transform.rotation = NewSpawn.transform.rotation;
            RemoveDivider(MidDivider);
        }

        if (isLeft && isLeftWrong == false)
        {
            Spawn.transform.position = NewSpawn.transform.position;
            Spawn.transform.rotation = NewSpawn.transform.rotation;
            RemoveDivider(LeftDivider);
        }

        if (isRight && isRightWrong == false)
        {
            Spawn.transform.position = NewSpawn.transform.position;
            Spawn.transform.rotation = NewSpawn.transform.rotation;
            RemoveDivider(RightDivider);
        }

        // TIMELINE PLAYS //

        if(isMidWrong && g.name == "Answer2Button")
        {
            MidTimeline.SetActive(true);
            MidTimeline.GetComponent<TimelineScript>().StartTimeline();
        }

        if(isLeftWrong && g.name == "Answer1Button")
        {
            LeftTimeline.SetActive(true);
            LeftTimeline.GetComponent<TimelineScript>().StartTimeline();
        }

        if(isRightWrong && g.name == "Answer3Button")
        {
            RightTimeline.SetActive(true);
            RightTimeline.GetComponent<TimelineScript>().StartTimeline();
        }

        // COMPLETED CHECK //

        if (IsCompleted())
        {
          //  ci.EditText("Won!");
        }

        // DEBUG HELP //

        if(isRight == false && isLeft == false && isMid == false)
        {
            Debug.LogError("IsRight, IsLeft and IsMid is all false on GivenAnswer");
        }

        // DISABLE ANSWERPROMPT //

        AnswerPrompt.SetActive(false);
    }

    public bool IsCompleted()
    {
        foreach (GameObject g in LastRow)
        {
            if (g == ChosenPiece && isNoTimelineActive())
            {
                return true;
            }
        }
        return false;
    }

    public bool isNoTimelineActive()
    {
        foreach (GameObject g in timelineManager.AllTimelines)
        {
            if (g.activeInHierarchy == true)
            {
                return false;
            }
        }
        return true;
    }

    public void RemoveDivider(GameObject divider)
    {
        if(divider == null)
        {
            player.GetComponent<Player>().ga.ci.EditText("Wrong Answer");
        }
        else if(divider != null)
        {
            divider.SetActive(false);
        }
    }
}
