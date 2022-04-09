using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BossLevelJoggingBoss : MonoBehaviour
{
    public GameObject Player;
    public GameObject Throwable;
    public float Timer;
    public Vector2 Strength;
    public float MovementStrength;
    private float OGTimer;
    public int Health;
    public int BulletDamage;
    public bool StartThrows = false;
    public TextMeshProUGUI bosshealth;
    void Start()
    {
        OGTimer = Timer;
    }

    // Update is called once per frame
    void Update()
    {
        bosshealth.text = "Health: " + Health;
        if (Timer >= 0 && StartThrows == true)
        {
            Timer -= Time.deltaTime;
        }
        else if(StartThrows == true)
        {
            ThrowObject();
            Timer = OGTimer;
        }

        if(Health <= 0)
        {
            bosshealth.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

    public void ThrowObject()
    {
        GameObject g = Instantiate(Throwable, gameObject.transform.position, gameObject.transform.rotation);
        g.GetComponent<ThrowableBossLevelJogging>().MovementStrength = MovementStrength;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Bullet"))
        {
            Health -= BulletDamage;
            Destroy(other.gameObject);
        }
    }
}
