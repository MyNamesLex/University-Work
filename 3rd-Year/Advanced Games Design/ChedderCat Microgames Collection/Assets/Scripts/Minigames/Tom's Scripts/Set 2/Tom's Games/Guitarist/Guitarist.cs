using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Guitarist : MonoBehaviour
{
    [Header("Scene Requirements")]
    public MinigameAction action;

    [Header("Buttons")]
    public Button RedButton;
    public Button YellowButton;
    public Button BlueButton;
    public Button GreenButton;

    [Header("Player Numbers")]
    public int Press1;
    public int Press2;
    public int Press3;
    public int Press4;

    [Header("Button Numbers")]
    public float rng;
    public float rng2;
    public float rng3;
    public float rng4;

    [Header("Input Enabled?")]
    public bool isInputEnabled = false;
    // Start is called before the first frame update
    void Start()
    {
        rng = Random.Range(1, 5);
        rng2 = Random.Range(1, 5);
        rng3 = Random.Range(1, 5);
        rng4 = Random.Range(1, 5);
        StartCoroutine(ShowSequence());
    }

    public void IntToButton(float t)
    {
        switch(t)
        {
            case 1:
                StartCoroutine(FlashButton(RedButton));
                break;
            case 2:
                StartCoroutine(FlashButton(YellowButton));
                break;
            case 3:
                StartCoroutine(FlashButton(GreenButton));
                break;
            case 4:
                StartCoroutine(FlashButton(BlueButton));
                break;
        }
    }

    IEnumerator FlashButton(Button b)
    {
        while (true)
        {
            Debug.Log("y");
            Color color = b.GetComponent<Image>().color;
            b.GetComponent<Image>().color = new Color(255, 255, 255);
            yield return new WaitForSeconds(1);
            b.GetComponent<Image>().color = color;
            yield break;
        }
    }

    IEnumerator ShowSequence()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            IntToButton(rng);
            yield return new WaitForSeconds(2);
            IntToButton(rng2);
            yield return new WaitForSeconds(2);
            IntToButton(rng3);
            yield return new WaitForSeconds(2);
            IntToButton(rng4);
            yield return new WaitForSeconds(2);
            isInputEnabled = true;
            yield break;
        }
    }

    // Button Input //

    public void ButtonInput(string name)
    {
        if (isInputEnabled == true)
        {
            switch (name)
            {
                case "RedButton":
                    if (Press1 == 0)
                    {
                        Press1 = 1;
                        CheckButtons();
                        break;
                    }
                    if (Press2 == 0)
                    {
                        Press2 = 1;
                        CheckButtons();
                        break;
                    }
                    if (Press3 == 0)
                    {
                        Press3 = 1;
                        CheckButtons();
                        break;
                    }
                    if (Press4 == 0)
                    {
                        Press4 = 1;
                        CheckButtons();
                        break;
                    }
                    break;
                case "GreenButton":
                    if (Press1 == 0)
                    {
                        Press1 = 3;
                        CheckButtons();
                        break;
                    }
                    if (Press2 == 0)
                    {
                        Press2 = 3;
                        CheckButtons();
                        break;
                    }
                    if (Press3 == 0)
                    {
                        Press3 = 3;
                        CheckButtons();
                        break;
                    }
                    if (Press4 == 0)
                    {
                        Press4 = 3;
                        CheckButtons();
                        break;
                    }
                    break;
                case "YellowButton":
                    if (Press1 == 0)
                    {
                        Press1 = 2;
                        CheckButtons();
                        break;
                    }
                    if (Press2 == 0)
                    {
                        Press2 = 2;
                        CheckButtons();
                        break;
                    }
                    if (Press3 == 0)
                    {
                        Press3 = 2;
                        CheckButtons();
                        break;
                    }
                    if (Press4 == 0)
                    {
                        Press4 = 2;
                        CheckButtons();
                        break;
                    }
                    break;
                case "BlueButton":
                    if (Press1 == 0)
                    {
                        Press1 = 4;
                        CheckButtons();
                        break;
                    }
                    if (Press2 == 0)
                    {
                        Press2 = 4;
                        CheckButtons();
                        break;
                    }
                    if (Press3 == 0)
                    {
                        Press3 = 4;
                        CheckButtons();
                        break;
                    }
                    if (Press4 == 0)
                    {
                        Press4 = 4;
                        CheckButtons();
                        break;
                    }
                    break;
            }
        }
    }

    public void CheckButtons()
    {
        if(Press1 == rng && Press2 == rng2 && Press3 == rng3 && Press4 == rng4)
        {
            action.WinMicrogame();
        }
        else if(Press1 != 0 && Press2 != 0 && Press3 != 0 && Press4 != 0)
        {
            action.LoseMicrogame();
        }
        else
        {
            return;
        }
    }
}
