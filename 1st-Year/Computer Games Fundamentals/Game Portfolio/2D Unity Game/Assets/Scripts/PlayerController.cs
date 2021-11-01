using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    float walkspeed;
    float sprintspeed;
    public Transform InventoryUI;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        walkspeed = 2.0f; //setting speeds for walking and sprinting
        sprintspeed = walkspeed * 2;
    }
    void FixedUpdate()
    {

    }
    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("xspeed", rb.velocity.x);
        anim.SetFloat("yspeed", rb.velocity.y);
        if (rb.velocity.magnitude < 0.01)
            anim.speed = 0.0f;
        else
            anim.speed = 1.0f;

        if (Input.GetKeyDown("i"))
        {
            if (InventoryUI.gameObject.active == false)
            {
                // set the text, and show
                string inv = GetComponent<Inventory>().GetInventoryString();
                InventoryUI.GetChild(1).GetComponent<Text>().text = inv;
                InventoryUI.gameObject.SetActive(true);
            }
            else
            {
                // hide the inventory
                InventoryUI.gameObject.SetActive(false);
            }
        }

        rb.velocity = new Vector2(Input.GetAxis("Horizontal"),
        Input.GetAxis("Vertical")) * walkspeed;

        if (Input.GetKeyDown("left shift")) //sprint mechanic
        {
            walkspeed = sprintspeed; //changes the walkspeed value to the sprintspeed value
            anim.speed = 2.0f; //changes the animation speed so it speeds up when sprinting
        }
        if(Input.GetKeyUp("left shift"))
        {
            walkspeed = 2.0f; //resets the speeds back to walking when the left shift key is released
            anim.speed = 1.0f; 
        }

        if (Input.GetKeyDown("right shift")) //sprint mechanic
        {
            walkspeed = sprintspeed; //changes the walkspeed value to the sprintspeed value
            anim.speed = 2.0f; //changes the animation speed so it speeds up when sprinting
        }
        if (Input.GetKeyUp("right shift"))
        {
            walkspeed = 2.0f; //resets the speeds back to walking when the left shift key is released
            anim.speed = 1.0f;
        }
    }

}