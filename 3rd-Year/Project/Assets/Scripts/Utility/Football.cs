using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Football : MonoBehaviour
{
    public Animator anim;
    public bool isSecondFootball = false;
    // Start is called before the first frame update
    void Start()
    {
        anim.SetBool("SecondFootball", isSecondFootball);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
