using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class NewPlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    Animator animator;

    public float Speed;
    public bool OnGround = true;

    public AudioSource audioSource;
    public AudioClip jumpclip;
    public AudioClip hurtclip;
    public AudioClip damagedealtclip;

    public AudioClip rifleshootsfx;
    public float volume = 0.5f;

    public GameObject[] pauseObjects;
    public GameObject Player;
    public GameObject EngineerSlot;

    public int Health;
    public int Damage;
    public int throwspeed;

    public Text HealthText;
    public Text GameOver;

    public Transform Cam;

    public bool Attack = false;
    public bool camzoomtoggle = false;

    InventoryScript Inventory;
    PlayerClass classes;

    public bool classscout;
    public bool classengineer;
    public bool classsoldier;
    public bool classjanitor;
    public bool classmedic;

    public bool equippedbow = false;
    public bool equippedswordplayer = false;
    public bool equippedswordtwo = false;
    public bool equippedscalpel = false;
    public bool equippedrifle = false;
    public bool equippedmop = false;

    public Text AmmoCountText;
    public Text ArrowCountText;

    public static NewPlayerMovement _instance;

    public int LevelCompleteInt;

    public int LevelQuantity;

    public ParticleSystem hurtparticle;

    public bool Move = true;

    void Awake()
    {
        if (_instance)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }

        HealthText.text = "Health: " + Health;

    }

    void Start()
    {
        //spawn player
        GameObject Spawn = GameObject.Find("Spawn");
        Player.transform.position = Spawn.transform.position;

        //get component
        Inventory = GetComponent<InventoryScript>();
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        //cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;

        //class chooser, getting from PlayerClass

        PlayerClass classes = FindObjectOfType<PlayerClass>();
        AmmoCollector ammo = FindObjectOfType<AmmoCollector>();

        if (classes.scout == true)
        {
            classscout = true;
            Speed = 7;
        }
        else if(classes.medic == true)
        {
            classmedic = true;
            Health = 120;
            HealthText.text = "Health: 120";
        }
        else if(classes.janitor == true)
        {
            classjanitor = true;
        }
        else if(classes.engineer == true)
        {
            classengineer = true;
        }
        else if(classes.soldier == true)
        {
            classsoldier = true;
            ammo.totalammo = 40;
        }

        if(classengineer == true)
        {
            EngineerSlot.SetActive(true);
        }

    }

    void Update()
    {
        //movement
        if (Move == true)
        {
            float Horizontal = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;
            float Vertical = Input.GetAxis("Vertical") * Speed * Time.deltaTime;

            Vector3 Movement = Cam.transform.right * Horizontal + Cam.transform.forward * Vertical;
            Movement.y = 0f;

            transform.Translate(Horizontal, 0, Vertical);

            // transform.rotation = Quaternion.Lerp(transform.rotation, CamRotation, 0.1f);

            if (Movement.magnitude != 0f)
            {
                transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Cam.GetComponent<CameraControlloer>().sensivity * Time.deltaTime);
                animator.SetBool("Running", true);
                animator.SetBool("Idle", false);

                Quaternion CamRotation = Cam.rotation;
                CamRotation.x = 0f;
                CamRotation.z = 0f;

                transform.rotation = Quaternion.Lerp(transform.rotation, CamRotation, 0.1f);
            }

            if (Movement.magnitude == 0f)
            {
                animator.SetBool("Running", false);
                animator.SetBool("Idle", true);
            }


            if (Input.GetButtonDown("Jump") && OnGround)
            {
                rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);

                OnGround = false;

                PlayJumpSound();
                animator.SetBool("Jumping", true);
            }

            //pause menu

            if (Input.GetKeyDown("p") || Input.GetKeyDown(KeyCode.Escape))
            {
                if (Time.timeScale == 1)
                {
                    Input.GetMouseButtonDown(0);
                    Time.timeScale = 0;
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.Confined;
                    showPaused();
                }
                else if (Time.timeScale == 0)
                {
                    Input.GetMouseButtonDown(0);
                    Time.timeScale = 1;
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Confined;
                    hidePaused();
                }
            }

            //left click attack button
            RandomEvent rand = FindObjectOfType<RandomEvent>();

            if (Input.GetMouseButtonDown(0) && rand.weaponjam == false)
            {

                if (equippedrifle == true)
                {
                    audioSource.PlayOneShot(rifleshootsfx, volume);
                }

                Item item = FindObjectOfType<Item>();

                if (equippedbow || equippedmop || equippedrifle || equippedscalpel || equippedswordplayer || equippedswordtwo == true)
                {
                    animator.SetBool("Attack", false);
                }
                else
                {
                    animator.SetBool("Attack", true);
                }

                //item.Durability -= 1;
                StartCoroutine(Attacking());

            }

            //Check if player is out of lives

            if (Health <= 0)
            {
                GameOver.gameObject.SetActive(true);
                animator.SetBool("Dead", true);

                StartCoroutine(WaitForAnim());
            }

            //dev restart key

            if (Input.GetKeyDown("r"))
            {
                Time.timeScale = 1;
                SceneManager.LoadScene(4);
            }

            //weapon checks for UI , ammo based

            if (equippedrifle == true)
            {
                AmmoCollector ammo = FindObjectOfType<AmmoCollector>();
                AmmoCountText.gameObject.SetActive(true);
                AmmoCountText.text = "Ammo: " + ammo.totalammo;
                animator.SetBool("equippedrifle", true);

            }

            if (equippedbow == true)
            {
                ArrowAmount arrow = FindObjectOfType<ArrowAmount>();
                ArrowCountText.gameObject.SetActive(true);
                ArrowCountText.text = "Arrows: " + arrow.totalarrows;
            }

            if (equippedrifle == false)
            {
                AmmoCountText.gameObject.SetActive(false);
                animator.SetBool("equippedrifle", false);
            }

            if (equippedbow == false)
            {
                ArrowCountText.gameObject.SetActive(false);
            }

            //Check amount of level completed

            LevelVoteBox lastlevel = FindObjectOfType<LevelVoteBox>();

            if (LevelCompleteInt == LevelQuantity)
            {
                lastlevel.LevelCompleteIntCheck = 1;
            }
        }
    }

    IEnumerator Attacking()
    {
        while(true)
        {
            Attack = true;
            yield return new WaitForSeconds(1);
            animator.SetBool("Attack", false);
            Attack = false;
            break;
        }
    }

    IEnumerator WaitForAnim()
    {
        while(true)
        {
            Move = false;
            yield return new WaitForSeconds(2);
            Cursor.visible = true;
            
            //placeholder due to dontdestroyonload weirdness, would be SceneManager.LoadScene(17);
            Application.Quit();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Ground")
        {
            OnGround = true;
            animator.SetBool("Jumping", false);
        }

        if (other.gameObject.tag == "Ramp")
        {
            OnGround = true;
            animator.SetBool("Jumping", false);
        }

        if (other.gameObject.tag == "Enemy")
        {
            RandomEvent rand = FindObjectOfType<RandomEvent>();

            if(Attack == true && rand.weaponjam == false)
            {
                PlayDamageDealtSound();
                return;
            }
            else
            {
                Stalker stal = FindObjectOfType<Stalker>();
                PlayHurtSound();
                Health -= stal.EnemyDamage;
                hurtparticle.Play();

                HealthText.text = "Health: " + Health;
            }
        }

        if (other.gameObject.tag == "ShooterEnemy")
        {
            RandomEvent rand = FindObjectOfType<RandomEvent>();

            if (Attack == true && rand.weaponjam == false)
            {
                PlayDamageDealtSound();
                return;
            }
            else
            {
                ShootEnemy shooter = FindObjectOfType<ShootEnemy>();
                PlayHurtSound();
                Health -= shooter.EnemyDamage;
                hurtparticle.Play();

                HealthText.text = "Health: " + Health;
            }
        }


        //boss ai

        if (other.gameObject.tag == "Boss")
        {
            RandomEvent rand = FindObjectOfType<RandomEvent>();

            if (Attack == true && rand.weaponjam == false)
            {
                PlayDamageDealtSound();
                return;
            }
            else
            {
                BossAI Boss = FindObjectOfType<BossAI>();
                PlayHurtSound();
                Health -= Boss.EnemyDamage;

                HealthText.text = "Health: " + Health;
            }
        }


        //Projectile Boss

        if (other.gameObject.tag == "Projectile")
        {
            BossAI Boss = FindObjectOfType<BossAI>();
            PlayHurtSound();

            Health -= Boss.ProjectileDamage;
            HealthText.text = "Health: " + Health;
        }


        //bomb throw

        if (other.gameObject.tag == "Bomb")
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                StartCoroutine(Explode());
                BossAI boss = FindObjectOfType<BossAI>();
                BombScript bomb = FindObjectOfType<BombScript>();

                Vector3 direction = other.transform.position - boss.Boss.transform.position;

                direction = -direction.normalized;
                Vector3 height = new Vector3(0, 400, 0);

                bomb.particle.Play();
                bomb.thrown = true;

                other.rigidbody.AddForce(direction * throwspeed + height);
            }
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Bomb")
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                StartCoroutine(Explode());

                BossAI boss = FindObjectOfType<BossAI>();
                BombScript bomb = FindObjectOfType<BombScript>();

                Vector3 direction = other.transform.position - boss.Boss.transform.position;

                direction = -direction.normalized;
                Vector3 height = new Vector3(0, 400, 0);

                bomb.particle.Play();
                bomb.thrown = true;

                other.rigidbody.AddForce(direction * throwspeed + height);
            }
        }
    }

    IEnumerator Explode()
    {
        while (true)
        {
            BombScript bomb = FindObjectOfType<BombScript>();
            yield return new WaitForSeconds(5);
            Destroy(bomb.Bomb);
            break;
        }
    }

    //damage assigning for each weapon

    public void CheckEquipped()
    {
        switch (Inventory.ItemID)
        {
            case 10:
                equippedswordplayer = true;
                equippedbow = false;
                equippedmop = false;
                equippedrifle = false;
                equippedswordtwo = false;
                Damage = 30;
                break;
            case 11:
                equippedswordtwo = true;
                equippedbow = false;
                equippedmop = false;
                equippedrifle = false;
                equippedscalpel = false;
                Damage = 50;
                break;
            case 12:
                equippedbow = true;
                equippedmop = false;
                equippedrifle = false;
                equippedswordplayer = false;
                equippedscalpel = false;
                Damage = 10;
                break;
            case 13:
                equippedrifle = true;
                equippedbow = false;
                equippedscalpel = false;
                equippedswordtwo = false;
                equippedmop = false;
                Damage = 60;
                break;
            case 14:
                equippedscalpel = true;
                equippedbow = false;
                equippedswordplayer = false;
                equippedswordtwo = false;
                equippedrifle = false;
                Damage = 60;
                break;
            case 15:
                equippedmop = true;
                equippedbow = false;
                equippedswordplayer = false;
                equippedswordtwo = false;
                equippedscalpel = false;
                Damage = 2;
                break;


        }
    }

    //jump sfx

    private void PlayJumpSound()
    {
        audioSource.PlayOneShot(jumpclip, volume);
        return;
    }

    private void PlayHurtSound()
    {
        audioSource.PlayOneShot(hurtclip, volume);
    }

    private void PlayDamageDealtSound()
    {
        audioSource.PlayOneShot(damagedealtclip, volume);
    }

    //pause functions
    private void showPaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            g.SetActive(true);
        }
    }

    private void hidePaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            g.SetActive(false);
        }
    }

}

