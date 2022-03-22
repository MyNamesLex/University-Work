using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rifle : MonoBehaviour
{
    public int damage = 10;
    public int range = 100;
    public float fireRate = 15f;
    public float impactForce = 30f;

    public float nextTimeToFire = 0f;

    private LayerMask playerLayer;

    public int ammo;

    public Text OutOfAmmo;
    public AudioClip playRifleSnd;
    public float volume = 0.5f;
    public AudioSource audioSource;
    public AudioClip outofAmmoSFX;

    public ParticleSystem fireparticle;
    
    private void Update()
    {
        AmmoCollector ammocollector = FindObjectOfType<AmmoCollector>();

        NewPlayerMovement player = FindObjectOfType<NewPlayerMovement>();

        RandomEvent rand = FindObjectOfType<RandomEvent>();

        ammo = ammocollector.totalammo;

        if (Input.GetMouseButtonDown(0) && ammo == 0)
        {
            StartCoroutine(AlertOutOfAmmo());
            audioSource.PlayOneShot(outofAmmoSFX, volume);
        }

        if (Input.GetMouseButtonDown(0) && Time.time >= nextTimeToFire && player.equippedrifle == true && ammo != 0 && rand.weaponjam == false)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            fireparticle.transform.rotation = player.transform.rotation;
            fireparticle.transform.position = player.transform.position;
            fireparticle.Play();
            audioSource.PlayOneShot(playRifleSnd, volume);
            Shoot();
        }
    }

    IEnumerator AlertOutOfAmmo()
    {
        while(true)
        {
            bool seen = false;
            if(seen == false)
            {
                OutOfAmmo.gameObject.SetActive(true);
                seen = true;
                yield return new WaitForSeconds(2);
                seen = false;
                OutOfAmmo.gameObject.SetActive(false);
                break;
            }
        }
    }

    void Shoot()
    {
        CameraControlloer camera = FindObjectOfType<CameraControlloer>();
        NewPlayerMovement player = FindObjectOfType<NewPlayerMovement>();
        RaycastHit hit;
        if (Physics.Raycast(player.transform.position, player.transform.forward, out hit, range))
        {
            AmmoCollector ammocollector = FindObjectOfType<AmmoCollector>();

            if(ammocollector.totalammo != 0)
            {
                ammocollector.totalammo -= 1;
            }

            Debug.Log(hit.transform.name);

            Stalker target = hit.transform.GetComponent<Stalker>();
            ShootEnemy shootEnemy = hit.transform.GetComponent<ShootEnemy>();

            if (hit.transform.name == "EnemyContainer")
            {
                target.hurtparticle.Play();
                target.EnemyHealth -= damage;
            }

            if (hit.transform.name == "ShootyEnemyContainer")
            {
                shootEnemy.hurtparticle.Play();
                shootEnemy.EnemyHealth -= damage;
            }


            if (target != null)
            {
                target.EnemyHealth -= damage;
            }
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
        }
    }

    public void RifleSnd()
    {
        audioSource.PlayOneShot(playRifleSnd, volume);
    }
}
