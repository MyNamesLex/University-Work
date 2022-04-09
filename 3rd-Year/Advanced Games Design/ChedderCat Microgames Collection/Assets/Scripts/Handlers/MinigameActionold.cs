using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigameActionold : MonoBehaviour
{
    [Header("Scene Requirements")]
    public MinigameHandler handler;
    public TransitionCanvas transitionCanvas;
    public string minigameName;
    public string playerPrompt;

    //Save Data Related
    string sceneName;
    string dataLocation;
    minigameData data = new minigameData();

    [Serializable]
    public class minigameData
    {
        public bool playedBefore = false;

        public float gameScore;         //Minigame Specific Score/Quickest Time
        public int FreeplayScore;       //Longest Run
        public int timesPlayed;         //Times the game has been played
    }

    void Awake()
    {
        sceneName = SceneManager.GetActiveScene().name;
        dataLocation = Application.dataPath + sceneName + ".sussy";

        LoadSave();
    }

    public void Save() //Write
    {

        //do data stuff here
        string json = JsonUtility.ToJson(data);
        SaveScore();
        data.playedBefore = true;
        data.timesPlayed++;

        File.WriteAllText(dataLocation, json);
        Debug.Log("data saved");
    }

    public void LoadSave() //Read
    {
        if (File.Exists(dataLocation))
        {
            string load = File.ReadAllText(dataLocation);
            minigameData loaded = JsonUtility.FromJson<minigameData>(load);
            Debug.Log("Data Loaded");
        }
        else
        {
            Save();
            Debug.Log("No existing data, created new");
        }
    }

    //Call this method from Microgame
    public void SaveScore()
    {
        float gameScore = handler.timeSpent;
        //Compare to loaded one 
        if (gameScore >= data.gameScore)
        {
            data.gameScore = gameScore;
            Debug.Log("Score Set");
        }
        else{ Debug.Log("Not a Highscore"); }
    }

    public void WinMicrogame()
    {
        Debug.Log("Win");
        transitionCanvas.SetValues();
        Save();
        handler.LoadingLevel(false);
    }

    public void LoseMicrogame()
    {
        Debug.Log("Lose");
        transitionCanvas.SetValues();
        Save();
        handler.LoadingLevel(true);
    }
}