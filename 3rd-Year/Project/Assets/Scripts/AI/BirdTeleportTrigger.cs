using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdTeleportTrigger : MonoBehaviour
{
    public GameObject InstantiateBirdObj;
    public GameObject BirdTeleportStart;
    public GameObject BirdTeleportEnd;
    private bool hit = false;

    [Header("Floats")]
    public float DeathTimer;
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && hit == false)
        {
            hit = true;
            GameObject bird = Instantiate(InstantiateBirdObj, BirdTeleportStart.transform.position, BirdTeleportStart.transform.rotation);
            bird.GetComponent<StraightToAI>().Collider1Pos = BirdTeleportEnd;
            bird.gameObject.transform.rotation = BirdTeleportStart.transform.rotation;

        }
    }

    public IEnumerator Timer()
    {
        yield return new WaitForSeconds(DeathTimer);
        Destroy(gameObject);
    }
}
