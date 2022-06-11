using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongSideRoadTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<Player>().MovePlayerToSpawn();
            other.GetComponent<Player>().ci.EditText("You were driving on the wrong side of the road!");
        }
    }
}
