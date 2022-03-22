using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayerClassScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        while(true)
        {
            var g = GameObject.Find("PlayerClass");
            yield return new WaitForSeconds(1);
            Destroy(g);
            Destroy(this);
        }
    }
}
