using System.Collections;
using UnityEngine;

public class AbilitiesManager : MonoBehaviour
{
    [Header("What Type Of Ability?")]
    public bool Stun = false;
    public bool Burn = false;
    public bool AttackEnemies = false;
    public bool PoisonCircle = false;

    public string AbilityChosen;

    [Header("Tier 3 Ability Activated?")]
    public bool Tier3 = false;
    public bool Activated = false;

    [Header("Stun Stats")]
    public bool StunHappening = false;
    public float StunAvailableTimer;
    private bool OGStunAvailableTimerBool = false;
    private float OGTime;
    public float StunDurationTimer;

    [Header("Burn Stats")]
    public bool BurnHappening = false;
    public float BurnAvailableTimer;
    private bool OGBurnAvailableTimerBool = false;
    private float OGTimeBurn;
    public float BurnTick;
    public float BurnDuration;
    public float BurnIntensity;

    [Header("Attack Enemy Stats")]
    public bool AttackEnemyHappening = false;
    public float AttackAvailableTimer;
    private bool OGAttackAvailableTimerBool = false;
    public float ExplosionSize;
    public GameObject PrefabExplosion;
    private float OGTimeAttack;

    [Header("Poison Shoot Stats")]
    public bool PoisonHappening = false;
    public float PoisonAvailableTimer;
    private float OGPoisonAvailableTimer;
    private bool OGPoisonAvailableTimerBool = false;
    public float PoisionDuration;
    public float PoisonDamageTick;
    public float PoisonCircleSpeed;
    public float PoisonIntensity;
    public float CircleDuration;
    public Vector3 CircleSize;
    public GameObject PrefabPoisonCircle;

    [Header("PoisonSpawns")]
    public GameObject Pos1;
    public GameObject Pos2;
    public GameObject Pos3;
    public GameObject Pos4;
    public GameObject Pos5;

    [Header("Tier3 Abilities")]
    public bool AttackEnemyTier3Bool = false;
    public bool PoisonTier3Bool = false;
    public bool StunTier3Bool = false;
    public bool BurnTier3Bool = false;

    [Header("Enemies")]
    public GameObject NearestEnemy;
    public EnemiesOnScreen EoS;

    [Header("Player Head")]
    public GameObject PlayerHead;

    [Header("Tier")]
    public string TierString;

    public void Start()
    {
        UpdateTier();
    }
    public void Update()
    {
        // Set Timers

        if(PoisonAvailableTimer != 0 && OGPoisonAvailableTimerBool != true)
        {
            OGPoisonAvailableTimerBool = true;
            OGPoisonAvailableTimer = PoisonAvailableTimer;
        }

        if(AttackAvailableTimer != 0 && OGAttackAvailableTimerBool != true)
        {
            OGAttackAvailableTimerBool = true;
            OGTimeAttack = AttackAvailableTimer;
        }

        if(StunAvailableTimer != 0 && OGStunAvailableTimerBool != true)
        {
            OGStunAvailableTimerBool = true;
            OGTime = StunAvailableTimer;
        }

        if(BurnAvailableTimer != 0 && OGBurnAvailableTimerBool != true)
        {
            OGBurnAvailableTimerBool = true;
            OGTimeBurn = BurnAvailableTimer;
        }

        if (EoS != null)
        {
            NearestEnemy = EoS.NearestEnemy;
        }

        //Get Head Of Snake (Snake0)

        if (PlayerHead == null)
        {
            PlayerHead = GameObject.FindGameObjectWithTag("Snake0");
        }

        // Check Which This Object Is, check if it has reached tier 3
        // and set the AbilityChosen string accordingly

        if (AttackEnemies)
        {
            if (Tier3 == true)
            {
                AttackEnemyTier3Bool = true;
                AttackEnemyTierThree();
            }
            else
            {
                AttackEnemyFunction();
                AbilityChosen = "AttackEnemy";
            }
        }

        if (Burn)
        {
            if (Tier3 == true)
            {
                BurnTier3Bool = true;
                BurnTierThree();
            }
            else
            {
                BurnFunction();
                AbilityChosen = "Burn";
            }
        }

        if (Stun)
        {
            if (Tier3 == true)
            {
                StunTier3Bool = true;
                StunTierThree();
            }
            else
            {
                StunFunction();
                AbilityChosen = "Stun";
            }
        }

        if (PoisonCircle)
        {
            if (Tier3 == true)
            {
                PoisonTier3Bool = true;
                PoisonTierThree();
            }
            else
            {
                PoisonFunction();
                AbilityChosen = "PoisonCircle";
            }
        }
    }

