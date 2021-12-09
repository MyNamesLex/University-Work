using UnityEngine;

public class SnakeController : MonoBehaviour
{
    private Rigidbody2D rb;

    [Header("Player Control")]
    public float speed;
    public float turnspeed;
    public int wallpushforce;

    [Header("Health")]
    public int Health = 100;

    [Header("EnemyPrefabs")]
    public GameObject PlaceHolderEnemy;

    [Header("AbilityManager")]
    public UpgradeRNGButtons rngbuttons;
    public BuySnakesButtons buysnakes;
    public EnemiesOnScreen EoS;
    public AbilitiesManager ab;

    [Header("Button Upgrade Scripts")]
    public Upgrade ButtonOne;
    public Upgrade ButtonTwo;
    public Upgrade ButtonThree;

    public NewSnake ButtonOneBuy;
    public NewSnake ButtonTwoBuy;
    public NewSnake ButtonThreeBuy;

    public UpgradeScreen us;

    public GetGold gg;

    [Header("Position In Index")]
    public int Position;
    public SnakeManager sm;

    [Header("Dev Tool")]
    public GameObject AccessUpgrades;
    public GameObject AccessDevMenu;
    public GetSnakes gs;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        Position = transform.GetSiblingIndex();

        // Spawn Enemy //

        if (Input.GetKeyDown(KeyCode.Q) && gameObject.tag == "Snake0")
        {
            Instantiate(PlaceHolderEnemy);
        }

        // Rotate //

        if (Input.GetMouseButton(0))
        {
            rb.freezeRotation = false;
            transform.Rotate(new Vector3(0, 0, 1), turnspeed * Time.deltaTime);
        }
        if (Input.GetMouseButton(1))
        {
            rb.freezeRotation = false;
            transform.Rotate(new Vector3(0, 0, 1), -turnspeed * Time.deltaTime);
        }
        if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
        {
            rb.freezeRotation = true;
        }

        // Move Forward //

        if (rb.velocity.magnitude > speed)
        {
            rb.velocity = rb.velocity.normalized * speed;
        }
        else
        {
            rb.velocity = transform.right * speed * Time.fixedDeltaTime;
        }

        // Ability Selector //


        // Access Upgrade Menu (Temporary access until levels system made)

