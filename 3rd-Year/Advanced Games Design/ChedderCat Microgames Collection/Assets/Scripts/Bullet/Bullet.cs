using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float TimeOutTimer;
    private void Start()
    {
        StartCoroutine(Timeout());
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Destructable"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        if(other.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
        if (other.CompareTag("Avoid"))
        {
            Destroy(gameObject);
        }
    }
    IEnumerator Timeout()
    {
        yield return new WaitForSeconds(TimeOutTimer);
        Destroy(gameObject);
    }
}
