using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZipCollide : MonoBehaviour
{
    public MinigameAction action;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Zip"))
        {
            collision.GetComponent<DragObject>().ForceDrop = true;
            action.WinMicrogame();
            Debug.Log("Win");
        }
    }
}