    // Tier Abilities Excluding Tier 3 //

    // Stunned Abilities
    public void StunFunction()
    {
        if (StunAvailableTimer > 0 && NearestEnemy != null)
        {
            StunAvailableTimer -= Time.deltaTime;
        }
        else if (StunAvailableTimer <= 0 && StunHappening == false && NearestEnemy != null)
        {
            StunHappening = true;
            StartCoroutine(StunCourotine(NearestEnemy));
        }
    }

    IEnumerator StunCourotine(GameObject nearest)
    {
        nearest.GetComponent<PlaceHolderEnemy>().Stunned = true;
        nearest.GetComponent<PlaceHolderEnemy>().StunnedFunction(StunDurationTimer);

        yield return new WaitForSeconds(StunDurationTimer);
        StunAvailableTimer = OGTime;
        StunHappening = false;
        yield return null;
    }

    // Burn Abilities //

    public void BurnFunction()
    {
        if (BurnAvailableTimer > 0 && NearestEnemy != null)
        {
            BurnAvailableTimer -= Time.deltaTime;
        }
        else if (BurnAvailableTimer <= 0 && BurnHappening == false && NearestEnemy != null)
        {
            BurnHappening = true;
            BurnAvailableTimer = OGTimeBurn;
            StartCoroutine(BurnCourotine(NearestEnemy, BurnTick, BurnDuration));
        }
    }

    IEnumerator BurnCourotine(GameObject g, float burntick, float BurnDuration)
    {
        if (BurnHappening == true)
        {
            g.GetComponent<PlaceHolderEnemy>().Burning = true;
            g.GetComponent<PlaceHolderEnemy>().BurnFunction(BurnIntensity, burntick, BurnDuration);
            yield return new WaitForSeconds(BurnDuration);
            BurnHappening = false;
            yield return null;
        }
    }

    // Enemy Attack Enemy Abilities //

    public void AttackEnemyFunction()
    {
        if (AttackAvailableTimer > 0 && NearestEnemy != null)
        {
            AttackAvailableTimer -= Time.deltaTime;
        }
        else if (AttackAvailableTimer <= 0 && NearestEnemy != null && AttackEnemyHappening == false)
        {
            AttackAvailableTimer = OGTimeAttack;
            StartCoroutine(AttackEnemyCourotine(NearestEnemy, gameObject));
        }
    }

    IEnumerator AttackEnemyCourotine(GameObject g, GameObject AbilityCaster)
    {
        if (AttackEnemyHappening == false)
        {
            AttackEnemyHappening = true;
            g.GetComponent<PlaceHolderEnemy>().AttackEnemies = true;
            g.GetComponent<PlaceHolderEnemy>().AbilityCasterAttackEnemyObject = AbilityCaster;
            AttackEnemyHappening = false;
            yield return null;
        }
    }

    // Poison Abilities //

    public void PoisonFunction()
    {
        if (PoisonAvailableTimer > 0 && NearestEnemy != null)
        {
            PoisonAvailableTimer -= Time.deltaTime;
            PoisonHappening = false;
        }
        else if (PoisonAvailableTimer <= 0 && NearestEnemy != null && PoisonHappening == false)
        {
            PoisonHappening = true;
            StartCoroutine(PoisonShootTimerCourotine());
        }
    }

