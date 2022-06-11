using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class BoardPiece : MonoBehaviour
{
    [Header("Toggle Objects")]
    public GameObject AnswerPrompt;
    public GameObject[] AnswerButtons;
    public GameObject LeftDivider;
    public GameObject RightDivider;
    public GameObject MidDivider;
    public bool Triggered;
    public bool TriggeredOnce;

    [Header("Player")]
    public Player player;
    public GameObject NewSpawn;

    [Header("Questions")]
    public bool LeftCorrect;
    public bool MidCorrect;
    public bool RightCorrect;
    public string QuestionString;
    public QuestionManager questionManager;

    [Header("Timeline")]
    public GameObject LeftTimeline;
    public GameObject RightTimeline;
    public GameObject MidTimeline;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && Triggered == false && player.InTimeline == false)
        {
            player.FreezePlayer();
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            Triggered = true;

            AnswerPrompt.GetComponentInChildren<QuestionsText>().QuestionString = QuestionString;

            // SET ISWRONG BOOLS ON ANSWER BUTTONS //
            AnswerButtonsOrganiser();

            // SHOW ANSWERPROMPT //
            AnswerPrompt.SetActive(true);
            AnswerPrompt.GetComponentInChildren<QuestionsText>().ShowQuestion();

            // PASS VARIABLES TO GIVENANSWER //
            PassVariablesToGivenAnswer();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            AnswerPrompt.SetActive(false);

            foreach (GameObject g in AnswerButtons)
            {
                //if question has been answered and player drives off the boardpiece objects
                if (g.GetComponent<GivenAnswer>().ChosenPiece.gameObject.activeInHierarchy == false ||
                    g.GetComponent<GivenAnswer>().LeftDivider.gameObject.activeInHierarchy == false
                    || g.GetComponent<GivenAnswer>().RightDivider.gameObject.activeInHierarchy == false
                    || g.GetComponent<GivenAnswer>().MidDivider.gameObject.activeInHierarchy == false)
                {
                    Triggered = true;
                }
                else //if question has NOT been answered and player drives off the boardpiece objects
                {
                    Triggered = false;
                }
            }
        }
    }

    // GENERATE QUESTION AND CHECK QUESTION IS NOT GENERATED FOR ANOTHER BOARDPIECE //

    public void MidQuestion()
    {
        TriggeredOnce = true;
        int rng = Random.Range(0, questionManager.MidCorrectPieces.Count);
        QuestionString = questionManager.MidCorrect[rng];
    }

    public void LeftQuestion()
    {
        TriggeredOnce = true;
        int rng = Random.Range(0, questionManager.LeftCorrectPieces.Count);
        QuestionString = questionManager.LeftCorrect[rng];
    }

    public void RightQuestion()
    {
        TriggeredOnce = true;
        int rng = Random.Range(0, questionManager.RightCorrectPieces.Count);
        QuestionString = questionManager.RightCorrect[rng];
    }

    // ANSWERBUTTONS RIGHT WRONG //

    public void AnswerButtonsOrganiser()
    {
        if (RightCorrect)
        {
            foreach (GameObject g in AnswerButtons)
            {
                g.GetComponent<GivenAnswer>().isLeftWrong = true;
                g.GetComponent<GivenAnswer>().isRightWrong = false;
                g.GetComponent<GivenAnswer>().isMidWrong = true;
            }
        }
        if (MidCorrect)
        {
            foreach (GameObject g in AnswerButtons)
            {
                g.GetComponent<GivenAnswer>().isLeftWrong = true;
                g.GetComponent<GivenAnswer>().isRightWrong = true;
                g.GetComponent<GivenAnswer>().isMidWrong = false;
            }
        }
        if (LeftCorrect)
        {
            foreach (GameObject g in AnswerButtons)
            {
                g.GetComponent<GivenAnswer>().isLeftWrong = false;
                g.GetComponent<GivenAnswer>().isRightWrong = true;
                g.GetComponent<GivenAnswer>().isMidWrong = true;
            }
        }
    }

    // TRANSFER VARIABLES TO GIVENANSWER //

    public void PassVariablesToGivenAnswer()
    {

        foreach (GameObject g in AnswerButtons)
        {
            g.GetComponent<GivenAnswer>().ChosenPiece = gameObject;

            g.GetComponent<GivenAnswer>().LeftDivider = LeftDivider;
            g.GetComponent<GivenAnswer>().RightDivider = RightDivider;
            g.GetComponent<GivenAnswer>().MidDivider = MidDivider;

            g.GetComponent<GivenAnswer>().LeftTimeline = LeftTimeline;
            g.GetComponent<GivenAnswer>().MidTimeline = MidTimeline;
            g.GetComponent<GivenAnswer>().RightTimeline = RightTimeline;

            g.GetComponent<GivenAnswer>().NewSpawn = NewSpawn;
        }
    }
}
