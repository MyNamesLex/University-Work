using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour
{
    public QuestionManager questionManager;
    public TimelineManager timelineManager;
    public Player player;


    public void ResetBoard()
    {
        foreach (GameObject g in questionManager.AnswerPieces)
        {
            g.GetComponent<BoardPiece>().Triggered = false;
        }

        foreach (GameObject g in questionManager.RowDividers)
        {
            g.gameObject.SetActive(true);
        }

        foreach (GameObject g in timelineManager.AllTimelines)
        {
            g.gameObject.SetActive(false);
        }
    }

    public void UpdateBoard()
    {
        switch (player.AnsweredCorrect)
        {
            case 0:
                foreach (GameObject g in questionManager.Row1)
                {
                    g.GetComponent<BoardPiece>().Triggered = true;
                }
                break;
            case 1:
                foreach (GameObject g in questionManager.Row2)
                {
                    g.GetComponent<BoardPiece>().Triggered = true;
                }
                break;
            case 2:
                foreach (GameObject g in questionManager.Row3)
                {
                    g.GetComponent<BoardPiece>().Triggered = true;
                }
                break;
            case 3:
                foreach (GameObject g in questionManager.Row4)
                {
                    g.GetComponent<BoardPiece>().Triggered = true;
                }
                break;
            case 4:
                foreach (GameObject g in questionManager.Row5)
                {
                    g.GetComponent<BoardPiece>().Triggered = true;
                }
                break;
            case 5:
                foreach (GameObject g in questionManager.Row6)
                {
                    g.GetComponent<BoardPiece>().Triggered = true;
                }
                break;
            case 6:
                foreach (GameObject g in questionManager.Row7)
                {
                    g.GetComponent<BoardPiece>().Triggered = true;
                }
                break;
            case 7:
                foreach (GameObject g in questionManager.Row8)
                {
                    g.GetComponent<BoardPiece>().Triggered = true;
                }
                break;
            case 8:
                foreach (GameObject g in questionManager.Row9)
                {
                    g.GetComponent<BoardPiece>().Triggered = true;
                }
                break;
            case 9:
                foreach (GameObject g in questionManager.Row10)
                {
                    g.GetComponent<BoardPiece>().Triggered = true;
                }
                break;
            case 10:
                foreach (GameObject g in questionManager.Row11)
                {
                    g.GetComponent<BoardPiece>().Triggered = true;
                }
                break;
        }
    }
}
