using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class DragObject : MonoBehaviour
{
    [Header("Scene Requirements")]
    public MinigameAction action;
    public MinigameAction.minigameData loaded;
    [Header("Pick up sizes of the object")]
    public float PickUpSizeX;
    public float PickUpSizeY;
    public float PickUpSizeZ;

    [Header("Drop sizes of the object")]
    public float DropSizeX;
    public float DropSizeY;
    public float DropSizeZ;

    [Header("Bools")]

    [Tooltip("Can the object be picked up right now?")]
    public bool Locked = false;

    [Header("Is this the Brush Teeth Game?")]
    public bool BrushTeethGame = false;
    public bool increasing;
    public bool decreasing;
    public float IncreaseRockValue;
    public float DecreaseRockValue;

    [Header("Is This The Zip Game?")]
    public bool ZipGame = false;
    public float LowXJamParameter;
    public float HighXJamParameter;
    public float LockedTimer;
    public bool ForceDrop;
    public float Threshold;
    public AudioSource audioSource;
    public AudioClip jammed;
    public float volume;

    private void Start()
    {
        if (action != null)
        {
            loaded = action.loaded;
        }
        else if(action == null)
        {
            Debug.LogWarning("Minigame action is null on DragObject Script");
        }

        if(BrushTeethGame == true)
        {
            StartCoroutine(RockBrush());
        }

    }
    public void OnMouseDrag()
    {
        if (Locked == false && ZipGame == false && BrushTeethGame == false)
        {
            transform.localScale = new Vector3(PickUpSizeX, PickUpSizeY, PickUpSizeZ);
            transform.position = MousePosition();
        }

        // Zip Game //

        if (ForceDrop == false)
        {
            if (ZipGame == true)
            {
                if (audioSource.isPlaying == false)
                {
                    audioSource.Play();
                }
                transform.localScale = new Vector3(PickUpSizeX, PickUpSizeY, PickUpSizeZ);
                if (MousePosition().x <= -LowXJamParameter || MousePosition().x >= HighXJamParameter)
                {
                    Jam();
                }
                else if (Locked == false)
                {
                    transform.position = MousePosition();
                }
            }
        }
    }

    public void OnMouseUp()
    {
        if (BrushTeethGame == false)
        {
            ForceDrop = false;
            transform.localScale = new Vector3(DropSizeX, DropSizeY, DropSizeZ);
        }
    }

    private void Update()
    {
        // Brush Game //

        if (BrushTeethGame == true)
        {
            transform.position = MousePosition();

            if (increasing == true)
            {
                gameObject.transform.Rotate(new Vector3(0, 0, IncreaseRockValue) * Time.deltaTime);
            }

            else if(decreasing == true)
            {
                gameObject.transform.Rotate(new Vector3(0, 0, -DecreaseRockValue) * Time.deltaTime);
            }
        }
    }

    IEnumerator RockBrush()
    {
        while(true)
        {
            increasing = true;
            decreasing = false;
            yield return new WaitForSeconds(1);
            decreasing = true;
            increasing = false;
            yield return new WaitForSeconds(1);
        }
    }

    public Vector3 MousePosition()
    {
        Vector3 Depth = Input.mousePosition;
        if (ZipGame == true)
        {
            Depth.z = 5f;
        }
        else
        {
            Depth.z = 5f;
        }
        Vector3 Mouse = Camera.main.ScreenToWorldPoint(Depth);
        //Debug.Log(Mouse);
        return Mouse;
    }


    // Zip Game //

    public void Jam()
    {
        transform.position = new Vector3(0, gameObject.transform.position.y, gameObject.transform.position.z);
        if (audioSource.isPlaying == true)
        {
            audioSource.Stop();
        }
        audioSource.PlayOneShot(jammed, volume);
        Debug.Log("Jam");
        ForceDrop = true;
        StartCoroutine(LockTimerCourotine());
    }

    IEnumerator LockTimerCourotine()
    {
        while(true)
        {
            Locked = true;
            if(loaded.timesPlayed <= Threshold)
            {
                int t = loaded.timesPlayed / 5;
                int x = (int)(LockedTimer + t);
                yield return new WaitForSeconds(x);
            }
            Locked = false;
            yield break;
        }
    }
}
