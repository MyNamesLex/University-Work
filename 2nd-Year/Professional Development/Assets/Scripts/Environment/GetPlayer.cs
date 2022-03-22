using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject Player = GameObject.Find("Player");

        Player.transform.position = this.transform.position;
    }

}
