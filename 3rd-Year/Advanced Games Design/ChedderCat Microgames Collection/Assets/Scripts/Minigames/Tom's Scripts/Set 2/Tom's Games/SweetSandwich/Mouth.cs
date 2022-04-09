using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouth : MonoBehaviour
{
    public MinigameAction action;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Sandwich"))
        {
            action.WinMicrogame();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Sandwich"))
        {
            action.LoseMicrogame();
        }
    }
}
