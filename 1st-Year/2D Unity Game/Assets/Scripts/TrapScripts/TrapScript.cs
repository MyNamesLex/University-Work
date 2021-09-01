using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        //if the player enters the invisible item's hitbox, it will execute this code
        if (other.name == "Player")
        {
            GameObject Trap = GameObject.Find("TrapTrigger");
            Trap.transform.GetChild(0).gameObject.SetActive(true); //changed the Trap gameObject from inactive to active so when the player triggers the 'TrapTrigger' the trap will be active and kill the player
        }
    }
}
