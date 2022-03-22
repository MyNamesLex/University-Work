using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RandomEvent : MonoBehaviour
{ 
    public static RandomEvent _instance;

    public bool weaponlock = false;
    public bool weaponjam = false;

    public Text WeaponLockText;
    public Text WeaponLockTextUser;

    public Text WeaponJamText;
    public Text WeaponJamTextUser;

    public float TimerWeaponLockInt;
    public float TimerWeaponJamInt;

    public GameObject Mop;

    public GameObject player;

    void Awake()
    {
        if (_instance)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void EquipRandom()
    {
        int rng = Random.Range(1, 25);
        if(rng == 1)
        {
            InventoryScript inv = FindObjectOfType<InventoryScript>();
            NewPlayerMovement player = FindObjectOfType<NewPlayerMovement>();

            if(player.equippedbow == true || player.equippedmop == true || player.equippedrifle == true || player.equippedscalpel == true || player.equippedswordplayer || player.equippedswordtwo == true)
            {
                inv.DropWeapon();
            }



            GameObject MopInstance = GameObject.Instantiate(Mop) as GameObject;


            GameObject itemPickedUp = MopInstance.gameObject;
            Item item = itemPickedUp.GetComponent<Item>();

            weaponlock = true;

            inv.AddItem(itemPickedUp, item.ID, item.type, item.description, item.icon);
            inv.ItemUsage(item);
        }
        else
        {
            return;
        }
    }

    public void JamWeaponRandom()
    {
        int rng = Random.Range(1, 50);

        if(rng == 1)
        {
            weaponjam = true;
        }
        else
        {
            return;
        }
    }

    public void Update()
    {

        WeaponLockText.text = "Weapon Locked For: " + TimerWeaponLockInt;
        WeaponJamText.text = "Weapon Jammed for: " + TimerWeaponJamInt;


        //weaponlock
        if (weaponlock == true)
        {
            WeaponLockText.gameObject.SetActive(true);
            WeaponLockTextUser.gameObject.SetActive(true);
        }
        if(weaponlock == false)
        {
            WeaponLockText.gameObject.SetActive(false);
            WeaponLockTextUser.gameObject.SetActive(false);
            TimerWeaponLockInt = 10;
            weaponlock = false;
        }

        if(TimerWeaponLockInt >= 0 && weaponlock == true)
        {
            TimerWeaponLockInt -= Time.deltaTime;
        }

        if(TimerWeaponLockInt <= 0)
        {
            weaponlock = false;
        }


        //weaponjam

        if(weaponjam == true)
        {
            WeaponJamText.gameObject.SetActive(true);
            WeaponJamTextUser.gameObject.SetActive(true);
        }

        if (weaponjam == false)
        {
            WeaponJamText.gameObject.SetActive(false);
            WeaponJamTextUser.gameObject.SetActive(false);
            TimerWeaponJamInt = 10;
            weaponjam = false;
        }

        if (TimerWeaponJamInt >= 0 && weaponjam == true)
        {
            TimerWeaponJamInt -= Time.deltaTime;
        }

        if (TimerWeaponJamInt <= 0)
        {
            weaponjam = false;
        }

    }

    public void Yeet()
    {
        int rng = Random.Range(1, 1000);

        if(rng == 1)
        {
            var x = player.gameObject.GetComponent<Rigidbody>();

            x.AddForce(999, 999, 99);
        }
        else
        {
            return;
        }
    }
}
