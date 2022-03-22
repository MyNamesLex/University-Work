using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseEasyLevel : MonoBehaviour
{
    public Animation anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();
    }

    // Update is called once per frame
    public void OnTriggerEnter(Collider other)
    {
        anim.Play("open");
        anim.Stop();
        Debug.Log("open;");
        return;
    }

    public void OnTriggerExit(Collider other)
    {
        anim.Play("close");
        anim.Stop();
        Debug.Log("close;");
        return;
    }
}
