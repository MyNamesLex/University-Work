using System.Collections;
using UnityEngine;

public class PlaceHolderEnemy : MonoBehaviour
{
    public GameObject PlayerHead;
    [Header("Enemy Stats")]
    public float speed;
    public float Health = 100;
    public float DamageFloat = 10;
    [Header("Add To Enemies List")]
    public GameObject EoS;
    public bool Added = false;

    [Header("Effects")]
    public bool Stunned;
    public bool AttackEnemies;
    private GameObject attackobject;
    public bool InPoisonCircle;
    public bool Burning;
    public GameObject AbilityCasterAttackEnemyObject;
    public GameObject ExplodeObject;
    public bool StopExplosionDupe = false;
    public bool StopExplosionDupeSpawnExplosions = false;

    [Header("Snake Manager")]
    public GameObject sm;
    // Update is called once per frame

    // sets a random speed and finds the playerhead
    public void Start()
    {
        speed = Random.Range(1, 2);
        PlayerHead = GameObject.FindGameObjectWithTag("Snake0");
    }

    //gets the enemiesonscreenlist and adds the enemy to it

    void Update()
    {
        if (EoS == null)
        {
            EoS = GameObject.FindGameObjectWithTag("EnemiesOnScreen");
        }
        if (EoS != null && Added == false)
        {
            Added = true;
            EoS.GetComponent<EnemiesOnScreen>().EnemiesOnScreenList.Add(gameObject);
        }

        if (PlayerHead == null)
        {
            PlayerHead = GameObject.FindGameObjectWithTag("Snake0");
        }
        else
        {
            GoToPlayer();
        }

        if (sm == null)
        {
            sm = GameObject.FindGameObjectWithTag("SnakeManager");
        }

        if (Health <= 0)
        {
            if (sm != null)
            {
                sm.GetComponent<SnakeManager>().Gold++;
            }
            if (EoS != null)
            {
                EoS.GetComponent<EnemiesOnScreen>().EnemiesOnScreenList.Remove(gameObject);
            }
            Destroy(gameObject);
        }
    }

    //Get Functions

    public float GetDamage()
    {
        return DamageFloat;
    }

    //Burn Functions

    public void BurnFunction(float Intensity, float BurnTick, float BurnDuration)
    {
        if (Burning == true)
        {
            StartCoroutine(BurnCourotine(Intensity, BurnTick));
            StartCoroutine(BurnDurationCourotine(BurnDuration));
        }
    }

    IEnumerator BurnDurationCourotine(float BurnDuration)
    {
        if (Burning == true)
        {
            yield return new WaitForSeconds(BurnDuration);
            Burning = false;
            yield return null;
        }
        yield return null;
    }

    IEnumerator BurnCourotine(float Intensity, float BurnTick)
    {
        if (Burning == true)
        {
            Damage(Intensity);
            yield return new WaitForSeconds(BurnTick);
            if (Burning == false)
            {
                yield return null;
            }
        }
        else
        {
            yield return null;
        }
    }

    public void GoToPlayer()
    {
        //head straight to the playershead if it is not currently stunned and not targetting other enemies

        if (Stunned == false && AttackEnemies != true)
        {
            transform.position = Vector2.MoveTowards(transform.position, PlayerHead.transform.position, speed * Time.deltaTime);
        }

        //if the attackenemies ability has been used, do not go for the player but other enemies

        if (AttackEnemies == true)
        {
            if (attackobject == null)
            {
                attackobject = EoS.GetComponent<EnemiesOnScreen>().NearestEnemy;
                // get nearest enemy to the player to ensure this ability is useful at saving the player
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, attackobject.transform.position, speed * Time.deltaTime);
                //if this is the only enemy on the screen ignore the ability and target the player
            }
        }
    }

    //Attack Enemy Functions

    public void AttackedEnemy()
    {
        if (StopExplosionDupeSpawnExplosions == false)
        {
            StartCoroutine(StopDupeCourotines());
        }
    }

    IEnumerator StopDupeCourotines()
    {
        StopExplosionDupeSpawnExplosions = true;

        ExplodeObject = Instantiate(AbilityCasterAttackEnemyObject.GetComponent<AbilitiesManager>().PrefabExplosion);
        Instantiate(ExplodeObject);

        ExplodeObject.GetComponent<ExplosionRadius>().Explode(gameObject, AbilityCasterAttackEnemyObject);
        yield return null;
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Explosion")
        {
            Damage(100);
        }
        if (other.gameObject.tag == "Enemy" && AttackEnemies == true && StopExplosionDupe == false)
        {
            AttackedEnemy();
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy" && AttackEnemies == true && StopExplosionDupe == false)
        {
            AttackedEnemy();
        }
    }

    //Stun Functions

    public void StunnedFunction(float timer)
    {
        StartCoroutine(StunCourotine(timer));
    }

    private IEnumerator StunCourotine(float timer)
    {
        Stunned = true;
        yield return new WaitForSeconds(timer);
        Stunned = false;
        yield return new WaitForSeconds(0);
    }

    public void Damage(float damage)
    {
        Debug.Log("Damage Dealt To Enemy = " + damage);
        Health -= damage;
    }

}
