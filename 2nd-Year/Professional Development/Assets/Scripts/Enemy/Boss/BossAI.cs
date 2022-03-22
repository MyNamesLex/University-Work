using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class BossAI : MonoBehaviour
{
    GameObject Destination; //set to player in unity
    public GameObject Enemy;

    private NavMeshAgent Agent; //pathfinding

    Transform Player; //players position

    public Animator animator;

    public AudioSource audioSource;
    public AudioClip hurtclip;
    public AudioClip damagedealtclip;
    public float volume = 0.5f;

    private float timer;

    public float Radius; //range he can walk around in
    public float WanderTimer; //how long he goes for walking to that place for

    public int EnemyHealth;
    public int EnemyDamage;

    //projectile damage throw
    public int ProjectileDamage;

    public GameObject Throw;

    private Vector3 t = new Vector3(0, 0, 200);

    public Transform Boss;

    public bool stop;

    Vector3 MoveThrow = new Vector3(200, 0, 0);


    // Start is called before the first frame update
    void Start()
    {
        NewPlayerMovement playe = FindObjectOfType<NewPlayerMovement>();

        Agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        Destination = playe.Player;
        Player = playe.Player.transform;

        timer = WanderTimer; //timer equals how long he goes for walking to that place for
    }

    // Update is called once per frame
    void Update()
    {
        NewPlayerMovement playe = FindObjectOfType<NewPlayerMovement>();
        Debug.Log(playe.Damage);

        animator.SetBool("Running", true);


        Vector3 newPos = RandomNavSphere(transform.position, Radius, -1);
        Agent.SetDestination(newPos);
        
        Agent.SetDestination(Destination.transform.position);  //go to the player
        
        transform.LookAt(Player); //look at player


        //health check if health is 0
        if (EnemyHealth <= 0)
        {
            SceneManager.LoadScene(15);
            Destroy(Enemy); //dies
        }

        //Projectile throw

        StartCoroutine(ProjectileThrow());

        if(stop == true)
        {
            StartCoroutine(Timer());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //-1 health every time player attacks
        NewPlayerMovement playe = FindObjectOfType<NewPlayerMovement>();

        if (other.gameObject.name == "Player" || other.tag == "Weapon")
        {
            if (playe.Attack == true)
            {
                EnemyHealth -= playe.Damage;
                PlayHurtSFX();
            }

            else if(other.tag == "Weapon")
            {
                PlayHurtSFX();
            }

            else
            {
                animator.SetBool("Attack", true);
                PlayDamageDealSFX();
            }
        }

        if (other.gameObject.tag == "Bomb")
        {
            BombScript bomb = FindObjectOfType<BombScript>();
            if (bomb.thrown == true)
            {
                EnemyHealth -= 50;
            }
        }
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float distance, int layermask)
    {
        Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * distance;
        //random position multiplied by the distance allocated for 
        //enemy to move around within

        randomDirection += origin; //random direction plus where the enemy currently is

        NavMeshHit navHit;

        NavMesh.SamplePosition(randomDirection, out navHit, distance, layermask);

        return navHit.position;
    }


    public Vector3 BossThrowPosition()
    {
        Vector3 Throwaway = Throw.transform.position = Boss.transform.position;

        Vector3 MoveThrowPos = new Vector3(200, 0, 0);

        return Throwaway + MoveThrowPos;
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


    //Projectile throws

    IEnumerator ProjectileThrow()
    {
        while (true)
        {
            if (Throw != null)
            {
                Rigidbody rigid = Throw.GetComponent<Rigidbody>();
                {
                    yield return new WaitForSeconds(5);
                    if (stop == false)
                    {
                        if(Throw != null)
                        {
                            Throw.SetActive(true);
                            Instantiate(Throw);

                            BossThrowPosition();

                            stop = true;

                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                    break;
                }
            }
            else
            {
                break;
            }
        }
    }

    IEnumerator Timer()
    {
        while(true)
        {
            yield return new WaitForSeconds(10);
            stop = false;
            break;
        }
    }
}
