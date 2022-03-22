using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDGrab : MonoBehaviour
{
    public int GrabbedActiveID;
    public int GrabbedHealthBonus;
    public int GrabbedHealthRecover;
    public int GrabbedAtkPower;
    public int GrabbedDurability;
    public Sprite GrabbedSprite;

    public string weaponname;

    // Update is called once per frame
    public void Start()
    {
        switch (GrabbedActiveID)
        {
            case 10:
                weaponname = "Sword Player";
                break;
            case 11:
                weaponname = "Sword 2";
                break;
            case 12:
                weaponname = "Bow";
                break;
            case 13:
                weaponname = "Rifle";
                break;
            case 14:
                weaponname = "Scalpel";
                break;
            case 15:
                weaponname = "Mop";
                break;
        }
    }
}
