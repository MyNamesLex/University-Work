using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainAmmo : MonoBehaviour
{
    public int AmountOfAmmoGained;
    private void OnTriggerEnter(Collider other)
    {

        AmmoCollector ammocollector = FindObjectOfType<AmmoCollector>();
        if(other.tag == "Player")
        {
            NewPlayerMovement player = FindObjectOfType<NewPlayerMovement>();

            ammocollector.totalammo += AmountOfAmmoGained;

            Destroy(gameObject);
        }
    }
}
