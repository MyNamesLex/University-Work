using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PedCrossRoad : MonoBehaviour
{
    public GameObject AIToCross;
    public GameObject TeleportPosToStartWalking;
    public GameObject PositionToCrossFrom;
    public TrafficLight trafficlight1;
    public TrafficLight trafficlight2;
    public GameObject NewCollider1PosObj;
    public GameObject NewCollider2PosObj;
    public bool hitonce = false;
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && hitonce == false)
        {
            Debug.Log("hit once was false");
            hitonce = true;
            AIToCross.transform.position = TeleportPosToStartWalking.transform.position;
            AIToCross.GetComponent<WalkingAI>().CrossFromPos = PositionToCrossFrom;
            AIToCross.GetComponent<WalkingAI>().PrimedToCross = true;
            StartCoroutine(trafficlight1.LockRedCourotine());
            StartCoroutine(trafficlight2.LockRedCourotine());
        }
        else
        {
            Debug.Log("hit once is true");
        }
    }

    public GameObject NewCollider1Pos()
    {
        return NewCollider1PosObj;
    }

    public GameObject NewCollider2Pos()
    {
        return NewCollider2PosObj;
    }
}