    IEnumerator PoisonShootTimerCourotine()
    {
        if (PoisonAvailableTimer <= 0 && PoisonHappening == true)
        {
            GameObject g;
            g = Instantiate(PrefabPoisonCircle);
            Instantiate(g);
            if(g.GetComponent<GetPoisonStats>().GetPoisonIntensity == 0)
            {
                g.GetComponent<GetPoisonStats>().GetPoisonIntensity = PoisonIntensity;
            }
            if(g.GetComponent<GetPoisonStats>().GetCircleDuration == 0)
            {
                g.GetComponent<GetPoisonStats>().GetCircleDuration = CircleDuration;
            }
            if(g.GetComponent<GetPoisonStats>().GetCircleSize == new Vector3(0,0,0))
            {
                g.GetComponent<GetPoisonStats>().GetCircleSize = CircleSize;
            }
            if(g.GetComponent<GetPoisonStats>().GetPoisonSpeed == 0)
            {
                g.GetComponent<GetPoisonStats>().GetPoisonSpeed = PoisonCircleSpeed;
            }
            if (g.GetComponent<GetPoisonStats>().GetDamageTick == 0)
            {
                g.GetComponent<GetPoisonStats>().GetDamageTick = PoisonDamageTick;
            }
            PoisonAvailableTimer = OGPoisonAvailableTimer;
            PoisonHappening = false;
            yield return null;
        }
        else
        {
            yield return null;
        }
    }

    // Tiers //

    public void UpdateTier()
    {
        switch(TierString)
        {
            case "T1":


                PoisonAvailableTimer += 12;
                PoisionDuration += 20;
                PoisonDamageTick += 0.7f;
                PoisonCircleSpeed += 10;
                PoisonIntensity += 2;
                CircleDuration += 20;
                CircleSize += new Vector3(8, 8, 8);


                AttackAvailableTimer += 10;
                ExplosionSize += 20;


                BurnAvailableTimer = 5;
                BurnTick += 0.2f;
                BurnDuration += 3;
                BurnIntensity += 2;


                StunAvailableTimer = 5;
                StunDurationTimer += 1;

                break;

            case "T2":
                PoisonAvailableTimer += 2;
                PoisionDuration += 2;
                PoisonDamageTick = 2;
                PoisonCircleSpeed += 2;
                PoisonIntensity += 2;
                CircleDuration += 2;
                CircleSize += new Vector3(2, 2, 2);


                AttackAvailableTimer += 2;
                ExplosionSize += 2;


                BurnAvailableTimer -= 0.5f;
                BurnTick = 0.2f;
                BurnDuration += 1;
                BurnIntensity += 1;


                StunAvailableTimer -= 1;
                StunDurationTimer += 2;
                break;

            case "T3":
                PoisonAvailableTimer += 2;
                PoisionDuration += 2;
                PoisonDamageTick = 2;
                PoisonCircleSpeed += 2;
                PoisonIntensity += 2;
                CircleDuration += 2;
                CircleSize += new Vector3(2, 2, 2);


                AttackAvailableTimer += 2;
                ExplosionSize += 2;


                BurnAvailableTimer -= 0.5f;
                BurnTick = 0.2f;
                BurnDuration += 1;
                BurnIntensity += 1;


                StunAvailableTimer -= 1;
                StunDurationTimer += 2;
                break;

            case "T4":
                PoisonAvailableTimer += 2;
                PoisionDuration += 2;
                PoisonDamageTick = 2;
                PoisonCircleSpeed += 2;
                PoisonIntensity += 2;
                CircleDuration += 2;
                CircleSize += new Vector3(2, 2, 2);


                AttackAvailableTimer += 2;
                ExplosionSize += 2;

                BurnAvailableTimer -= 0.5f;
                BurnTick = 0.2f;
                BurnDuration += 1;
                BurnIntensity += 1;

                StunAvailableTimer -= 1;
                StunDurationTimer += 2;
                break;

        }
    }

    // All Tier 3 Abilities //


    // Poison Tier 3 Abilities //


    public void PoisonTierThree()
    {
        if (PoisonAvailableTimer > 0 && NearestEnemy != null)
        {
            PoisonAvailableTimer -= Time.deltaTime;
            PoisonHappening = false;
        }
        else if (PoisonAvailableTimer <= 0 && NearestEnemy != null && PoisonHappening == false)
        {
            PoisonHappening = true;
            StartCoroutine(PoisonT3Courotine());
        }
    }

