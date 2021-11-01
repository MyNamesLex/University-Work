using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MessageDisplay : MonoBehaviour
{
    public Transform messageUI;
    Text textObject;
    // Use this for initialization
    void Start()
    {
        textObject = messageUI.GetChild(0).GetComponent<Text>();
    }
    IEnumerator DoMessage(string message, float seconds)
    {
        messageUI.gameObject.SetActive(true);
        textObject.text = message;
        yield return new WaitForSeconds(seconds);
        messageUI.gameObject.SetActive(false);
    }

    internal void ShowMessage(string v)
    {
        throw new NotImplementedException();
    }

    public void ShowMessage(string message, float seconds)
    {
        StartCoroutine(DoMessage(message, seconds));
    }

    IEnumerator DoYesNo(string message, Action<bool> callback)
    {
        message += "\n(Y/N)";
        messageUI.gameObject.SetActive(true);
        textObject.text = message;
        bool answer = false;
        while (true)
        {
            if (Input.GetKeyDown("n"))
            {
                answer = false;
                break;
            }
            if (Input.GetKeyDown("y"))
            {
                answer = true;
                break;
            }
            yield return null; // wait for next frame
        }
        messageUI.gameObject.SetActive(false);
        callback(answer);
    }
    public void YesNoMessage(string message, Action<bool> answerFunc)
    {
        StartCoroutine(DoYesNo(message, answerFunc));
    }
}