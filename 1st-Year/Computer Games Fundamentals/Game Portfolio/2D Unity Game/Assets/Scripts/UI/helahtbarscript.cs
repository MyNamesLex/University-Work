using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class helahtbarscript : MonoBehaviour
{
    Image HealthBarImage;
    float maxhealth = 100f; //the max amount of health
    public static float health;

    // Start is called before the first frame update
    void Start()
    {
        HealthBarImage = GetComponent<Image>(); //displays the healthbar image
        health = maxhealth; 
    }

    // Update is called once per frame
    void Update()
    {
        HealthBarImage.fillAmount = health / maxhealth; //health divided by the max amount you can have
    }
}