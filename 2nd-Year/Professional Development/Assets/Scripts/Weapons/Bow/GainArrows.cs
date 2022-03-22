using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainArrows: MonoBehaviour
{
    public int AmountOfArrowsGained;
    private void OnTriggerEnter(Collider other)
    {

        ArrowAmount arrowamount = FindObjectOfType<ArrowAmount>();
        if (other.tag == "Player")
        {
            NewPlayerMovement player = FindObjectOfType<NewPlayerMovement>();

            arrowamount.totalarrows += AmountOfArrowsGained;

            Destroy(gameObject);
        }
    }
}
