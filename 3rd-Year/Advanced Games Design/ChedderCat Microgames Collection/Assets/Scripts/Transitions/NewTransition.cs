using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class NewTransition : MonoBehaviour
{
    [Header("UI Values")]
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI HeadingText;

    public int Points;
    public int Lives;

    public MinigameHandler handler;
    public MinigameAction action;
    public string sceneName;
    public bool isFreeplay;
    public bool PointsSet = false;

    
    // Start is called before the first frame update
    void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
    }

    public void SetValues()
    {
        string load = File.ReadAllText(Application.dataPath + sceneName + ".sussy");
        MinigameAction.minigameData loaded = JsonUtility.FromJson<MinigameAction.minigameData>(load);

        if (PointsSet == false)
        {
            PointsSet = true;
            Points = handler.points + Points;
        }
        if (isFreeplay == true)
        {
            if (loaded.FreeplayScore < Points)
            {
                loaded.FreeplayScore = Points;
            }
        }
        else
        {
            if (loaded.gameScore < Points)
            {
                loaded.gameScore = Points;
            }
        }
        SetText();
    }
    private void SetText()
    {
        ScoreText.text = "Points: " + Points;

        switch(Lives)
        {
            case 4:
                break;
            case 3:
                break;
            case 2: 
                break;
            case 1:
                break;
            case 0:
                //display RedX, Set text to GameOver
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
