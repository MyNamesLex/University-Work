using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryScript : MonoBehaviour
{
    public bool inventoryEnabled;
    public GameObject inventoryUI;

    private int allSlots;
    public int ItemID;

    public string DroppedWeaponName;

    private GameObject[] slot;
    public GameObject weaponManager;
    public GameObject medkitManager;
    public bool playersWeapon;

    public Sprite icon;

    public Text OutOfAmmo;
 


    public bool equipped;
    GameObject slotHolder;

    GameObject ins;

    GameObject PlayerGameObject;

    Item item;

    private void Start()
    {
        NewPlayerMovement player = GetComponent<NewPlayerMovement>();
        PlayerGameObject = player.Player;

        inventoryUI = GameObject.Find("Inventory");
        slotHolder = GameObject.Find("Slot");
        ins = GameObject.Find("InstantiateItem");




        item = GetComponent<Item>();

        allSlots = 8;
        slot = new GameObject[allSlots];


        for (int i = 0; i < allSlots; i++)
        {

            slot[i] = slotHolder.transform.GetChild(i).gameObject;
            if (slot[i].GetComponent<Slot>().item == null)
                slot[i].GetComponent<Slot>().empty = true;
        }


    }
    void Update()
    {
        Slot slot = GetComponent<Slot>();
        NewPlayerMovement player = GetComponent<NewPlayerMovement>();
        PlayerGameObject = player.Player;

        //inventory toggle

        slotHolder = GameObject.Find("Slot");
        ins = GameObject.Find("InstantiateItem");


        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryEnabled = !inventoryEnabled;
            if (inventoryEnabled == true)
            {
                inventoryUI.SetActive(true);
            }
            else
            {
                inventoryUI.SetActive(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            DropWeapon();
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            SmallHeal small = FindObjectOfType<SmallHeal>();

            //check if in inventory

            small.SmallHealFunction();
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        RandomEvent randomEvent = FindObjectOfType<RandomEvent>();


        if (other.tag == "Item" && randomEvent.weaponlock == false)
        {
            GameObject itemPickedUp = other.gameObject;
            Item item = itemPickedUp.GetComponent<Item>();

            NewPlayerMovement player = GetComponent<NewPlayerMovement>();

            if (Input.GetKeyDown(KeyCode.Q))
            {
                ItemID = item.ID;
               

                player.CheckEquipped();

                AddItem(itemPickedUp, item.ID, item.type, item.description, item.icon);
                ItemUsage(item);
                DontDestroyOnLoad(other);
            }
        }
    }

    public void OnTriggerStay(Collider other)
    {
       RandomEvent randomEvent = FindObjectOfType<RandomEvent>();

        if (other.tag == "Item" && randomEvent.weaponlock == false)
        {
            GameObject itemPickedUp = other.gameObject;
            Item item = itemPickedUp.GetComponent<Item>();

            NewPlayerMovement player = FindObjectOfType<NewPlayerMovement>();

            if (Input.GetKeyDown(KeyCode.Q))
            {

                ItemID = item.ID;
             

                player.CheckEquipped();

                AddItem(itemPickedUp, item.ID, item.type, item.description, item.icon);
                ItemUsage(item);
                DontDestroyOnLoad(other);
            }
        }
    }
    public void AddItem(GameObject itemObject, int itemID, string itemType, string itemDescription, Sprite itemIcon)
    {
        for (int i = 0; i < allSlots; i++)
        {
            GameObject weapon = weaponManager.transform.GetChild(i).gameObject;
            RandomEvent randomEvent = FindObjectOfType<RandomEvent>();
            NewPlayerMovement player = GetComponent<NewPlayerMovement>();
            if (weapon.GetComponent<Item>().equipped == false)
            {
                if (slot[i].GetComponent<Slot>().type == itemType)
                {

                    //add item to slot if empty
                    itemObject.GetComponent<Item>().pickedUp = true;
                    slot[i].GetComponent<Slot>().icon = itemIcon;
                    slot[i].GetComponent<Slot>().type = itemType;
                    slot[i].GetComponent<Slot>().ID = itemID;
                    slot[i].GetComponent<Slot>().description = itemDescription;



                    itemObject.transform.parent = slot[i].transform;
                    itemObject.SetActive(false);

                    slot[i].GetComponent<Slot>().UpdateSlot();
                    DontDestroyOnLoad(itemObject);
                    //slot[i].GetComponent<Slot>().empty = false;
                    return;
                }
            }
            else
            {
                return;
            }
        }
    }

    [Obsolete]
    public void DropWeapon()
    {
        RandomEvent random = FindObjectOfType<RandomEvent>();
        NewPlayerMovement player = GetComponent<NewPlayerMovement>();
        if (random.weaponlock == false)
        {
            IDGrab Weapon = FindObjectOfType<IDGrab>();
            Slot slot = FindObjectOfType<Slot>();
            Rigidbody rigid = ins.GetComponent<Rigidbody>();
            Item item = GetComponent<Item>();

            if(player.equippedrifle == true && OutOfAmmo.gameObject.active == true)
            {
                OutOfAmmo.gameObject.SetActive(false);
            }

            switch (Weapon.weaponname)
            {
                case "Sword Player":
                    DroppedWeaponName = "Sword Player";
                    player.equippedswordplayer = false;
                    break;
                case "Sword 2":
                    DroppedWeaponName = "Sword 2";
                    player.equippedswordtwo = false;
                    break;
                case "Bow":
                    DroppedWeaponName = "Bow";
                    player.equippedbow = false;
                    break;
                case "Rifle":
                    DroppedWeaponName = "Rifle";
                    player.equippedrifle = false;
                    break;
                case "Scalpel":
                    DroppedWeaponName = "Scalpel";
                    player.equippedscalpel = false;
                    break;
                case "Mop":
                    DroppedWeaponName = "Mop";
                    player.equippedmop = false;
                    break;

            }


            DroppedItem droppos = FindObjectOfType<DroppedItem>();
            ins.transform.position = player.transform.position + new Vector3(2, 0, 0);
            ins.SetActive(true);
            Instantiate(ins);
            DontDestroyOnLoad(ins);

            ins.transform.position = droppos.InstantiateOriginalPosition;

            for (int i = 0; i < allSlots; i++)
            {
                GameObject weapon = weaponManager.transform.GetChild(i).gameObject;
                weapon.SetActive(false);
                weapon.GetComponent<Item>().equipped = false;
                slot.slotFull = false;
            }
            return;
        }
    }

    public void MedkitUsage(Item item)
    {
        for (int i = 0; i < allSlots; i++)
        { 
                if (medkitManager.transform.GetChild(i).gameObject.GetComponent<Item>().ID == item.ID)
                {
                    GameObject medkit = medkitManager.transform.GetChild(i).gameObject;
                    NewPlayerMovement player = FindObjectOfType<NewPlayerMovement>();
                    medkit.GetComponent<Item>().equipped = false;
                }
            
        }
    }

    public void ItemUsage(Item item)
    {
        //Weapon
        Slot slot = FindObjectOfType<Slot>();
        if (item.type == "Weapon")
        {
            for (int i = 0; i < allSlots; i++)
            {
                GameObject weapon = weaponManager.transform.GetChild(i).gameObject;
                if(slot.slotFull == false)
                {
                    weaponManager = GameObject.FindWithTag("WeaponManager");

                    int allWeapons = weaponManager.transform.childCount;
                    for (int j = 0; j < allWeapons; j++)
                    {
                        if (weaponManager.transform.GetChild(i).gameObject.GetComponent<Item>().ID == item.ID)
                        {
                            weapon.SetActive(true);
                            weapon.GetComponent<Item>().equipped = true;
                            slot.slotFull = true;
                            slot.GetComponent<Slot>().ClearSlot();
                        }
                    }
                }
                else
                {
                    return;
                }
            }
 
        }

        //Medkit
        if (item.type == "MedKit")
        {
            for (int i = 0; i < allSlots; i++)
            {
                medkitManager = GameObject.FindWithTag("MedKitManager");

                int allMedkit = medkitManager.transform.childCount;
                for (int j = 0; j < allMedkit; j++)
                {
                    if(Input.GetKeyDown(KeyCode.E))
                        if (medkitManager.transform.GetChild(i).gameObject.GetComponent<Item>().ID == item.ID)
                        {
                            GameObject medkit = medkitManager.transform.GetChild(i).gameObject;
                            NewPlayerMovement player = FindObjectOfType<NewPlayerMovement>();
                            player.Health += GetComponent<Item>().HealthRecover;
                            medkit.GetComponent<Item>().equipped = false;
                        }
                }
            }

        }

        //Throwable

        //Armor


    }



}
