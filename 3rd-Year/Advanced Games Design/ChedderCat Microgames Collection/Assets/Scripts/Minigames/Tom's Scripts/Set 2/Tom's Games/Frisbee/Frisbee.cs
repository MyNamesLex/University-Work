using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frisbee : MonoBehaviour
{
    public MinigameAction action;
    public KeyCode key;
    public bool TossedOnce;
    public bool Catchable = false;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key) && Catchable == false && TossedOnce == true && anim.GetBool("ThrowOnce"))
        {
            Debug.Log("Lose");
            action.LoseMicrogame();
        }

        if (Input.GetKeyDown(key) && TossedOnce == false)
        {
            TossedOnce = true;
            ThrowOnce();
        }


        if(Input.GetKeyDown(key) && Catchable == true)
        {
            Debug.Log("Win");
            action.WinMicrogame();
        }
    }

    void ThrowOnce()
    {
        anim.SetBool("ThrowOnce", true);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "PersonTwo")
        {
            Catchable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "PersonTwo")
        {
            Catchable = false;
        }
    }
}
