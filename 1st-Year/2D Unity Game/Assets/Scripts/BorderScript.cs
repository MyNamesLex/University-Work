using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderScript : MonoBehaviour
{
    public MessageDisplay messageBox;
    void OnTriggerEnter2D(Collider2D other)
    {
        //if the player enters the invisible item's hitbox where the entrance is to an area, execute this piece of code
        if (other.name == "Player")
        {
            messageBox.ShowMessage("The forest is too treacherous to traverse", 6.0f); //Player is also blocked by the 'Borders' Tilemap in Grid which is an invisible version of 'Buildings' in Grid
            // 'Borders' prevents the player from seeing the default blue background of unity and allows me to create a nicer looking end of the map
        }
    }
}
