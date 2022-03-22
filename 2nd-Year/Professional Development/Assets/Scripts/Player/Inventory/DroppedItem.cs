using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedItem : MonoBehaviour
{
    public int DroppedActiveID;
    public int DroppedHealthBonus;
    public int DroppedHealthRecover;
    public int DroppedAtkPower;
    public int DroppedDurability;
    public Sprite DroppedSprite;

    public MeshFilter current;
    public MeshRenderer currentren;

    public MeshFilter scalpel;
    public MeshRenderer scalpelren;

    public MeshFilter bow;
    public MeshRenderer bowren;

    public MeshFilter swordtwo;
    public MeshRenderer swordtworen;

    public MeshFilter rifle;
    public MeshRenderer rifleren;

    public MeshFilter mop;
    public MeshRenderer mopren;

    public MeshFilter sword;
    public MeshRenderer swordren;

    public Vector3 InstantiateOriginalPosition;

    public void Start()
    {
        NewPlayerMovement player = GetComponent<NewPlayerMovement>();
        player.transform.position = InstantiateOriginalPosition + new Vector3(2, 0, 0); ;
    }

    public void Awake()
    {
        IDGrab ID = FindObjectOfType<IDGrab>();
        Item item = FindObjectOfType<Item>();

        item.ID = ID.GrabbedActiveID;
        item.HealthBonus = ID.GrabbedHealthBonus;
        item.HealthRecover = ID.GrabbedHealthRecover;
        item.AtkPower = ID.GrabbedAtkPower;
        item.Durability = ID.GrabbedDurability;
        item.type = "Weapon";
        item.icon = ID.GrabbedSprite;

        DroppedActiveID = ID.GrabbedActiveID;
        DroppedHealthBonus = ID.GrabbedHealthBonus;
        DroppedDurability = ID.GrabbedDurability;
        DroppedAtkPower = ID.GrabbedAtkPower;
        DroppedHealthRecover = ID.GrabbedHealthRecover;
        DroppedSprite = ID.GrabbedSprite;
        

        if(ID.GrabbedActiveID == 12)
        {
            gameObject.GetComponent<Bow>().enabled = true;
        }

        else if(ID.GrabbedActiveID == 13)
        {
            gameObject.GetComponent<Rifle>().enabled = true;
        }

        else
        {
            gameObject.GetComponent<Rifle>().enabled = false;
            gameObject.GetComponent<Bow>().enabled = false;
        }

        switch (DroppedActiveID)
        {
            case 10:
                //sword player
                current.mesh = sword.mesh;
                currentren.material = swordren.material;
                break;
            case 11:
                //sword two
                current.mesh = swordtwo.mesh;
                currentren.material = swordtworen.material;
                break;
            case 12:
                //bow
                Debug.Log("bow");
                current.mesh = bow.mesh;
                currentren.material = bowren.material;
                break;
            case 13:
                //rifle
                current.mesh = rifle.mesh;
                currentren.material = rifleren.material;
                break;
            case 14:
                //scalpel
                current.mesh = scalpel.mesh;
                currentren.material = scalpelren.material;
                break;
            case 15:
                //mop
                current.mesh = mop.mesh;
                currentren.material = mopren.material;
                break;


        }
    }

}
