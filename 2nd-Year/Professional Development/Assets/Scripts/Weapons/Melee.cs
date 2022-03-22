using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    public bool meleeattack;
    public float volume = 0.5f;
    public AudioSource audioSource;
    public AudioClip meeleeSnd;
    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    public void Rotate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Swing());
        }

        if(meleeattack == true)
        {
            transform.Rotate(0, 0, 90);
        }
        else
        {
            transform.Rotate(0, 0, 0);
        }
    }

    IEnumerator Swing()
    {
        while(true)
        {
            meleeattack = true;
            audioSource.PlayOneShot(meeleeSnd, volume);
            yield return new WaitForSeconds(0.1f);
            meleeattack = false;
            break;
        }
    }
}
