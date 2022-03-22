using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string type;
    public string description;
    public int ID;
    public Sprite icon;
    public bool pickedUp;
    public bool equipped;
    public bool playersWeapon;
    public int HealthBonus;
    public int HealthRecover;
    public int AtkPower;
    public int Durability;

    public void Awake()
    {
        IDGrab IDGrab = FindObjectOfType<IDGrab>();

        if (gameObject.tag == "Weapon")
        {
            IDGrab.GrabbedActiveID = ID;
            IDGrab.GrabbedHealthBonus = HealthBonus;
            IDGrab.GrabbedHealthRecover = HealthRecover;
            IDGrab.GrabbedAtkPower = AtkPower;
            IDGrab.GrabbedDurability = Durability;
            IDGrab.GrabbedSprite = icon;

        }
        else
        {
            return;
        }
    }
}
