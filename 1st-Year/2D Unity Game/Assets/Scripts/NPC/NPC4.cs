using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class NPC4 : MonoBehaviour
{
    public MessageDisplay messageBox;
    Inventory inv;
    void BuyCallback(bool answer)
    {
        if (answer)
        {
            inv.Add("Silver Coins", 5);
            inv.Add("Pickaxe Shaft", 1);
            inv.Add("Scrap Metal", 5);
            messageBox.ShowMessage("Thank you! Here's your Pickaxe- Oh it broke", 2.0f);
            GameObject StoneHouseBlock = GameObject.Find("StoneHouseBlockParent"); //removes the stone blocking the path into the creepy house
            StoneHouseBlock.transform.GetChild(0).gameObject.SetActive(false);
            StoneHouseBlock.transform.GetChild(1).gameObject.SetActive(true);
        }
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            inv = coll.gameObject.GetComponent<Inventory>();
            bool hasPick = inv.GetCount("Rusty Pickaxe") > 0; //checks players inventory
            if (hasPick)
            {
                messageBox.YesNoMessage("Hey you have a pickaxe, not the best pickaxe but it will do\n " + "Can you please give me the pickaxe so i can destroy this rock? I'll give it back and reward you!", BuyCallback);
                inv.Remove("Rusty Pickaxe", -1);
            }
            else
            {
                messageBox.ShowMessage("If only i had a pickaxe...", 2.0f); //leading the player to come back to them when they have a pickaxe as the player will be walking past them to get the sword which in exchange for will recieve a pickaxe from NPC3
            }
        }
    }
}
