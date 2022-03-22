using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bow : MonoBehaviour
{
    // Update is called once per frame

    GameObject InstantiateArrow;

    public bool Fired = false;

    public int arrows;
    public AudioClip BowShoot;
    public AudioSource audioSource;
    public float volume = 0.5f;

    public Text OutOfArrowsText;

    public void Start()
    {
        ArrowAmount arrowsamount = FindObjectOfType<ArrowAmount>();    
    }

    void Update()
    {
        InstantiateArrow = GameObject.Find("InstantiateArrow");

        ArrowAmount arrowsamount = FindObjectOfType<ArrowAmount>();
        arrows = arrowsamount.totalarrows;
        NewPlayerMovement player = FindObjectOfType<NewPlayerMovement>();

        RandomEvent rand = FindObjectOfType<RandomEvent>();

        Debug.Log(player.equippedbow);

        if (Input.GetMouseButtonDown(0) && player.equippedbow == true && rand.weaponjam == false)
        {
            if (arrows != 0)
            {
                StartCoroutine(Timer());
            }
            if (arrows == 0)
            {
                StartCoroutine(OutOfArrows());
            }
        }
    }

    IEnumerator Timer()
    {
        while(true)
        {
            if (Fired == false)
            {
                Fired = true;
                audioSource.PlayOneShot(BowShoot, volume);
                ArrowAmount arrowsamount = FindObjectOfType<ArrowAmount>();
                arrowsamount.totalarrows -= 1;
                InstantiateArrow.SetActive(true);

                NewPlayerMovement player = FindObjectOfType<NewPlayerMovement>();
                CameraControlloer camera = FindObjectOfType<CameraControlloer>();

                Vector3 pos = player.transform.position;
                Vector3 setpos = new Vector3(-1, 2, 0);

                Vector3 FinalPos = pos + setpos;

                Debug.Log(player.transform.position + "Player Pos");
                Debug.Log(FinalPos + "Final Pos");
                Instantiate(InstantiateArrow, FinalPos, player.transform.rotation);

                yield return new WaitForSeconds(2);
                Fired = false;
                break;
            }
            else
            {
                break;
            }
        }
    }

    IEnumerator OutOfArrows()
    {
        while(true)
        {
            bool seen = false;
            if (seen == false)
            {
                OutOfArrowsText.gameObject.SetActive(true);
                seen = true;
                yield return new WaitForSeconds(2);
                seen = false;
                OutOfArrowsText.gameObject.SetActive(false);
                break;
            }
        }
    }

}
