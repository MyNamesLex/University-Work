using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PopUps : MonoBehaviour
{
    public string[] PopupTextMessages;
    public TextMeshProUGUI PopupText;
    public Animator anim;
    public int currentMessage;
    public int TimeOnScreen;
    public int TimeOffScreen;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DisplayPopupText());
    }

    IEnumerator DisplayPopupText()
    {
        while(true)
        {
            if (currentMessage >= PopupTextMessages.Length)
            {
                yield break;
            }
            anim.SetBool("Show", true);
            PopupText.text = PopupTextMessages[currentMessage];
            yield return new WaitForSeconds(TimeOnScreen);
            anim.SetBool("Show", false);
            yield return new WaitForSeconds(TimeOffScreen);
            currentMessage++;
        }
    }
}
