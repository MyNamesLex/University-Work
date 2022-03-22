using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedParticle : MonoBehaviour
{

    public int TimerAmount;
    public ParticleSystem particle;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        while(true)
        {
            yield return new WaitForSeconds(TimerAmount);
            particle.Play();
        }
    }
}
