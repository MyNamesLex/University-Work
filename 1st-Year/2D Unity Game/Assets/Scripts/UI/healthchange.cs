using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthchange : MonoBehaviour
{ 
    public MessageDisplay messageBox;
    public Transform RestartUI;
    float maxHealth = 100f;

    void OnTriggerEnter2D(Collider2D coll)
    {
        
        if (coll.gameObject.tag == "Spike")
        {
            helahtbarscript.health -= 10f; //takes health
        }
        if (coll.gameObject.tag == "Health")
        {
            if (helahtbarscript.health == 100) // ensuring the player does not exceed past 100 health
            {
                helahtbarscript.health += 0f; //adds no health if the player health is above 100
            }
            else
            {
                helahtbarscript.health += 10f; //adds health
                Destroy(coll.gameObject); //destroys the FullHP gameobject upon collision
            }
        }
        if (coll.gameObject.tag == "FullHP")
        {
            if (helahtbarscript.health == 100) // ensuring the player does not exceed past 100 health
            {
                helahtbarscript.health += 0f; //adds no health if the player health is above 100
            }
            else
            {
                helahtbarscript.health += 100f; //adds health
                Destroy(coll.gameObject); //destroys the FullHP gameobject upon collision
                if (helahtbarscript.health > 100) //checks if the health is above 100
                { 
                    helahtbarscript.health = 100f; //sets the player health too 100
                }
            }
        }
        if (coll.gameObject.tag == "InstaKill")
        {
                helahtbarscript.health = 0; //sets the players health to zero
        }
        if (helahtbarscript.health == 0) // checks if the player has zero health kills the player
        {
            Destroy(gameObject); // destroys the player object (killing the player)
            messageBox.ShowMessage("Game Over. Press the Restart button in the Bottom Left to Restart", 5.0f); //prompts them to restart and directs them how to restart
            RestartUI.gameObject.SetActive(true); // displays the restart button
        }
    }
}
