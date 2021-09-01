using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ExitShack : MonoBehaviour
{
    public Transform InventoryUI;
    void OnTriggerEnter2D(Collider2D other)
    {
        //if the player enters the invisible item's hitbox where the entrance is to an area, execute this piece of code
        if (other.name == "Player")
        {
            SceneManager.LoadScene(1);
        }
    }
}
