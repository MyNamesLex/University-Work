using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class NPCWitch : MonoBehaviour
{
    MessageDisplay messageBox;
    void Start()
    {
        messageBox = GameObject.Find("MessageHandler").GetComponent<MessageDisplay>();
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Inventory inv = coll.gameObject.GetComponent<Inventory>();
            messageBox.ShowMessage("Leave this place, now", 4.0f); //little easter egg character
        }
    }
}
