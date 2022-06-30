using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestionsText : MonoBehaviour
{
    [Header("Title")]
    public TextMeshProUGUI TitleText;

    [Header("Questions")]
    public Board board;
    public string QuestionString;
    public Button Question1ButtonText;
    public Button Question2ButtonText;
    public Button Question3ButtonText;

    public void ShowQuestion() // questions sourced from https://www.gov.uk/guidance/the-highway-code and https://www.highwaycodeuk.co.uk/answers
    {
        board.UpdateBoard();
        switch (QuestionString)
        {

            // LEFT CORRECT //

            case "1":
                TitleText.text = "You are a pedestrian, if there is no pavement, where must you walk?";
                /////////////////////////////////

                Question1ButtonText.GetComponentInChildren<TextMeshProUGUI>().text = "Right-hand side of the road";
                //Correct
                //////////////////////////////////

                Question2ButtonText.GetComponentInChildren<TextMeshProUGUI>().text = "Left-hand side of the road";

                /////////////////////////////////

                Question3ButtonText.GetComponentInChildren<TextMeshProUGUI>().text  = "Middle of the road";

                /////////////////////////////////
                break;

            case "2":
                TitleText.text = "What should you do to your vehicle in hot weather?";
                /////////////////////////////////

                Question1ButtonText.GetComponentInChildren<TextMeshProUGUI>().text = "Well ventilated to avoid drowsiness";
                //Correct
                //////////////////////////////////

                Question2ButtonText.GetComponentInChildren<TextMeshProUGUI>().text = "Check your mirrors";

                /////////////////////////////////

                Question3ButtonText.GetComponentInChildren<TextMeshProUGUI>().text = "Check your rear window";

                /////////////////////////////////
                break;

            case "3":
                TitleText.text = "Before moving off in a car, which of these should you do?";
                /////////////////////////////////

                Question1ButtonText.GetComponentInChildren<TextMeshProUGUI>().text = "Use all mirrors to check if the road is clear";
                //Correct
                //////////////////////////////////

                Question2ButtonText.GetComponentInChildren<TextMeshProUGUI>().text = "Check your phone";

                /////////////////////////////////

                Question3ButtonText.GetComponentInChildren<TextMeshProUGUI>().text = "Drive off immediatly";

                /////////////////////////////////
                break;

            case "4":
                TitleText.text = "When can you drive with a dog in the car?";
                /////////////////////////////////

                Question1ButtonText.GetComponentInChildren<TextMeshProUGUI>().text = "If the dog is suitably restrained";
                //Correct
                //////////////////////////////////

                Question2ButtonText.GetComponentInChildren<TextMeshProUGUI>().text = "Always";

                /////////////////////////////////

                Question3ButtonText.GetComponentInChildren<TextMeshProUGUI>().text = "If they are in the backseat";

                /////////////////////////////////
                break;

            // MID CORRECT //

            case "5":
                TitleText.text = "Which of the following must you NOT do when overtaking?";
                /////////////////////////////////

                Question1ButtonText.GetComponentInChildren<TextMeshProUGUI>().text = "Check your mirrors";

                /////////////////////////////////

                Question2ButtonText.GetComponentInChildren<TextMeshProUGUI>().text = "Weave in and out of lanes to overtake";
                //Correct
                /////////////////////////////////

                Question3ButtonText.GetComponentInChildren<TextMeshProUGUI>().text = "Take time to judge the speeds correctly";

                /////////////////////////////////
                break;

            case "6":
                TitleText.text = "In wet weather, what stopping distance is required?";
                /////////////////////////////////

                Question1ButtonText.GetComponentInChildren<TextMeshProUGUI>().text = "Typical stopping distance";

                /////////////////////////////////

                Question2ButtonText.GetComponentInChildren<TextMeshProUGUI>().text = "Double the typical stopping distance";
                //Correct
                /////////////////////////////////

                Question3ButtonText.GetComponentInChildren<TextMeshProUGUI>().text = "Triple the typical stopping distance";

                /////////////////////////////////
                break;

            case "7":
                TitleText.text = "On approaching a roundabout, which of these should you NOT do";
                /////////////////////////////////

                Question1ButtonText.GetComponentInChildren<TextMeshProUGUI>().text = "Decide as early as possible which exit you need to take";

                /////////////////////////////////

                Question2ButtonText.GetComponentInChildren<TextMeshProUGUI>().text = "Rush into the correct lane to ensure you get into it before it is too late";

                //Correct
                /////////////////////////////////

                Question3ButtonText.GetComponentInChildren<TextMeshProUGUI>().text = "Adjust your speed and position to fit in with traffic conditions";

                /////////////////////////////////
                break;

            case "8":
                TitleText.text = "What information must you give to anyone with a 'reasonable grounds for requiring them' when in an accident in your vehicle?";
                /////////////////////////////////

                Question1ButtonText.GetComponentInChildren<TextMeshProUGUI>().text = "Your name";

                /////////////////////////////////

                Question2ButtonText.GetComponentInChildren<TextMeshProUGUI>().text = "Your name, address and vehicle registration number";

                //Correct
                /////////////////////////////////

                Question3ButtonText.GetComponentInChildren<TextMeshProUGUI>().text = "Your vehicle registration number and address";

                /////////////////////////////////
                break;


            // RIGHT CORRECT //

            case "9":
                TitleText.text = "When reversing, which one of the following must you NOT do";
                /////////////////////////////////

                Question1ButtonText.GetComponentInChildren<TextMeshProUGUI>().text = "Check your blind spot";

                /////////////////////////////////

                Question2ButtonText.GetComponentInChildren<TextMeshProUGUI>().text = "Use your mirrors";

                /////////////////////////////////

                Question3ButtonText.GetComponentInChildren<TextMeshProUGUI>().text = "Reverse from a side road into a main road";
                //Correct
                /////////////////////////////////
                break;

            case "10":
                TitleText.text = "What must you NOT do when overtaking";
                /////////////////////////////////

                Question1ButtonText.GetComponentInChildren<TextMeshProUGUI>().text = "Check the road is clear";

                /////////////////////////////////

                Question2ButtonText.GetComponentInChildren<TextMeshProUGUI>().text = "Road users are not beginning to overtake you";

                /////////////////////////////////

                Question3ButtonText.GetComponentInChildren<TextMeshProUGUI>().text = "Overtaking when approaching a corner or bend";
                //Correct
                /////////////////////////////////
                break;

            case "11":
                TitleText.text = "When is the only time listed here where you can use the hard shoulder";
                /////////////////////////////////

                Question1ButtonText.GetComponentInChildren<TextMeshProUGUI>().text = "If you need a break";

                /////////////////////////////////

                Question2ButtonText.GetComponentInChildren<TextMeshProUGUI>().text = "To answer the phone";

                /////////////////////////////////

                Question3ButtonText.GetComponentInChildren<TextMeshProUGUI>().text = "Directed to do so by the police, traffic officer or a traffic sign";
                //Correct
                /////////////////////////////////
                break;

            case "12":
                TitleText.text = "What is the minimum tread of depth for your car tyres?";
                /////////////////////////////////

                Question1ButtonText.GetComponentInChildren<TextMeshProUGUI>().text = "1.8mm";

                /////////////////////////////////

                Question2ButtonText.GetComponentInChildren<TextMeshProUGUI>().text = "1.7mm";

                /////////////////////////////////

                Question3ButtonText.GetComponentInChildren<TextMeshProUGUI>().text = "1.6mm";
                //Correct
                /////////////////////////////////
                break;


            // DEFAULT ERROR CATCH //

            default:
                TitleText.text = "Question string not found, default reached";
                /////////////////////////////////

                Question1ButtonText.GetComponentInChildren<TextMeshProUGUI>().text = "null";

                /////////////////////////////////

                Question2ButtonText.GetComponentInChildren<TextMeshProUGUI>().text = "null";

                /////////////////////////////////

                Question3ButtonText.GetComponentInChildren<TextMeshProUGUI>().text = "null";

                /////////////////////////////////
                break;
        }

    }
}
