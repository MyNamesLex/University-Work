using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class ShootEnemy : MonoBehaviour
{
    GameObject Destination;
    public GameObject Enemy;

    private NavMeshAgent Agent;

    Transform Player;

    Rigidbody rb;

    public Animator animator;

    public AudioSource audioSource;
    public AudioClip hurtclip;
    public AudioClip damagedealtclip;
    public float volume = 0.5f;

    public static bool IsStalking;

    private float timer;

    public float Radius;
    public float WanderTimer;

    public int EnemyHealth;
    public int EnemyDamage;

    public ParticleSystem hurtparticle;
    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("Running", true);

        NewPlayerMovement playe = FindObjectOfType<NewPlayerMovement>();

        Agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();

        Destination = playe.Player;
        Player = playe.Player.transform;

        timer = WanderTimer;
    }

    // Update is called once per frame
    void Update()
    {
        NewPlayerMovement playe = FindObjectOfType<NewPlayerMovement>();
        if (IsStalking == false)
        {
            timer += Time.deltaTime;

            if (timer >= WanderTimer)
            {
                Vector3 newPos = RandomNavSphere(transform.position, Radius, -1);
                Agent.SetDestination(newPos);

                timer = 0; //walk timer reset

                if (newPos.magnitude == 0f)
                {
                    animator.SetBool("Idle", true);
                    Agent.SetDestination(newPos);
                }
                if (newPos.magnitude != 0f)
                {
                    animator.SetBool("Idle", false);
                }
            }
        }
        else
        {

            Shoot();

            Vector3 newPos = RandomNavSphere(transform.position, Radius, -1);
            Agent.SetDestination(newPos);

            Agent.SetDestination(Destination.transform.position);
            transform.LookAt(Player);
        }


        if (EnemyHealth <= 0)
        {
            hurtparticle.Play();
            StartCoroutine(Wait());
        }
    }

    public void Shoot()
    {
        NewPlayerMovement player = FindObjectOfType<NewPlayerMovement>();
        RaycastHit hit;

        int rng = Random.Range(1, 50);
        if (rng == 1)
        {

            if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, 100))
            {

                Debug.Log("enemy shoot" + hit.transform.name);

                NewPlayerMovement target = hit.transform.GetComponent<NewPlayerMovement>();

                if (hit.transform.name == "Player" || hit.transform.name == "Player")
                {
                    target.hurtparticle.Play();

                }

                if (target != null)
                {
                    target.Health -= 2;
                    target.HealthText.text = "Health: " + target.Health;
                    return;
                }
                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * 2);
                    return;
                }
            }
        }
    }

    IEnumerator Wait()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            Destroy(Enemy);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //-1 health every time player attacks
        NewPlayerMovement playe = FindObjectOfType<NewPlayerMovement>();
        CameraControlloer cam = FindObjectOfType<CameraControlloer>();

        if (other.gameObject.name == "Player")
        {
            if (playe.Attack == true)
            {
                EnemyHealth -= playe.Damage;
                IsStalking = true;

                StartCoroutine(StunKB());


                hurtparticle.Play();

                PlayHurtSFX();
            }
            else
            {
                IsStalking = true;
                PlayDamageDealSFX();
            }
        }

        if (other.tag == "Weapon")
        {
            PlayHurtSFX();
            hurtparticle.Play();
        }
    }
    IEnumerator StunKB()
    {
        while (true)
        {
            rb.Sleep();
            yield return new WaitForSeconds(1);
            rb.WakeUp();
            Agent.SetDestination(Player.transform.position);
            break;
        }
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float distance, int layermask)
    {
        Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * distance;

        randomDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randomDirection, out navHit, distance, layermask);

        return navHit.position;
    }


    //SFX commands
    public void PlayHurtSFX()
    {
        audioSource.PlayOneShot(hurtclip, volume);
    }
    public void PlayDamageDealSFX()
    {
        audioSource.PlayOneShot(damagedealtclip, volume);
    }
}
