using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossLineEnableDisable : MonoBehaviour
{
    public Player player;
    public bool CanCross;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (player.InTimeline == false)
            {
                player.CanCrossLine = CanCross;
            }
        }
    }
}
