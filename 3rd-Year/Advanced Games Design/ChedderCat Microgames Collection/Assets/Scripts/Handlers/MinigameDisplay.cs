using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MinigameDisplay : MonoBehaviour
{
    public MinigameHandler handler;

    [Header("Display Values")]
    public Canvas canvas;
    public TextMeshProUGUI actionTextDisplayText;
    public TextMeshProUGUI MicrogameTimeDisplayText;
    public TextMeshProUGUI TransitionTimerTextMesh;
    public TextMeshProUGUI ControlsTextMesh;
    public TextMeshProUGUI Controls2TextMesh;
    public TextMeshProUGUI Controls3TextMesh;
    public string actionText;

    [Header("Display On Screen")]
    public float MicrogameTime;
    public int DecimalPlaces;
    public string ControlsText;
    public string Controls2Text;
    public string Controls3Text;
    [Header("Debug Bools")]
    public bool NoActionText = false;
    public bool NoMicrogameTimeDisplay = false;
    public bool NoCanvas = false;

    // Start is called before the first frame update
    void Start()
    {
        if (actionTextDisplayText != null)
        {
            actionTextDisplayText.text = actionText;
        }
        if(ControlsTextMesh != null)
        {
            ControlsTextMesh.text = ControlsText;
        }
        if (Controls2TextMesh != null)
        {
            Controls2TextMesh.text = Controls2Text;
        }
        if (Controls3TextMesh != null)
        {
            Controls3TextMesh.text = Controls3Text;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (actionTextDisplayText == null && NoActionText == false)
        {
            NoActionText = true;
            Debug.LogWarning("action text display text is null");
        }

        if(MicrogameTimeDisplayText == null && NoMicrogameTimeDisplay == false)
        {
            NoMicrogameTimeDisplay = true;
            Debug.LogWarning("Microgame Time Display Text is null");
        }

        if(canvas == null && NoCanvas == false)
        {
            NoCanvas = true;
            Debug.LogWarning("canvas is null");
        }


        if (canvas != null && MicrogameTimeDisplayText != null && actionTextDisplayText != null)
        {
            if (handler.IsTimedEvent == true && handler.DurationOfMinigame > 0)
            {
                float t = Mathf.Pow(10.0f, DecimalPlaces);
                float display = Mathf.Round(handler.DurationOfMinigame * t) / t;
                MicrogameTime = display;

                MicrogameTimeDisplayText.text = "Timer: " + MicrogameTime;
                TransitionTimerTextMesh.text = MicrogameTimeDisplayText.text;
            }
            else if (handler.DurationOfMinigame <= 0 && handler.IsTimedEvent == true)
            {
                MicrogameTime = 0;
                MicrogameTimeDisplayText.text = "Timer: " + MicrogameTime;

                TransitionTimerTextMesh.text = MicrogameTimeDisplayText.text;
            }

            if (handler.IsTimedEvent == false)
            {
                MicrogameTimeDisplayText.text = "";
                TransitionTimerTextMesh.text = " ";
            }
        }
    }

    public void ShowActionText()
    {
        actionTextDisplayText.gameObject.SetActive(true);
    }

    public void HideActionText()
    {
        actionTextDisplayText.gameObject.SetActive(false);
    }

    public void SetActionText(string text)
    {
        if (actionTextDisplayText.gameObject.activeInHierarchy == false)
        {
            Debug.LogError("ActionText not active but trying to set the text!");
            return;
        }
        else
        {
            actionTextDisplayText.text = text;
        }
    }
}
