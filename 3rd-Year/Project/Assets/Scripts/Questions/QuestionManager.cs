using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    [Header("Selectables")]
    public List<GameObject> AnswerPieces;
    public List<GameObject> LeftCorrectPieces;
    public List<GameObject> MidCorrectPieces;
    public List<GameObject> RightCorrectPieces;
    public List<GameObject> Row1;
    public List<GameObject> Row2;
    public List<GameObject> Row3;
    public List<GameObject> Row4;
    public List<GameObject> Row5;
    public List<GameObject> Row6;
    public List<GameObject> Row7;
    public List<GameObject> Row8;
    public List<GameObject> Row9;
    public List<GameObject> Row10;
    public List<GameObject> Row11;

    [Header("Row Dividers")]
    public List<GameObject> RowDividers;

    [Header("Questions")]
    private bool StopDupe = false;
    public List<string> AllQuestions;
    public List<string> LeftCorrect;
    public List<string> MidCorrect;
    public List<string> RightCorrect;
    public int QuestionAmount; // for testing

    [Header("Duplicate Check Bool")]
    public bool LeftCorrectChecked = false;
    public bool MidCorrectChecked = false;
    public bool RightCorrectChecked = false;
    public bool RegenerateQuestionNeeded = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SortQuestions());
    }

    IEnumerator SortQuestions()
    {
        yield return new WaitForFixedUpdate();

        if(LeftCorrect.Count < QuestionAmount / 4 || MidCorrect.Count < QuestionAmount / 4 || RightCorrect.Count < QuestionAmount / 4)
        {
            Debug.Log("Check() + Starting SortQuestions");
            int rng = Random.Range(0, AllQuestions.Count);
            Check(rng, AllQuestions);
            StartCoroutine(SortQuestions());
        }
        else
        {
            Debug.Log("Stopping All Coroutines");
            if (StopDupe == false)
            {
                StopDupe = true;
                AddQuestionsToBoardPieces();
            }
            yield return null;
        }
    }

    // CHECK IF QUESTION IS A DUPLICATE ITEM //

    public void Check(int rng, List<string> Questions)
    {
        if (LeftCorrect.Count >= QuestionAmount / 4 && MidCorrect.Count >= QuestionAmount / 4 && RightCorrect.Count >= QuestionAmount / 4)
        {
            Debug.Log("All question lists are equal to AnswerPieces.Count");
            AddQuestionsToBoardPieces();
            return;
        }
        else
        {
            Debug.Log("QuestionLists are less than / not equal to QuestionAmount divided by 4, Adding Questions To Lists");

            //Get Current rng value to avoid SOME duplication
            int rngstill = rng;
            QuestionOrganiser(rngstill, Questions);
        }

        // AVOID DUPLICATE QUESTION STRINGS ADDED TO LISTS //

        if (LeftCorrect.Contains(Questions[rng]) && LeftCorrect.Count <= AnswerPieces.Count)
        {
            Debug.Log("Left Correct Contains");
            StartCoroutine(SortQuestions());
        }

        if (MidCorrect.Contains(Questions[rng]) && MidCorrect.Count <= AnswerPieces.Count)
        {
            Debug.Log("Mid Correct Contains");
            StartCoroutine(SortQuestions());
        }

        if (RightCorrect.Contains(Questions[rng]) && RightCorrect.Count <= AnswerPieces.Count)
        {
            Debug.Log("Right Correct Contains");
            StartCoroutine(SortQuestions());
        }
    }


    // ORGANISE INTO SEPERATE LISTS //

    public void QuestionOrganiser(int rng, List<string> Questions)
    {
        //Debug.Log(rng); // debug index out of range fix

        switch (Questions[rng])
        {
            // LEFT CORRECT //

            case "1":
                AddLeftCorrect(rng, Questions);
                break;

            case "2":
                AddLeftCorrect(rng, Questions);
                break;

            case "3":
                AddLeftCorrect(rng, Questions);
                break;

            case "4":
                AddLeftCorrect(rng, Questions);
                break;

            // MID CORRECT //

            case "5":
                AddMidCorrect(rng, Questions);
                break;

            case "6":
                AddMidCorrect(rng, Questions);
                break;

            case "7":
                AddMidCorrect(rng, Questions);
                break;

            case "8":
                AddMidCorrect(rng, Questions);
                break;

            // RIGHT CORRECT //

            case "9":
                AddRightCorrect(rng, Questions);
                break;

            case "10":
                AddRightCorrect(rng, Questions);
                break;

            case "11":
                AddRightCorrect(rng, Questions);
                break;

            case "12":
                AddRightCorrect(rng, Questions);
                break;

            default:
                Debug.LogError("Questions[rng] not found " + Questions[rng]);
                break;
        }
    }

    // ADD FUNCTIONS //

    public void AddLeftCorrect(int rng, List<string> Questions)
    {
        if (LeftCorrect.Contains(Questions[rng]))
        {
            StartCoroutine(SortQuestions());
        }
        else
        {
            LeftCorrect.Add(Questions[rng]);
            Debug.Log("Added LeftCorrect item");
        }
    }

    public void AddMidCorrect(int rng, List<string> Questions)
    {
        if (MidCorrect.Contains(Questions[rng]))
        {
            StartCoroutine(SortQuestions());
        }
        else
        {
            MidCorrect.Add(Questions[rng]);
            Debug.Log("Added MidCorrect item");
        }
    }

    public void AddRightCorrect(int rng, List<string> Questions)
    {
        if (RightCorrect.Contains(Questions[rng]))
        {
            StartCoroutine(SortQuestions());
        }
        else
        {
            RightCorrect.Add(Questions[rng]);
            Debug.Log("Added RightCorrect item");
        }
    }

    // ADD QUESTIONS TO BOARDPIECES //

    public void AddQuestionsToBoardPieces()
    {
        Debug.Log("AddQuestionsToBoardPieces() start");

        for (int i = 0; i < AnswerPieces.Count; i++)
        {
            if (AnswerPieces[i].GetComponent<BoardPiece>().RightCorrect)
            {
                if (RightCorrectPieces.Contains(AnswerPieces[i]) == false)
                {
                    RightCorrectPieces.Add(AnswerPieces[i]);
                }

                AnswerPieces[i].GetComponent<BoardPiece>().RightQuestion();
                Debug.Log("Added RightQuestion to " + AnswerPieces[i].name);
            }
            if (AnswerPieces[i].GetComponent<BoardPiece>().MidCorrect)
            {
                if (MidCorrectPieces.Contains(AnswerPieces[i]) == false)
                {
                    MidCorrectPieces.Add(AnswerPieces[i]);
                }

                AnswerPieces[i].GetComponent<BoardPiece>().MidQuestion();
                Debug.Log("Added MidQuestion to " + AnswerPieces[i].name);
            }
            if (AnswerPieces[i].GetComponent<BoardPiece>().LeftCorrect)
            {
                if (LeftCorrectPieces.Contains(AnswerPieces[i]) == false)
                {
                    LeftCorrectPieces.Add(AnswerPieces[i]);
                }

                AnswerPieces[i].GetComponent<BoardPiece>().LeftQuestion();
                Debug.Log("Added LeftQuestion to " + AnswerPieces[i].name);
            }
        }
        CheckForDuplicateQuestionStringsOnBoardPieces();
    }

    // CHECK FOR DUPLICATE QUESTION STRINGS ON BOARD PIECES //

    public void CheckForDuplicateQuestionStringsOnBoardPieces()
    {
        foreach (GameObject g in AnswerPieces)
        {
            int index = AnswerPieces.IndexOf(g);
            int indexplusone = index + 1;

            if (indexplusone >= AnswerPieces.Count)
            {
                Debug.Log("No Duplicate Strings Found On Board Pieces!");
                return;
            }
            else
            {
                Debug.Log("Checking Question String Found On " + AnswerPieces[index].name + " and " + AnswerPieces[indexplusone].name);

                if (AnswerPieces[index].GetComponent<BoardPiece>().QuestionString == AnswerPieces[indexplusone].GetComponent<BoardPiece>().QuestionString)
                {
                    Debug.LogError("Duplicate Question String Found On " + AnswerPieces[index].name + " and " + AnswerPieces[indexplusone].name);
                    Debug.LogError("Recursion calling AddQuestionsToBoardPieces() from CheckForDuplicateQuestionStringsOnBoardPieces()");
                    AddQuestionsToBoardPieces();
                }
            }
        }
    }
}
