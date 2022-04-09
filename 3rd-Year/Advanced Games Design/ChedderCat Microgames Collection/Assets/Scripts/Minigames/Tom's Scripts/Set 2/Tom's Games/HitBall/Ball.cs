using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Ball : MonoBehaviour
{
    [Header("Scene Requirements")]
    public MinigameAction action;

    [Header("Input Key")]
    public KeyCode key;

    [Header("Sprite Renderer")]
    public SpriteRenderer spriteRenderer;

    [Header("Increments")]
    public float RotateValue;
    public float IncreaseSizeTimer;

    [Header("Starter Transform Sizes")]
    public float startxSize;
    public float startySize;
    public float startzSize;

    [Header("Increase Transform Size Values")]
    public float increaseXSize;
    public float increaseYSize;
    public float increaseZSize;

    [Header("Current Transform Sizes")]
    public float xSize;
    public float ySize;
    public float zSize;

    [Header("When To Hit")]
    public float xSizeHitSpotLow;
    public float xSizeHitSpotHigh;

    public float ySizeHitSpotLow;
    public float ySizeHitSpotHigh;

    public float zSizeHitSpotLow;
    public float zSizeHitSpotHigh;

    [Header("Debug Values Don't Alter :)")]

    public float xSizeHitZone;
    public float ySizeHitZone;
    public float zSizeHitZone;

    public bool CanHitX = false;
    public bool CanHitY = false;
    public bool CanHitZ = false;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.localScale = new Vector3(startxSize, startySize, startzSize);
        StartCoroutine(IncreaseSize());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, RotateValue) * Time.deltaTime);

        // Hit Zones - Gets The SizeHitZones for x, y and z transform sizes for the Hit Times // - Tom

        xSizeHitZone = Mathf.Clamp(xSize, xSizeHitSpotLow, xSizeHitSpotHigh);
        ySizeHitZone = Mathf.Clamp(ySize, ySizeHitSpotLow, ySizeHitSpotHigh);
        zSizeHitZone = Mathf.Clamp(zSize, zSizeHitSpotLow, zSizeHitSpotHigh);

        // Hit Times // - Tom

        if (xSizeHitZone < xSizeHitSpotHigh && xSizeHitZone > 0.81)
        {
            CanHitX = true;
        }
        else
        {
            CanHitX = false;
        }

        if(ySizeHitZone < ySizeHitSpotHigh && ySizeHitZone > 0.81)
        {
            CanHitY = true;
        }
        else
        {
            CanHitY = false;
        }

        if(zSizeHitZone < zSizeHitSpotHigh && zSizeHitZone > 0.81)
        {
            CanHitZ = true;
        }
        else
        {
            CanHitZ = false;
        }

        //If CanHit x, y and z are all true (aka there in there hitzone's) if player swings within this zone they win
        //otherwise player loses - Tom

        if(CanHitX && CanHitY && CanHitZ)
        {
            spriteRenderer.color = new Color(0, 255, 0);
            if (Input.GetKeyDown(key))
            {
                Debug.Log("Won");
                action.WinMicrogame();
            }
        }
        else
        {
            spriteRenderer.color = new Color(255, 255, 255);
            if (Input.GetKeyDown(key))
            {
                Debug.Log("Lost");
                action.LoseMicrogame();
            }
        }
    }

    IEnumerator IncreaseSize()
    {
        while(true)
        {
            yield return new WaitForSeconds(IncreaseSizeTimer);

            xSize += increaseXSize;
            ySize += increaseYSize;
            zSize += increaseZSize;

            gameObject.transform.localScale = new Vector3(xSize, ySize, zSize);
        }
    }
}
