using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brush : MonoBehaviour
{
    [Tooltip("How quick it changes to white per every collision")]
    public float BlueIncrementValue;

    [Header("Lists")]
    public List<GameObject> Teeth;
    public List<GameObject> CleanTeeth;

    [Header("Teeth Sprites")]
    public Sprite TeethWhite;
    public Sprite Teeth1White;
    public Sprite Teeth2White;
    public Sprite Teeth3White;
    public Sprite Teeth4White;
    public Sprite Teeth5White;
    public Sprite Teeth6White;
    public Sprite Teeth7White;
    public Sprite Teeth8White;
    public Sprite Teeth9White;

    [Header("Scene Requirements")]
    public MinigameAction action;
    public MinigameHandler handler;

    public bool Triggered = false;

    [Header("Drag Object")]
    public DragObject dragobj;

    [Header("Save File")]
    public MinigameAction.minigameData data;

    [Header("SFX")]
    public AudioSource audioSource;
    public AudioClip ToothCleaned;
    public float volume = 0.5f;

    private void Start()
    {
        data = action.loaded;
    //    BlueIncrementValue /= data.timesPlayed;
        if(BlueIncrementValue <= 2.5)
        {
            BlueIncrementValue = 100;
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Teeth"))
        {
            other.GetComponent<ParticleSystem>().Play();
            SpriteRenderer r = other.GetComponent<SpriteRenderer>();

            other.GetComponent<Teeth>().blue += BlueIncrementValue;

            if (other.GetComponent<Teeth>().blue >= 255 && !CleanTeeth.Contains(other.gameObject))
            {
                r.color = new Color(255, 255, other.GetComponent<Teeth>().blue);
                audioSource.PlayOneShot(ToothCleaned, volume);
                Debug.Log("clean tooth");
                TeethOrganiser(other.gameObject);
                CleanTeeth.Add(other.gameObject);
            }

            if(CleanTeeth.Count == 10 && Triggered == false)
            {
                Triggered = true;
                action.WinMicrogame();
            }
        }

    }

    public void TeethOrganiser(GameObject g)
    {
        switch(g.name)
        {
            case "Teeth":
                g.GetComponent<SpriteRenderer>().sprite = TeethWhite;
                break;
            case "Teeth (1)":
                g.GetComponent<SpriteRenderer>().sprite = Teeth1White;
                break;
            case "Teeth (2)":
                g.GetComponent<SpriteRenderer>().sprite = Teeth2White;
                break;
            case "Teeth (3)":
                g.GetComponent<SpriteRenderer>().sprite = Teeth3White;
                break;
            case "Teeth (4)":
                g.GetComponent<SpriteRenderer>().sprite = Teeth4White;
                break;
            case "Teeth (5)":
                g.GetComponent<SpriteRenderer>().sprite = Teeth5White;
                break;
            case "Teeth (6)":
                g.GetComponent<SpriteRenderer>().sprite = Teeth6White;
                break;
            case "Teeth (7)":
                g.GetComponent<SpriteRenderer>().sprite = Teeth7White;
                break;
            case "Teeth (8)":
                g.GetComponent<SpriteRenderer>().sprite = Teeth8White;
                break;
            case "Teeth (9)":
                g.GetComponent<SpriteRenderer>().sprite = Teeth9White;
                break;
        }
    }
}
