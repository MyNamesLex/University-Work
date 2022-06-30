using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class StaggerText : MonoBehaviour
{
    public TextMeshProUGUI DisplayText;
    public string[] Text;
    public float TimeOnScreen;
    public int CurrentText;
    public string NextSceneName;

    public void Start()
    {
        StartCoroutine(StaggerTextCourotine());
    }

    IEnumerator StaggerTextCourotine()
    {
        while(true)
        {
            if(CurrentText == Text.Length)
            {
                Debug.Log("No more strings in Text, CurrentText: " + CurrentText + "| Text length: " + Text.Length);
                SceneManager.LoadScene(NextSceneName);
                yield break;
            }

            DisplayText.text = Text[CurrentText];
            yield return new WaitForSeconds(TimeOnScreen);
            CurrentText++;
        }
    }
}
