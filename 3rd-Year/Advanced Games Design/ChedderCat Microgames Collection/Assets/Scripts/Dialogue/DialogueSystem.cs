using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    [Header("Dialogue")]
    public string[] Words;
    private int internalcounter;

    [Header("Wait's")]
    public float dialogueOnScreenTimer;
    public float TimeUntilShow;

    [Header("Display Text")]
    public TextMeshProUGUI DisplayText;

    // Start is called before the first frame update
    void Start()
    {
        StartDialogue(); // Probably want to remove this down the line - Tom
    }

    public void StartDialogue()
    {
        StartCoroutine(TimedDisplayWords());
    }

    // Pretty self explanatory code but the code waits however long TimeUntilShow is and checks if the part of the array
    // (words) is on exists, if it does set the DisplayText text equal to the words string, wait for however long
    // dialogueOnScreenTimer is and then increase the internal counter so it can set the next part of the words array
    // to the DisplayText text and continues this until eventually  we hit the end of the words array and then it exits
    // the courotine - Tom
    IEnumerator TimedDisplayWords()
    {
        while(true)
        {
            yield return new WaitForSeconds(TimeUntilShow);
            if (internalcounter >= Words.Length)
            {
                DisplayText.text = "";
                Debug.Log("No more dialogue");
                yield break;
            }

            DisplayText.text = Words[internalcounter];
            yield return new WaitForSeconds(dialogueOnScreenTimer);
            internalcounter++;
        }
    }
}