    IEnumerator PoisonT3Courotine()
    {
        if (PoisonAvailableTimer <= 0 && PoisonHappening == true)
        {
            GameObject g;
            g = Instantiate(PrefabPoisonCircle);
            foreach (GameObject obj in EoS.EnemiesOnScreenList)
            {
                Instantiate(g);

                int random = Random.Range(0, 4);

                switch (random)
                {
                    case 0:
                        g.transform.position = Pos1.transform.position;
                        break;
                    case 1:
                        g.transform.position = Pos2.transform.position;
                        break;
                    case 2:
                        g.transform.position = Pos3.transform.position;
                        break;
                    case 3:
                        g.transform.position = Pos4.transform.position;
                        break;
                    case 4:
                        g.transform.position = Pos5.transform.position;
                        break;
                    default:
                        g.transform.position = Pos5.transform.position;
                        break;
                }


                g.GetComponent<GetPoisonStats>().GetPoisonIntensity = PoisonIntensity;
                g.GetComponent<GetPoisonStats>().GetCircleDuration = CircleDuration;
                g.GetComponent<GetPoisonStats>().GetCircleSize = CircleSize;
                g.GetComponent<GetPoisonStats>().GetPoisonSpeed = PoisonCircleSpeed;
                g.GetComponent<GetPoisonStats>().GetDamageTick = PoisonDamageTick;
                PoisonAvailableTimer = OGPoisonAvailableTimer;
                PoisonHappening = false;
            }
            yield return null;
        }
        else
        {
            yield return null;
        }
    }


    // Enemy Attack Enemy Tier 3 Abilities //


    public void AttackEnemyTierThree()
    {
        if (AttackAvailableTimer > 0 && NearestEnemy != null)
        {
            AttackAvailableTimer -= Time.deltaTime;
        }
        else if (AttackAvailableTimer <= 0 && NearestEnemy != null && AttackEnemyHappening == false)
        {
            AttackAvailableTimer = OGTimeAttack;
            StartCoroutine(AttackEnemyT3Courotine(gameObject));
        }
    }

    IEnumerator AttackEnemyT3Courotine(GameObject Abilitycaster)
    {
        if (AttackEnemyHappening == false)
        {
            AttackEnemyHappening = true;
            foreach (GameObject obj in EoS.EnemiesOnScreenList)
            {
                Debug.Log("Running");
                obj.GetComponent<PlaceHolderEnemy>().AttackEnemies = true;
                obj.GetComponent<PlaceHolderEnemy>().AbilityCasterAttackEnemyObject = Abilitycaster;
            }
            AttackEnemyHappening = false;
            yield return null;
        }
    }


    // Burn Tier 3 Abilities //


    public void BurnTierThree()
    {
        if (BurnAvailableTimer > 0 && NearestEnemy != null)
        {
            BurnAvailableTimer -= Time.deltaTime;
        }
        else if (BurnAvailableTimer <= 0 && BurnHappening == false && NearestEnemy != null)
        {
            BurnHappening = true;
            BurnAvailableTimer = OGTimeBurn;
            StartCoroutine(BurnT3Courotine(BurnTick, BurnDuration));
        }
    }

    IEnumerator BurnT3Courotine(float burntick, float BurnDuration)
    {
        if (BurnHappening == true)
        {
            foreach (GameObject obj in EoS.EnemiesOnScreenList)
            {
                obj.GetComponent<PlaceHolderEnemy>().Burning = true;
                obj.GetComponent<PlaceHolderEnemy>().BurnFunction(BurnIntensity, burntick, BurnDuration);
            }
            yield return new WaitForSeconds(BurnDuration);
            BurnHappening = false;
            yield return null;
        }
    }



    // Stun Tier 3 Abilities //
    public void StunTierThree()
    {
        if (StunAvailableTimer > 0 && NearestEnemy != null)
        {
            StunAvailableTimer -= Time.deltaTime;
        }
        else if (StunAvailableTimer <= 0 && StunHappening == false && NearestEnemy != null)
        {
            StunHappening = true;
            StartCoroutine(StunT3Courotine());
        }
    }

    IEnumerator StunT3Courotine()
    {
        foreach (GameObject obj in EoS.EnemiesOnScreenList)
        {
            obj.GetComponent<PlaceHolderEnemy>().Stunned = true;
            obj.GetComponent<PlaceHolderEnemy>().StunnedFunction(StunDurationTimer);
        }
        yield return new WaitForSeconds(StunDurationTimer);
        StunAvailableTimer = OGTime;
        StunHappening = false;
        yield return null;
    }
}
