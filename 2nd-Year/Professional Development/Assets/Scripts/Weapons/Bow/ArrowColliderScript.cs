using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowColliderScript : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        Stalker stalker = FindObjectOfType<Stalker>();
        ShootEnemy shootenemy = FindObjectOfType<ShootEnemy>();
        if (other.tag == "Enemy")
        {
            stalker.EnemyHealth -= 20;
        }

        if (other.tag == "ShooterEnemy")
        {
            shootenemy.EnemyHealth -= 20;
        }
    }
}
