using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootballManager : MonoBehaviour
{
    public GameObject ball1;
    public GameObject ball3;
    public GameObject ball2;

    public MinigameAction action;
    public bool StopDuplication = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(ball1.gameObject.transform.position.z == 1 || ball2.gameObject.transform.position.z == 1 || ball3.gameObject.transform.position.z == 1)
        {
            if (StopDuplication == false)
            {
                StopDuplication = true;
                action.LoseMicrogame();
            }
        }

        if(ball1.GetComponent<Football>().isCaught && ball2.GetComponent<Football>().isCaught && ball3.GetComponent<Football>().isCaught && StopDuplication == false)
        {
            StopDuplication = true;
            action.WinMicrogame();
        }
    }
}
