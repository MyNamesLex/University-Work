﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallCollider : MonoBehaviour
{
    public GameObject Spawn;
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.transform.position = Spawn.transform.position;
        }
    }
}
