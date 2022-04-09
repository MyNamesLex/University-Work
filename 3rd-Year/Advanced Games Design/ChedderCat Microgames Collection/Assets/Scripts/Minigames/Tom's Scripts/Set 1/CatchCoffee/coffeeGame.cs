using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class coffeeGame : MonoBehaviour
{
    public Rigidbody2D coffee;
    public GameObject coffeeGameobject;
    public MinigameAction action;
    public MinigameAction.minigameData data;
    public TextMeshProUGUI VisualAid;

    public float coffeeSpeed;
    public Vector3 CoffeeCatchPos;
    public int timesPlayed;
    public bool InHand = false;
    public bool CaughtBool = false;
    public KeyCode key;
    public float Delay;
    private bool Play = false;
    public float HighEndSpeed;
    public float LowEndSpeed;
    private float RNG;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip Caught;
    public AudioClip Missed;
    public AudioClip Win;
    public float volume;

    [Header("Sprites")]
    public SpriteRenderer sr;
    public Sprite Open;
    public Sprite Closed;

    private void Start()
    {
        RNG = Random.Range(LowEndSpeed, HighEndSpeed);
        data = action.loaded;
        VisualAid.text = "Coffee Not In Hand!";
    }

    // Update is called once per frame
    void Update()
    {
        if (Delay >= 0)
        {
            Delay -= Time.deltaTime;
        }

        if (Delay < 0)
        {
            Play = true;
        }

        if (Play == true)
        {
            Debug.Log("GO");
            //coffeeSpeed = coffeeSpeed += data.timesPlayed;

            coffee.AddForce(new Vector2(coffeeSpeed * Time.deltaTime + RNG * Time.deltaTime, 0));

            if (InHand == true)
            {
                VisualAid.text = "Coffee In Hand!";
            }
            else
            {
                VisualAid.text = "Coffee Not In Hand!";
            }

            if (InHand == true && Input.GetKeyDown(key) && CaughtBool == false)
            {
                CaughtBool = true;
                sr.sprite = Closed;
                coffee.isKinematic = true;
                coffee.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
                //coffeeGameobject.transform.position = new Vector3(CoffeeCatchPos.x, 3, CoffeeCatchPos.z);
                audioSource.PlayOneShot(Caught, volume);
                audioSource.PlayOneShot(Win, volume);
                action.WinMicrogame();
                Debug.Log("Won");
            }
            if (Input.GetKeyDown(key) && InHand == false && CaughtBool == false)
            {
                CaughtBool = true;
                coffee.isKinematic = true;
                audioSource.PlayOneShot(Missed, volume);
                coffee.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
                action.LoseMicrogame();
                Debug.Log("Lost");
            }
            //Add veocity to coffee
            //If button if pressed whilst colliding
            //stop coffee
            //win mircogame
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coffee"))
        {
            Debug.Log("Entered");
            InHand = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Coffee") && CaughtBool == false)
        {
            Debug.Log("Gone");
            InHand = false;
        }
    }
}

