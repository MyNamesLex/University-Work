using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// reference script for input syntax / quick playtesting to see if the input for the minigame would feel right - Tom
public class BasePlayerInputScript : MonoBehaviour
{
    public string keyinput;
    public int clickmouseinput;
    private KeyCode key; // key input - Tom

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(key)) // 'key' is the keycode (what we said it would be in the string) - Tom
        {
            Debug.Log("Input Registered");
        }

        if(Input.GetMouseButton(clickmouseinput)) // 'clickmouseinput' is right click (1) or left click (0) on mouse - Tom
        {
            Debug.Log("clicked mouse");
        }

        if(Input.mouseScrollDelta.y > 0) // scroll up - Tom
        {
            Debug.Log("Scroll up");
        }

        if(Input.mouseScrollDelta.y < 0) // scroll down - Tom
        {
            Debug.Log("Scroll down");
        }

    }

    //I know i could just have a public keycode code and do it that
    //way instead of having it be like this in a string but doing it this
    //way will limit us in how many keys we use - Tom

    public KeyCode ConvertToKeyCode(string keyinput)
    {
        keyinput = keyinput.ToUpper();
        switch(keyinput)
        {
            case "SPACE":
                key = KeyCode.Space;
                return key;
            default:
                key = KeyCode.None;
                Debug.LogError("KeyCode not applied, could not find the keyinput to match");
                return key;
        }
    }
}

//This checks Save data location and loads it 
/*
string path = Application.persistentDataPath + "/testsavefile.xyz"; // file path - Tom

if (File.Exists(path))
{
    sv.LoadPlayerValues();
}
else
{
    Debug.LogWarning("File does not exist, just started game");
}
ConvertToKeyCode(keyinput);
*/