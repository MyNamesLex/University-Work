using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miss : MonoBehaviour
{
    public MinigameAction action;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Sandwich"))
        {
            action.LoseMicrogame();
        }
    }
}
