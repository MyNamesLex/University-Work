using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class NPC3 : MonoBehaviour
{
    public MessageDisplay messageBox;
    Inventory inv;
    void BuyCallback(bool answer)
    {
        bool hasSword = inv.GetCount("Rusty Sword") > 0; //checks what the player has in the inventory
        bool hasPickaxe = inv.GetCount("Rusty Pickaxe") > 0;
        bool hasAPickaxe = inv.GetCount("Average Pickaxe") > 0;
        bool hasSilverCoins = inv.GetCount("Silver Coins") > 0;

        if (answer && hasSilverCoins && !hasPickaxe && !hasSword) // different responses based of the players inventory
        {
            messageBox.ShowMessage("Here you go", 2.0f);
            inv.Remove("Silver Coins", -1);
            inv.Add("Average Pickaxe", 1);
        }

        if (answer && hasSword)
        {
            messageBox.ShowMessage("Oh you found it thank you so much! Here is your reward!", 3.0f);
            inv.Remove("Rusty Sword", -1);
            inv.Add("Gold Coins", 10);
            inv.Add("Rusty Pickaxe", 1);
        }
        if (answer && !hasSword && !hasPickaxe && !hasSilverCoins && !hasAPickaxe)     
        {
            messageBox.ShowMessage("Thank you so much kind stranger! Good luck!", 2.0f);
        }
        if (answer && hasAPickaxe)
        {
            messageBox.ShowMessage("Your Welcome");
        }
}
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            inv = coll.gameObject.GetComponent<Inventory>();
            bool hasSilverCoins = inv.GetCount("Silver Coins") > 0; //checks what the player has in the inventory
            bool hasSword = inv.GetCount("Rusty Sword") > 0;
            bool hasAPickaxe = inv.GetCount("Average Pickaxe") > 0;
            if (hasSword && !hasSilverCoins)
            {
                messageBox.ShowMessage("Oh you found it thank you so much!" + "Here is your reward!", 3.0f);
                inv.Remove("Rusty Sword", -1);
                inv.Add("Gold Coins", 10);
                inv.Add("Rusty Pickaxe", 1);
            }
            if (!hasSword)
            {
                messageBox.YesNoMessage("Dear stranger, can you please help me? Can you go and find my sword? I remember it being around here somewhere...", BuyCallback);
            }

            if (hasSilverCoins && !hasSword) //using items in the inventory to have responses to the progression and what is happening in the quest
            {
                messageBox.YesNoMessage("Wait he broke your pickaxe!? Want another one?", BuyCallback);
            }
            if (hasSword && hasAPickaxe)
            {
                messageBox.ShowMessage("Hi friend");
            }
        }
    }
}
