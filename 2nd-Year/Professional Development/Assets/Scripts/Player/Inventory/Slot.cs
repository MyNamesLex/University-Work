using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour
{
    public GameObject item;
    public bool empty;
    public Sprite icon;
    public Sprite NoneSprite;
    public Transform slotIconGO;
    public string type;
    public string description;
    public int ID;
    public bool slotFull;



    public void Start()
    {
        slotIconGO = transform.GetChild(0);
        slotIconGO.GetComponent<Image>().sprite = icon;
        slotFull = false;
    }
    public void UpdateSlot()
    {
        slotIconGO.GetComponent<Image>().sprite = icon;
    }
    public void ClearSlot()
    {
        slotIconGO = null;
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            slotIconGO.GetComponent<Image>().sprite = NoneSprite;
        }
    }

}
