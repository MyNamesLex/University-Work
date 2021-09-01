using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapScript3 : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        //if the player enters the invisible item's hitbox where the entrance is to an area, execute this piece of code
        if (other.name == "Player")
        {
            GameObject Trap3 = GameObject.Find("TrapTrigger3");
            Trap3.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
