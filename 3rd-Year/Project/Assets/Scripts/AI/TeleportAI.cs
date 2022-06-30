using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportAI : MonoBehaviour
{
    public GameObject[] StartingPositions;
    public GameObject[] EndingPositions;
    public int rngstart;
    public int rngend;
    public bool HitEnd = false;
    public float speed;

    public void Start()
    {
        RNG();
    }

    public void RNG()
    {
        rngstart = Random.Range(0, StartingPositions.Length);
        rngend = Random.Range(0, EndingPositions.Length);
        gameObject.transform.position = StartingPositions[rngstart].transform.position;
        gameObject.transform.rotation = StartingPositions[rngstart].transform.rotation;
        HitEnd = false;
    }

    public void Update()
    {
        float step = speed * Time.deltaTime;

        if (HitEnd == false)
        {
            transform.position = Vector3.MoveTowards(gameObject.transform.position, EndingPositions[rngend].transform.position, step);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("HitEnd") && HitEnd == false)
        {
            HitEnd = true;
            RNG();
        }
    }
}
