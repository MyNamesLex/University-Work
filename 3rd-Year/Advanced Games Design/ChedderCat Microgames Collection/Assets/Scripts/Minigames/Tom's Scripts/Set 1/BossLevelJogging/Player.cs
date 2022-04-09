using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D rb;
    public Vector3 boxExtents;
    public bool OnGround = false;
    public float JumpForce;
    public float maxspeed;

    public float currentspeed;
    public float IncrementSpeed;
    public float DecreaseSpeed;
    public float TimerToDecrease;
    public KeyCode key;
    public bool hitleftkey;
    public KeyCode key2;
    public MinigameAction action;
    public bool StopDupe = false;

    [Header("Persistence Handler")]
    public MinigameHandler handler;
    public bool PersistenceHandler = false;
    public bool AccessibilityMode = false;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip hit;
    public AudioClip run;
    public AudioClip jump;
    public AudioClip shoot;
    public float volume;

    [Header("Shoot")]
    public GameObject Bullet;
    public float BulletForce;
    public float CanFire;
    public float ShootRate;
    // Start is called before the first frame update
    void Start()
    {
        boxExtents = GetComponent<BoxCollider2D>().bounds.extents;
        player = gameObject;
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(TickDownIncrementSpeed());

        if (handler.persistenceHandler == null)
        {
            PersistenceHandler = false;
        }
        else
        {
            PersistenceHandler = true;
        }

        if (PersistenceHandler == true)
        {
            if (handler.persistenceHandler.Accessibility == true)
            {
                AccessibilityMode = true;
            }
            else
            {
                AccessibilityMode = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
      //  Debug.Log(rb.velocity);

        rb.AddForce(new Vector2(currentspeed, 0));


        if (AccessibilityMode == false)
        {
            if (Input.GetKeyDown(key) && hitleftkey == false)
            {
                hitleftkey = true;
                currentspeed += IncrementSpeed;
                audioSource.PlayOneShot(run, volume);
            }
            if (Input.GetKeyDown(key2) && hitleftkey == true)
            {
                hitleftkey = false;
                currentspeed += IncrementSpeed;
            }
        }

        if(Input.GetMouseButtonDown(0) && Time.time > CanFire)
        {
            CanFire = Time.time + ShootRate;
            Shoot();
            audioSource.PlayOneShot(shoot, volume);
        }

        if(AccessibilityMode == true)
        {
            AccessibilityModeFunction();
        }

        // Jump //
        if (OnGround == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(new Vector2(0, JumpForce));
                audioSource.PlayOneShot(jump, volume);
            }
        }
    }

    public void Shoot()
    {
        Vector3 gv3 = gameObject.transform.position + new Vector3(1, 0, 0);
        GameObject g = Instantiate(Bullet, gv3, transform.rotation);
        g.GetComponent<Rigidbody2D>().AddForce(new Vector2(BulletForce, 0));
    }

    public void AccessibilityModeFunction()
    {
        if (AccessibilityMode == true)
        {
            if (Input.GetMouseButton(0))
            {
                currentspeed += IncrementSpeed;
            }
        }
    }

    private void FixedUpdate()
    {
        if (rb.velocity.magnitude > maxspeed)
        {
            rb.velocity = rb.velocity.normalized * maxspeed;
        }

        Vector2 bottomHitBox =
    new Vector2(transform.position.x, transform.position.y - boxExtents.y);
        Vector2 hitBoxSize = new Vector2(boxExtents.x * 2.0f, 0.05f);

        RaycastHit2D OnGroundCast = Physics2D.BoxCast(bottomHitBox, hitBoxSize, 0.0f,
    new Vector3(0.0f, -1.0f), 0.0f, 1 << LayerMask.NameToLayer("Ground"));

        OnGround = OnGroundCast.collider != null && OnGroundCast.normal.y > 0.9f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        /*
        if (other.CompareTag("Ground") || other.CompareTag("Destructable"))
        {
            OnGround = true;
        }
        */
        if(other.CompareTag("Avoid") && StopDupe == false)
        {
            StopDupe = true;
            audioSource.PlayOneShot(hit, volume);
            action.LoseMicrogame();
        }
    }

    /*
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            OnGround = false;
        }
    }
    */
    IEnumerator TickDownIncrementSpeed()
    {
        while(true)
        {
            if(currentspeed < 0)
            {
                currentspeed = 0;
            }

            yield return new WaitForSeconds(TimerToDecrease);

            if (currentspeed >= 0)
            {
                currentspeed -= DecreaseSpeed;
            }
        }
    }
}
