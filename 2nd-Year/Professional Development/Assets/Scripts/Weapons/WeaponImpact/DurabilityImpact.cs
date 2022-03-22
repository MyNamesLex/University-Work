using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DurabilityImpact : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Item item = FindObjectOfType<Item>();
        if (item.Durability <= 0 && item.equipped == true)
        {
            InventoryScript inv = FindObjectOfType<InventoryScript>();
            inv.DropWeapon();
        }
    }
}
