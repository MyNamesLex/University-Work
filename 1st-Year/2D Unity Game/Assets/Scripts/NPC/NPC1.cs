using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class NPC1 : MonoBehaviour
{
    MessageDisplay messageBox;
    void Start()
    {
        messageBox = GameObject.Find("MessageHandler").GetComponent<MessageDisplay>();
    }
    void MagicCallback(bool answer)
    {
            // find the stone in the world
            GameObject stone = GameObject.Find("StoneParent");
            stone.transform.GetChild(0).gameObject.SetActive(false);
            stone.transform.GetChild(1).gameObject.SetActive(true);
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Inventory inv = coll.gameObject.GetComponent<Inventory>();
            bool hasScroll = inv.GetCount("Scroll") > 0;
            bool hasPotion = inv.GetCount("Potion") > 0;
            bool hasGoldRing = inv.GetCount("Gold Ring") > 0;
            if (!hasScroll && !hasPotion)
            {
                messageBox.ShowMessage(
                "You want to cross the river? This stone has been here many years\n" +
                "It is too heavy for any on the island to move. Only magic will move it.\n" +
                "There is a lady nearby who may help, but she will need to be paid",
               10.0f);
            }
            if (hasScroll && !hasPotion) //different responses based of the players inventory
            {
                messageBox.ShowMessage("Ah, you have the scroll but it is useless without quaffing the blue potion.\n You must find the blue potion",4.0f);
            }
            else if (hasScroll && hasPotion)
            {
                messageBox.YesNoMessage("Aha, you have the magic to move the stone. Would you like to quaff the potion and read the scroll? ", MagicCallback);
                inv.Remove("Potion", -1);
                inv.Remove("Scroll", -1);
            }

            if (hasPotion && hasGoldRing)
            {
                messageBox.ShowMessage("Aha, you have the potion but it is useless without the scroll.\n You must find the lady and sell the gold ring you have to her for the scroll", 4.0f);
            }
        }
    }
    void AnswerFunc(bool answer)
    {
        if (answer)
            messageBox.ShowMessage("Glad to hear it!", 3.0f);
        else
            messageBox.ShowMessage("Cheer up, it could be worse!", 3.0f);
    }


}
