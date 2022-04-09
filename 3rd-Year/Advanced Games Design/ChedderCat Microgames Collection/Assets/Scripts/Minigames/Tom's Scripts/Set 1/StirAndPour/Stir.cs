using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stir : MonoBehaviour
{
    [Tooltip("How much contact must be made to win?")]
    public int SetContactAmount;
    [Tooltip("How much contact has been made?")]
    public int CurrentContactAmount;

    [Header("Collisions")]
    public bool HitLeft = false;
    public bool HitRight = false;
    public CoffeeMug mug;
    private bool Won = false;

    [Header("Scene Requirements")]
    public MinigameAction action;

    [Header("SFX")]
    public AudioClip Stirring;
    public AudioSource audioSource;
    public float volume;

    [Header("Save File")]
    public MinigameAction.minigameData data;

    private void Start()
    {
        data = action.loaded;

        if(data.timesPlayed <= 20)
        {
            SetContactAmount += data.timesPlayed;
        }
        else
        {
            SetContactAmount += 20;
        }
    }

    public void Update()
    {
        if(CurrentContactAmount >= SetContactAmount && Won == false)
        {
            Won = true;
            action.WinMicrogame();
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("LeftSide"))
        {
            Debug.Log("T");
        }
        if (other.CompareTag("LeftSide") && HitLeft == false && mug.Stirable == true)
        {
            HitRight = false;
            HitLeft = true;
            CurrentContactAmount++;
            if (audioSource.isPlaying == false)
            {
                audioSource.PlayOneShot(Stirring, volume);
            }
            return;
        }
        if(other.CompareTag("RightSide") && HitRight == false && mug.Stirable == true)
        {
            HitRight = true;
            HitLeft = false;
            CurrentContactAmount++;
            if (audioSource.isPlaying == false)
            {
                audioSource.PlayOneShot(Stirring, volume);
            }
            return;
        }
    }
}
