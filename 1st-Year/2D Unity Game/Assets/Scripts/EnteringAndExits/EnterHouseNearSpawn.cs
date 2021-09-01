using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnterHouseNearSpawn : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        //if the player enters the invisible item's hitbox where the entrance is to an area, execute this piece of code
        if (other.name == "Player")
        {
            //The scene number to load (in File->Build Settings)
            SceneManager.LoadScene(5);
        }
    }
}
