using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkSugarScript : MonoBehaviour
{
    [Header("Particles")]
    public ParticleSystem particles;

    public CoffeeMug mug;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Sugar" || collision.gameObject.name == "Milk")
        {
            Destroy(collision.gameObject);
            Instantiate(particles, gameObject.transform.position, gameObject.transform.rotation);
            //mug.Collided = true;
            Destroy(gameObject);
        }
    }
}
