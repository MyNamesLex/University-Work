using System.Collections;
using UnityEngine;

public class GetPoisonStats : MonoBehaviour
{
    [Header("Stats")]
    public float GetPoisonIntensity;
    public float GetCircleDuration;
    public Vector3 GetCircleSize;
    public float GetPoisonSpeed;
    public float GetDamageTick;

    [Header("Check For Enemies")]
    public bool EnemyInCircle = false;
    private Rigidbody2D rb;


    public void Start()
    {
        transform.localScale = GetCircleSize;
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(CircleTimer());
    }

    // Update is called once per frame
    void Update()
    {
        // Move Forward //
        if (rb.velocity.magnitude > GetPoisonSpeed)
        {
            rb.velocity = rb.velocity.normalized * GetPoisonSpeed;
        }
        else
        {
            rb.velocity = transform.right * GetPoisonSpeed * Time.fixedDeltaTime;
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            EnemyInCircle = true;
            other.GetComponent<PlaceHolderEnemy>().InPoisonCircle = true;
            StartCoroutine(DamageTick(other.gameObject));
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.GetComponent<PlaceHolderEnemy>().InPoisonCircle = false;
            EnemyInCircle = false;
        }
    }

    // deals damage if the enemies are in the circle

    IEnumerator DamageTick(GameObject g)
    {
        if (g != null)
        {
            yield return new WaitForSeconds(GetDamageTick);
            if (g != null)
            {
                g.GetComponent<PlaceHolderEnemy>().Damage(GetPoisonIntensity);
            }
            yield return new WaitForSeconds(GetDamageTick);
        }
    }

    //gets the circle duration and when its finished
    //waiting destroys itself

    IEnumerator CircleTimer()
    {
        if (GetCircleDuration <= 0)
        {
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(CircleTimer());
            yield return null;
        }
        else
        {
            yield return new WaitForSeconds(GetCircleDuration);
            Debug.Log("Destroyed Poison Circle");
            Destroy(gameObject);
            yield return null;
        }
    }
}
