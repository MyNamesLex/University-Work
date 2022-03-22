using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerTextTrigger : MonoBehaviour
{
    public Text PickUpText;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameObject itemPickedUp = other.gameObject;
            Item item = itemPickedUp.GetComponent<Item>();
        }
    }
}
