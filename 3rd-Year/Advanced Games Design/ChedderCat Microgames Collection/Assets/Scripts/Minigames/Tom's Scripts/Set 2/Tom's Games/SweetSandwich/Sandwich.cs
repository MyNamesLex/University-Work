using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sandwich : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float RightForce;
    public void Update()
    {
        rb.velocity = new Vector2(0, Input.GetAxis("Vertical")) * speed;
        rb.AddForce(new Vector2(RightForce, 0));
    }
}
