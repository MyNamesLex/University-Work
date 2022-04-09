using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionTextTrigger : MonoBehaviour
{
    public MinigameDisplay display;
    public string ActionText;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            display.SetActionText(ActionText);
        }
    }

}
