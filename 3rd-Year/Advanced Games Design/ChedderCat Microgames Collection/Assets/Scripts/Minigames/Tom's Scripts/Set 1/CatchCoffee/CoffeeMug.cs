using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeMug : MonoBehaviour
{
    public bool SugarCollided;
    public bool MilkCollided;

    public ParticleSystem MilkParticles;
    public ParticleSystem SugarParticles;

    public bool Stirable;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Sugar"))
        {
            SugarCollided = true;
            IsStirable();
            Destroy(other.gameObject);
            SugarParticles.Play();
        }
        if(other.CompareTag("Milk"))
        {
            MilkCollided = true;
            IsStirable();
            Destroy(other.gameObject);
            MilkParticles.Play();
        }
    }

    private void IsStirable()
    {
        if(MilkCollided && SugarCollided)
        {
            Stirable = true;
        }
    }
}