        if (Input.GetKeyDown(KeyCode.Escape) && gameObject.tag == "Snake0" && AccessUpgrades.activeInHierarchy == false)
        {
            //Generate a random number for the rngbuttons (UpgradeButtons Parent Object)

            rngbuttons.selected = Random.Range(rngbuttons.Tier1, 5);
            rngbuttons.selectedtwo = Random.Range(rngbuttons.Tier1, 5);
            rngbuttons.selectedthree = Random.Range(rngbuttons.Tier1, 5);
            rngbuttons.RNG();

            //Generate a random number for the buysnakes (Get Current Snakes Parent Object)

            buysnakes.selected = Random.Range(buysnakes.Tier1, 5);
            buysnakes.selectedtwo = Random.Range(buysnakes.Tier1, 5);
            buysnakes.selectedthree = Random.Range(buysnakes.Tier1, 5);
            buysnakes.RNG();

            // Individual Button Scripts generating random numbers

            ButtonOne.rngt1 = Random.Range(1, 5);
            ButtonTwo.rngt1 = Random.Range(1, 5);
            ButtonThree.rngt1 = Random.Range(1, 5);

            ButtonOne.rngt2 = Random.Range(1, 5);
            ButtonTwo.rngt2 = Random.Range(1, 5);
            ButtonThree.rngt2 = Random.Range(1, 5);

            ButtonOne.rngt3 = Random.Range(1, 5);
            ButtonTwo.rngt3 = Random.Range(1, 5);
            ButtonThree.rngt3 = Random.Range(1, 5);

            ButtonOne.rngt4 = Random.Range(1, 5);
            ButtonTwo.rngt4 = Random.Range(1, 5);
            ButtonThree.rngt4 = Random.Range(1, 5);

            ButtonOneBuy.rngt1 = Random.Range(1, 5);
            ButtonTwoBuy.rngt1 = Random.Range(1, 5);
            ButtonThreeBuy.rngt1 = Random.Range(1, 5);

            ButtonOneBuy.rngt2 = Random.Range(1, 5);
            ButtonTwoBuy.rngt2 = Random.Range(1, 5);
            ButtonThreeBuy.rngt2 = Random.Range(1, 5);

            ButtonOneBuy.rngt3 = Random.Range(1, 5);
            ButtonTwoBuy.rngt3 = Random.Range(1, 5);
            ButtonThreeBuy.rngt3 = Random.Range(1, 5);

            ButtonOneBuy.rngt4 = Random.Range(1, 5);
            ButtonTwoBuy.rngt4 = Random.Range(1, 5);
            ButtonThreeBuy.rngt4 = Random.Range(1, 5);

            gg.GoldText.text = "Gold: " + sm.Gold;
            OpenUpgrades();
            return;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && gameObject.tag == "Snake0" && AccessUpgrades.activeInHierarchy == true)
        {
            //reset all the snakes and ability managers in the gameobjects
            //and rng so they generate again to make sure they up to date
            // and randomised

            gs.GetSnake0 = null;
            gs.GetSnake1 = null;
            gs.GetSnake2 = null;
            gs.GetSnake3 = null;
            gs.GetSnake4 = null;
            gs.Snake0Ab = null;
            gs.Snake1Ab = null;
            gs.Snake2Ab = null;
            gs.Snake3Ab = null;
            gs.Snake4Ab = null;
            gs.Snake0 = null;
            gs.Snake1 = null;
            gs.Snake2 = null;
            gs.Snake3 = null;
            gs.Snake4 = null;
            ButtonOne.rngt1 = 0;
            ButtonTwo.rngt1 = 0;
            ButtonThree.rngt1 = 0;
            ButtonOne.rngt2 = 0;
            ButtonTwo.rngt2 = 0;
            ButtonThree.rngt2 = 0;
            ButtonOne.rngt3 = 0;
            ButtonTwo.rngt3 = 0;
            ButtonThree.rngt3 = 0;
            ButtonOne.rngt4 = 0;
            ButtonTwo.rngt4 = 0;
            ButtonThree.rngt4 = 0;
            ButtonOne.sc = null;
            ButtonTwo.sc = null;
            ButtonThree.sc = null;
            us.CloseUpgrades();
            return;
        }

        // Dev Tool Edit Snakes

        if(Input.GetKeyDown(KeyCode.Alpha9) && !AccessDevMenu.activeInHierarchy)
        {
            AccessDevMenu.SetActive(true);
            Time.timeScale = 0;
            return;
        }
        if (Input.GetKeyDown(KeyCode.Alpha9) && AccessDevMenu.activeInHierarchy)
        {
            //reset all the snakes and ability managers in the gameobjects
            //so they are up to date
            gs.GetSnake0 = null;
            gs.GetSnake1 = null;
            gs.GetSnake2 = null;
            gs.GetSnake3 = null;
            gs.GetSnake4 = null;
            gs.Snake0Ab = null;
            gs.Snake1Ab = null;
            gs.Snake2Ab = null;
            gs.Snake3Ab = null;
            gs.Snake4Ab = null;
            gs.Snake0 = null;
            gs.Snake1 = null;
            gs.Snake2 = null;
            gs.Snake3 = null;
            gs.Snake4 = null;
            AccessDevMenu.SetActive(false);
            Time.timeScale = 1;
            return;
        }

        if(Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void PlayerDamage(int damage)
    {
        Health -= damage;
        Debug.Log("Damage Dealt to player = " + damage);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.GetComponent<PlaceHolderEnemy>().Damage(100);
            PlayerDamage(10);
        }
    }

    public void OpenUpgrades()
    {
        Time.timeScale = 0;
        AccessUpgrades.SetActive(true);
    }
}
