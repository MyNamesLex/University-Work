using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthValuePlayer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        helahtbarscript.health -= 5f; //deals damage
    }
}
