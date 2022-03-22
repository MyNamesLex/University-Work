using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour
{
    public int avgFrameRate;
    public Text fpstext;
    public float current = 0;
    public void Update()
    {
        current = (int)(1f / Time.unscaledDeltaTime);
        avgFrameRate = (int)current;
        fpstext.text = avgFrameRate.ToString() + " FPS";
    }
}
