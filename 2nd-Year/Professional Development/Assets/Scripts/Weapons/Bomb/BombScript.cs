using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    Rigidbody rigid;
    public ParticleSystem particle;
    public GameObject Bomb;

    public bool thrown = false;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    public void OnTriggerStay(Collider other)
    {
        if(other.tag == "Boss")
        {
            StartCoroutine(Hit());
        }
    }

    IEnumerator Hit()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            Destroy(gameObject);
        }
    }
}
