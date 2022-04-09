using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class MinigameHandler : MonoBehaviour
{
    [Header("Scene Names")]
    public List<string> NormalMinigameSceneNames;
    public List<string> BossSceneNames;
    public List<string> SequencedEvent;

    [Header("Persistent Values")]
    public PersistenceHandler persistenceHandler;
    [HideInInspector]  public int lives;
    [HideInInspector]  public int points;

    [Header("States")]
    [Tooltip("Raw Timer Float")]
    public float DurationOfMinigame;
    public bool INGAME;
    public bool LOADING;
    public bool FAIL;
    public bool FREEPLAY;
    [HideInInspector] public float timeSpent;

    [Header("Minigame Values")]
    public bool IsSequenced;
    public bool IsTimedEvent;
    public bool IsBossEvent;

    [Header("Transition")]
    public TransitionCanvas Transition;
    private void Start()
    {
        GameObject g = GameObject.FindGameObjectWithTag("PersistenceHandler");

        // Did this so we don't have to keep going into main menu and load from there - Tom

        if (g != null)
        {
            persistenceHandler = g.GetComponent<PersistenceHandler>();

            FREEPLAY = persistenceHandler.isFreeplay;
            lives = persistenceHandler.lives;
            points = persistenceHandler.points;
        }
        else
        {
            Debug.LogWarning("Persistence Handler not found!");
            lives = 3;
            points = 3;
            FREEPLAY = false;
        }

        Transition.DisplayLives();
    }

    // Update is called once per frame
    void Update()
    {
        if (INGAME == true && IsTimedEvent == true)
        {
            DurationOfMinigame -= Time.deltaTime;
            timeSpent += Time.deltaTime;
        }

        if(lives <= 0)
        {
            FAIL = true;
            Debug.Log("lives less then 0");
            LoadMainMenu();
        }

        if(DurationOfMinigame <= 0 && IsTimedEvent == true)
        {
            Debug.Log("DurationofMinigame less then 0 and is timed event");
            FAIL = true;
            LoadingLevel(FAIL);
        }

        // LOADING / INGAME //

        if (Transition.anim.GetBool("Show") == false)
        {
            INGAME = true;
            LOADING = false;
        }
        else if(LOADING == false)
        {
            LOADING = true;
            StartCoroutine(TransitionDelayCourotine());
            INGAME = false;
        }
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadingLevel(bool fail)
    {
        LOADING = true;

        if (fail == false && SceneManager.GetActiveScene().name != "StoryShow")
        {
            Transition.WonLostText.text = "Won!";
            points++;
        }
        else if (SceneManager.GetActiveScene().name != "StoryShow")
        {
            MinusLife(1);
            Transition.WonLostText.text = "Lost!";
        }

        NextMinigame();
    }

    public void NextMinigame()
    {
        SaveValues();
        Transition.ShowTransition();
    }

    IEnumerator TransitionDelayCourotine()
    {
        while(true)
        {
            yield return new WaitForSeconds(Transition.TimeUntilHide);

            if (FREEPLAY == true)
            {
                SceneManager.LoadScene("MainMenu");
            }

            if (FAIL == false && FREEPLAY == false)
            {
                Debug.Log("Microgame Passed!");
                PassMicrogame();
            }

            // FAILURE EVENT //
            if (FAIL == true && FREEPLAY == false)
            {
                Debug.Log("Microgame Failed!");
                FailMicroGame();
            }

            // ERROR CATCH
            else
            {
                Debug.LogWarning("Cannot load next microgame: " + " FAIL BOOLEAN: " + FAIL + " Is Sequenced: " + IsSequenced);
            }
        }
    }

    public void PassMicrogame()
    {
        // PASS EVENTS //

        //Timed Events
        if (IsTimedEvent == true)
        {
            Debug.Log("Timed Microgame Cleared!" + "IsTimedEvent should Return True = " + IsTimedEvent);
            string currentscene = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentscene);
        }
        //Boss Events
        if(IsBossEvent == true)
        {
            Debug.Log("Boss Microgame Cleared!" + "IsBossEvent should Return True = " + IsBossEvent);
            int rng = UnityEngine.Random.Range(0, BossSceneNames.Count);
            string loadscene = BossSceneNames[rng];
            SceneManager.LoadScene(loadscene);
        }

        //Sequenced Events
        if (IsSequenced == true)
        {
            Debug.Log("Sequenced Microgame Cleared!" + "If this event is Timed also, This will return true = " + IsTimedEvent);
            string NextInSequence = SequencedEvent[0];
            SceneManager.LoadScene(NextInSequence);
        }

        //Normal Events
        else
        {
            Debug.Log("Microgame Cleared! All should return false: Timed = " + IsTimedEvent + " Boss = " + IsBossEvent + " Sequenced = " + IsSequenced);
            int rng = UnityEngine.Random.Range(0, NormalMinigameSceneNames.Count);
            string loadscene = NormalMinigameSceneNames[rng];
            SceneManager.LoadScene(loadscene);
        }
    }

    //Checks Failure Condition and Changes the Level
    public void FailMicroGame()
    {
        // FAIL EVENTS //

        //TIMED Events
        if (IsTimedEvent == true)
        {
            int rng = UnityEngine.Random.Range(0, NormalMinigameSceneNames.Count);
            string loadscene = NormalMinigameSceneNames[rng];
            SceneManager.LoadScene(loadscene);

            Debug.Log("Failed Microgame of type " + " Timed = " + IsTimedEvent);
        }
        else
        // NOT A TIMED EVENT OR SEQUENCED
        {
            //BOSS, SEQUENCED, !TIME OR SEQUENCE Events
            string currentscene = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentscene);

            Debug.Log("Failed Microgame of type " + " Timed = " + IsTimedEvent + " Seqenced = " + IsSequenced + " Boss = " + IsBossEvent);
        }
    }

    // LIFE ADD AND SUBTRACT FUNCTIONS //
    public void MinusLife(int amount)
    {
        lives -= amount;
    }

    public void AddLife(int amount)
    {
        lives += amount;
    }

    // POINTS ADD AND SUBTRACT FUNCTIONS

    public void MinusPoint(int amount)
    {
        points -= amount;
    }
    public void AddPoint(int amount)
    {
        points += amount;
    }

    public void SaveValues()
    {
        if (persistenceHandler != null)
        {
            persistenceHandler.points = points;
            persistenceHandler.lives = lives;
        }
    }
}
