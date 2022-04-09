using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalKeeper : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public void Update()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal"), 0) * speed;
    }
    public void Caught(GameObject other)
    {
        Debug.Log("Caught: " + other.gameObject.name);
        int rng = Random.Range(0, 90);
        other.GetComponent<Rigidbody2D>().AddForce(new Vector2(rng, rng));
        other.GetComponent<Football>().isCaught = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Ball"))
        {
            Caught(other.gameObject);
        }
    }

}
