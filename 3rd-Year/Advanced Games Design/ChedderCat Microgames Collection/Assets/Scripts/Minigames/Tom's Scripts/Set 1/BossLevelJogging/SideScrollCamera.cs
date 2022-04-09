using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideScrollCamera : MonoBehaviour
{
    public float speed;
    public Camera Cam;
    public GameObject Player;
    public MinigameAction action;
    public bool StopCam = false;
    public GameObject StopCamPos;
    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip outofview;
    public float volume;
    private bool stopdupe = false;
    // Start is called before the first frame update
    void Start()
    {
        Cam = gameObject.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 PlayerViewPosition = Cam.WorldToViewportPoint(Player.transform.position);
        Vector3 CamViewPosition = Cam.WorldToViewportPoint(StopCamPos.transform.position);


        if (StopCam == false)
        {

            if(CamViewPosition.x >= 0 && PlayerViewPosition.x <= 1)
            {

            }
            else
            {
                StopCam = true;
            }

            if (PlayerViewPosition.x >= 0 && PlayerViewPosition.x <= 1)
            {
                Debug.Log("In View");
                Cam.transform.position = new Vector3(Cam.transform.position.x + speed * Time.deltaTime, Cam.transform.position.y, -10);
            }
            else
            {
                if (stopdupe == false)
                {
                    stopdupe = true;
                    audioSource.PlayOneShot(outofview, volume);
                    Debug.Log("Not In View");
                    action.LoseMicrogame();
                }
            }
        }
    }
}
