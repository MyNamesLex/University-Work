using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    [Header("Keys to be mashed")]
    public KeyCode Key;
    public KeyCode Key2;

    [Tooltip("How close is the game to being beaten?")]
    public int PercentageDone;
    [Tooltip("How much percentage will be increased per key press")]
    public int DesiredIncrement;

    [Header("Scene Requirements")]
    public MinigameAction action;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(Key))
        {
            PercentageDone += DesiredIncrement;
        }

        if (Input.GetKeyDown(Key2))
        {
            PercentageDone += DesiredIncrement;
        }

        if(PercentageDone >= 100)
        {
            action.WinMicrogame();
            Debug.Log("won");
        }
    }
}
