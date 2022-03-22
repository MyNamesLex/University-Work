using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Stalker : MonoBehaviour
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
        NewPlayerMovement playe = FindObjectOfType<NewPlayerMovement>();

        Agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        //animator = GetComponent<Animator>();

        Destination = playe.Player;
        Player = playe.Player.transform;

        timer = WanderTimer;
    }

    // Update is called once per frame
    void Update()
    {
        NewPlayerMovement playe = FindObjectOfType<NewPlayerMovement>();
        animator.SetBool("Running", true);

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
                    animator.SetBool("Running", false);
                    Agent.SetDestination(newPos);
                }
                if (newPos.magnitude != 0f)
                {
                    animator.SetBool("Idle", false);
                    animator.SetBool("Running", true);
                }
            }
        }
        else
        {
            //Agent.GetComponent<Animator>().Play("Walk");

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

    IEnumerator Wait()
    {
        while(true)
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
            if(playe.Attack == true)
            {
                EnemyHealth -= playe.Damage;
                IsStalking = true;

                StartCoroutine(StunKB());

                Vector3 knockbackVector = this.transform.position - Player.transform.position;

                Vector3 heightkb = new Vector3(0, 10, 0);

                Enemy.GetComponent<Rigidbody>().AddForce(knockbackVector + heightkb);

                hurtparticle.Play();

                PlayHurtSFX();
            }
            else
            {
                IsStalking = true;
                hurtparticle.Stop();
                StartCoroutine(Hitanim());
                PlayDamageDealSFX();
            }
        }

        if(other.tag == "Weapon")
        {
            PlayHurtSFX();
            hurtparticle.Play();
        }
    }

    IEnumerator Hitanim()
    {
        while(true)
        {
            animator.SetBool("Attack", true);
            yield return new WaitForSeconds(1);
            animator.SetBool("Attack", false);
            break;
        }
    }
    IEnumerator StunKB()
    {
        while(true)
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
