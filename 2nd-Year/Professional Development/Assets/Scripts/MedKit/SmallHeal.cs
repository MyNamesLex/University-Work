using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallHeal : MonoBehaviour
{
    public void SmallHealFunction()
    {
        NewPlayerMovement PLAYER = FindObjectOfType<NewPlayerMovement>();


        if(PLAYER.Health >= 80)
        {
            return;
        }
        PLAYER.Health += 20;

        PLAYER.HealthText.text = "Health: " + PLAYER.Health;
    }
}
