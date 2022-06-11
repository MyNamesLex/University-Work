using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkingAI : MonoBehaviour
{
    [Header("Walking AI")]
    public NavMeshAgent nma;
    public GameObject Collider1Pos;
    public GameObject Collider2Pos;

    [Header("Cross Road AI")]
    public GameObject CrossToPos;
    public GameObject CrossFromPos;
    public PedCrossRoad CrossRoadScript;
    public TrafficLight tl;
    public TrafficLight tl2;

    [Header("Walk Bools")]
    public bool HitCollider1 = false;

    [Header("Crossing Bools")]
    public bool HitCrossPos = false;
    public bool HitCrossedPos = false;
    public bool PrimedToCross = false;

    // Update is called once per frame
    void Update()
    {
        if (PrimedToCross)
        {
            nma.SetDestination(CrossFromPos.transform.position);
        }

        if(HitCrossPos)
        {
            nma.SetDestination(CrossToPos.transform.position);
        }

        else if (!PrimedToCross)
        {
            if (HitCollider1 == false)
            {
                nma.SetDestination(Collider1Pos.transform.position);
            }
            else if (HitCollider1 == true)
            {
                nma.SetDestination(Collider2Pos.transform.position);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Collider1"))
        {
            HitCollider1 = true;
        }
        if(other.CompareTag("Collider2"))
        {
            HitCollider1 = false;
        }

        // CROSS ROAD AI

        if(other.CompareTag("CrossFromPos") && PrimedToCross == true)
        {
            HitCrossPos = true;
            PrimedToCross = false;
        }

        if(other.CompareTag("CrossToPos") && HitCrossPos == true)
        {
            HitCrossPos = false;
            tl.LockRed = false;
            tl2.LockRed = false;
            Collider1Pos = CrossRoadScript.NewCollider1Pos();
            Collider2Pos = CrossRoadScript.NewCollider2Pos();
            StartCoroutine(tl.ShowGreenLight());
            StartCoroutine(tl2.ShowGreenLight());
            tl.GoToGreenTimer = tl.OGGoToGreenTimer;
            tl2.GoToGreenTimer = tl2.OGGoToGreenTimer;
            tl.TimeUntilChange = tl.OGTimeUntilChange;
            tl2.TimeUntilChange = tl2.OGTimeUntilChange;
        }
    }
}
