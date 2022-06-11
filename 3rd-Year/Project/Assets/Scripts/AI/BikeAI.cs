using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BikeAI : MonoBehaviour
{
    public NavMeshAgent nma;
    public GameObject Collider1Pos;
    public GameObject Collider2Pos;
    public bool HitCollider1 = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collider1"))
        {
            HitCollider1 = true;
        }
        if (other.CompareTag("Collider2"))
        {
            HitCollider1 = false;
        }
    }
}
