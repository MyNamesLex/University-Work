using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLight : MonoBehaviour
{
    [Header("Timers")]
    public float TimeUntilChange;
    [HideInInspector] public float OGTimeUntilChange;
    public float GoToGreenTimer;
    [HideInInspector] public float OGGoToGreenTimer;

    [Header("Bools")]
    public bool InCourotine;
    public bool RedLightShowing;
    public bool LockRed = false;

    [Header("Light Objects")]
    public GameObject RedLight;
    public GameObject YellowLight;
    public GameObject GreenLight;

    [Header("Player Cross Line Trigger")]
    public GameObject TrafficLine;
    // Start is called before the first frame update
    void Start()
    {
        OGTimeUntilChange = TimeUntilChange;
        OGGoToGreenTimer = GoToGreenTimer;
        if (gameObject.name == "IndividualTrafficLight")
        {
            TrafficLine.GetComponent<BoxCollider>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (RedLightShowing == true && LockRed == false) // if red light
        {
            if (TimeUntilChange > 0)
            {
                TimeUntilChange -= Time.deltaTime;
            }
            else
            {
                if (InCourotine == false)
                {
                    InCourotine = true;
                    StartCoroutine(ShowGreenLight());
                }
            }
        }
        else if(RedLightShowing == false && LockRed == false) // if green light
        {
            if (TimeUntilChange > 0)
            {
                TimeUntilChange -= Time.deltaTime;
            }
            else if(InCourotine == false)
            {
                InCourotine = true;
                StartCoroutine(ShowRedLight());
            }
        }
    }

    public IEnumerator ShowRedLight()
    {
        while(true)
        {
            YellowLight.SetActive(true);
            yield return new WaitForSeconds(GoToGreenTimer);
            GreenLight.SetActive(false);
            YellowLight.SetActive(false);
            RedLight.SetActive(true);
            RedLightShowing = true;
            Debug.Log("red light showing");
            if (gameObject.name == "IndividualTrafficLight")
            {
                TrafficLine.GetComponent<BoxCollider>().enabled = true;
            }
            InCourotine = false;
            TimeUntilChange = OGTimeUntilChange;
            break;
        }
    }

    public IEnumerator LockRedCourotine()
    {
        while (true)
        {
            LockRed = true;
            InCourotine = true;
            YellowLight.SetActive(true);
            yield return new WaitForSeconds(GoToGreenTimer);
            GreenLight.SetActive(false);
            YellowLight.SetActive(false);
            RedLight.SetActive(true);
            RedLightShowing = true;
            Debug.Log("red light showing");
            break;
        }
    }

    public IEnumerator ShowGreenLight()
    {
        while (true)
        {
            YellowLight.SetActive(true);
            yield return new WaitForSeconds(GoToGreenTimer);
            RedLight.SetActive(false);
            YellowLight.SetActive(false);
            GreenLight.SetActive(true);
            RedLightShowing = false;
            Debug.Log("green light showing");
            if (gameObject.name == "IndividualTrafficLight")
            {
                TrafficLine.GetComponent<BoxCollider>().enabled = false;
            }
            InCourotine = false;
            TimeUntilChange = OGTimeUntilChange;
            break;
        }
    }
}
