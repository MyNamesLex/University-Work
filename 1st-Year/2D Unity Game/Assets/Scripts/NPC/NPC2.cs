using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class NPC2 : MonoBehaviour
{
    public MessageDisplay messageBox;
    Inventory inv;
    void BuyCallback(bool answer)
    {
        if (answer)
        {
            inv.Remove("Gold Ring", -1); //removes the gold ring from the player's inventory
            inv.Add("Scroll", 1); //adds the scroll to the players inventory
            messageBox.ShowMessage("Good luck. Remember you must quaff a blue potion before reading the scroll\n" + "I have none but I remember leaving some near a shack near the forest edge", 8.0f); // helps the player find the potion
        }
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            inv = coll.gameObject.GetComponent<Inventory>();
            bool hasGold = inv.GetCount("Gold Ring") > 0; //checks if the player has found the gold ring to continue the game
            if (hasGold)
            {
                messageBox.YesNoMessage("I can sell you a powerful scroll for that gold ring. Do you want to buy it? ", BuyCallback);
            }
            else
            {
                messageBox.ShowMessage("I have powerful magic to sell, but you have no gold!", 3.0f); //tells the player what to do next so they are not confused
            }
        }
    }
}
