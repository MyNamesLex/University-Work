using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableBossLevelJogging : MonoBehaviour
{
    public float MovementStrength;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        else
        {
           transform.position = Vector2.MoveTowards(gameObject.transform.position, player.transform.position, MovementStrength * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
