using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CorrectIncorrect : MonoBehaviour
{
    public TextMeshProUGUI CorrectIncorrectText;
    public int TimeOnScreen;
    public void EditText(string s)
    {
        CorrectIncorrectText.text = s;
        StartCoroutine(DisplayTime());
    }

    IEnumerator DisplayTime()
    {
        while(true)
        {
            yield return new WaitForSeconds(TimeOnScreen);
            CorrectIncorrectText.text = "";
            yield break;
        }
    }
}
