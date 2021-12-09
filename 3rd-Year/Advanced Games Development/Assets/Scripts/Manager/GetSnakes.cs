using TMPro;
using UnityEngine;

public class GetSnakes : MonoBehaviour
{
    [Header("Get Snakes")]
    public GameObject GetSnake0;
    public GameObject GetSnake1;
    public GameObject GetSnake2;
    public GameObject GetSnake3;
    public GameObject GetSnake4;
    public GameObject SellSnake;

    [Header("Snake Abilities Managers")]
    public AbilitiesManager Snake0Ab;
    public AbilitiesManager Snake1Ab;
    public AbilitiesManager Snake2Ab;
    public AbilitiesManager Snake3Ab;
    public AbilitiesManager Snake4Ab;

    [Header("Snake Type")]
    public TextMeshProUGUI Snake0;
    public TextMeshProUGUI Snake1;
    public TextMeshProUGUI Snake2;
    public TextMeshProUGUI Snake3;
    public TextMeshProUGUI Snake4;

    [Header("Current Snake Selected")]
    public GameObject CurrentSelectedSnake;
    public TextMeshProUGUI CurrentSelectedSnakeText;

    [Header("Snake Manager")]
    public SnakeManager sm;

    [Header("Upgrade Screen")]
    public BoughtNotBoughtUpgrade bnbu;
    public void Update()
    {
        // Set the CurrentSelectedSnake text accordingly

        if (CurrentSelectedSnake == null)
        {
            CurrentSelectedSnakeText.text = "Current Selected: Nothing";
        }
        else
        {
            CurrentSelectedSnakeText.text = "Current Selected: " + CurrentSelectedSnake.name;
        }

        // Get the snakes and organise them in order

        if (GetSnake0 == null)
        {
            GetSnake0 = GameObject.FindGameObjectWithTag("Snake0");
            if (GetSnake0 != null)
            {
                Snake0Ab = GetSnake0.GetComponent<AbilitiesManager>();
            }
            Snake0 = transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
            Snake0.text = ShowSnakeSprite(Snake0, Snake0Ab);
        }

        if (GetSnake1 == null)
        {
            GetSnake1 = GameObject.FindGameObjectWithTag("Snake1");
            if (GetSnake1 != null)
            {
                Snake1Ab = GetSnake1.GetComponent<AbilitiesManager>();
            }
            Snake1 = transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>();
            Snake1.text = ShowSnakeSprite(Snake1, Snake1Ab);
        }

        if (GetSnake2 == null)
        {
            GetSnake2 = GameObject.FindGameObjectWithTag("Snake2");
            if (GetSnake2 != null)
            {
                Snake2Ab = GetSnake2.GetComponent<AbilitiesManager>();
            }
            Snake2 = transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>();
            Snake2.text = ShowSnakeSprite(Snake2, Snake2Ab);
        }

        if (GetSnake3 == null)
        {
            GetSnake3 = GameObject.FindGameObjectWithTag("Snake3");
            if (GetSnake3 != null)
            {
                Snake3Ab = GetSnake3.GetComponent<AbilitiesManager>();
            }
            Snake3 = transform.GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>();
            Snake3.text = ShowSnakeSprite(Snake3, Snake3Ab);
        }

        if (GetSnake4 == null)
        {
            GetSnake4 = GameObject.FindGameObjectWithTag("Snake4");
            if (GetSnake4 != null)
            {
                Snake4Ab = GetSnake4.GetComponent<AbilitiesManager>();
            }
            Snake4 = transform.GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>();
            Snake4.text = ShowSnakeSprite(Snake4, Snake4Ab);
        }
    }

    //UI


    // Displays what the snakes abilities are
    public string ShowSnakeSprite(TextMeshProUGUI s, AbilitiesManager am)
    {
        if (am == null)
        {
            return null;
        }
        switch (am.AbilityChosen)
        {
            case "AttackEnemy":
                s.text = "Attack Enemies";
                break;
            case "PoisonCircle":
                s.text = "Poison Shooter";
                break;
            case "Burn":
                s.text = "Burn Enemies";
                break;
            case "Stun":
                s.text = "Stun Enemies";
                break;
        }
        return s.text;
    }

    // Buttons

    public void SellSnakeFunction(GameObject g)
    {
        string tier = g.GetComponent<AbilitiesManager>().TierString;

        if (tier.Contains("T1"))
        {
            sm.Gold += 2;
            sm.Snakes.Remove(g);
            g.SetActive(false);
            sm.SnakesListOrganise();
        }
        if (tier.Contains("T2"))
        {
            sm.Gold += 4;
            sm.Snakes.Remove(g);
            g.SetActive(false);
            sm.SnakesListOrganise();
        }
        if (tier.Contains("T3"))
        {
            sm.Gold += 6;
            sm.Snakes.Remove(g);
            g.SetActive(false);
            sm.SnakesListOrganise();
        }
        if (tier.Contains("T4"))
        {
            sm.Gold += 8;
            sm.Snakes.Remove(g);
            g.SetActive(false);
            sm.SnakesListOrganise();
        }
    }

    public void UpgradeCurrentSnake(GameObject g)
    {
        string tier = g.GetComponent<AbilitiesManager>().TierString;

        if (tier.Contains("T1"))
        {
            int Cost = 2;
            if (Cost < sm.Gold)
            {
                sm.Gold -= 2;
                tier = tier.Replace("T1", "T2");
                g.GetComponent<AbilitiesManager>().TierString = tier;
                g.GetComponent<AbilitiesManager>().UpdateTier();
            }
            else
            {
                bnbu.UpdateText("Can't afford to upgrade");
            }
            return;
        }
        if (tier.Contains("T2"))
        {
            int Cost = 2;
            if (Cost < sm.Gold)
            {
                sm.Gold -= 4;
                tier = tier.Replace("T2", "T3");
                g.GetComponent<AbilitiesManager>().TierString = tier;
                g.GetComponent<AbilitiesManager>().UpdateTier();
                AbilityCheckT3(g);
            }
            else
            {
                bnbu.UpdateText("Can't afford to upgrade");
            }
            return;
        }
        if (tier.Contains("T3"))
        {
            int Cost = 2;
            if (Cost < sm.Gold)
            {
                sm.Gold -= 6;
                tier = tier.Replace("T3", "T4");
                g.GetComponent<AbilitiesManager>().TierString = tier;
                g.GetComponent<AbilitiesManager>().UpdateTier();
            }
            else
            {
                bnbu.UpdateText("Can't afford to upgrade");
            }
            return;
        }
        if (tier.Contains("T4"))
        {
            Debug.Log("Max Tier!");
            bnbu.UpdateText("Maximum Tier");
            return;
        }
    }

    //If the snake has been upgraded check for if it has reached tier 3
    // If it has reached tier 3, set the tier 3 boolean in the current snake
    // that has been chosen to true

    public void AbilityCheckT3(GameObject g)
    {
        if (g.GetComponent<AbilitiesManager>().TierString.Contains("T3"))
        {
            if (g.GetComponent<AbilitiesManager>().AbilityChosen == "PoisonCircle")
            {
                Debug.Log("T3PoisonAbility");
                g.GetComponent<AbilitiesManager>().Tier3 = true;
            }
            if (g.GetComponent<AbilitiesManager>().AbilityChosen == "Burn")
            {
                Debug.Log("T3BurnAbility");
                g.GetComponent<AbilitiesManager>().Tier3 = true;
            }
            if (g.GetComponent<AbilitiesManager>().AbilityChosen == "Stun")
            {
                Debug.Log("T3StunAbility");
                g.GetComponent<AbilitiesManager>().Tier3 = true;
            }
            if (g.GetComponent<AbilitiesManager>().AbilityChosen == "AttackEnemy")
            {
                Debug.Log("T3EnemyAttackEnemyAbility");
                g.GetComponent<AbilitiesManager>().Tier3 = true;
            }
        }
    }

    // Dev Tools //

    // For designers to upgrade the snake without changing the gold value
    public void UpgradeCurrentSnakeDev(GameObject g)
    {
        if (g.GetComponent<AbilitiesManager>().TierString.Contains("T1"))
        {
            g.GetComponent<AbilitiesManager>().TierString = g.GetComponent<AbilitiesManager>().TierString.Replace("T1", "T2");
            return;
        }
        if (g.GetComponent<AbilitiesManager>().TierString.Contains("T2"))
        {
            g.GetComponent<AbilitiesManager>().TierString = g.GetComponent<AbilitiesManager>().TierString.Replace("T2", "T3");
            AbilityCheckT3(g);
            return;
        }
        if (g.GetComponent<AbilitiesManager>().TierString.Contains("T3"))
        {
            g.GetComponent<AbilitiesManager>().TierString = g.GetComponent<AbilitiesManager>().TierString.Replace("T3", "T4");
            return;
        }
        if (g.GetComponent<AbilitiesManager>().TierString.Contains("T4"))
        {
            Debug.Log("Max Tier");
            return;
        }

    }

    // List of dev upgrade functions to allow for easier testing

    // Stun Changes
    public void StunAvailablePlus()
    {
        CurrentSelectedSnake.GetComponent<AbilitiesManager>().StunAvailableTimer++;
    }
    public void StunAvailableMinus()
    {
        CurrentSelectedSnake.GetComponent<AbilitiesManager>().StunAvailableTimer--;
    }

    public void StunDurationPlus()
    {
        CurrentSelectedSnake.GetComponent<AbilitiesManager>().StunDurationTimer++;
    }

    public void StunDurationMinus()
    {
        CurrentSelectedSnake.GetComponent<AbilitiesManager>().StunDurationTimer--;
    }

    // Burn Changes

    public void BurnAvailablePlus()
    {
        CurrentSelectedSnake.GetComponent<AbilitiesManager>().BurnAvailableTimer++;
    }

    public void BurnAvailableMinus()
    {
        CurrentSelectedSnake.GetComponent<AbilitiesManager>().BurnAvailableTimer--;
    }

    public void BurnTickPlus()
    {
        CurrentSelectedSnake.GetComponent<AbilitiesManager>().BurnTick++;
    }

    public void BurnTickMinus()
    {
        CurrentSelectedSnake.GetComponent<AbilitiesManager>().BurnTick--;
    }

    public void BurnDurationPlus()
    {
        CurrentSelectedSnake.GetComponent<AbilitiesManager>().BurnDuration++;
    }

    public void BurnDurationMinus()
    {
        CurrentSelectedSnake.GetComponent<AbilitiesManager>().BurnDuration--;
    }

    public void BurnIntensityPlus()
    {
        CurrentSelectedSnake.GetComponent<AbilitiesManager>().BurnIntensity++;
    }

    public void BurnIntensityMinus()
    {
        CurrentSelectedSnake.GetComponent<AbilitiesManager>().BurnIntensity--;
    }

    //enemy attack enemy changes

    public void AttackAvailablePlus()
    {
        CurrentSelectedSnake.GetComponent<AbilitiesManager>().AttackAvailableTimer++;
    }

    public void AttackAvailableMinus()
    {
        CurrentSelectedSnake.GetComponent<AbilitiesManager>().AttackAvailableTimer--;
    }

    public void ExplosionSizePlus()
    {
        CurrentSelectedSnake.GetComponent<AbilitiesManager>().ExplosionSize++;
    }

    public void ExplosionSizeMinus()
    {
        CurrentSelectedSnake.GetComponent<AbilitiesManager>().ExplosionSize--;
    }

    //poison shoot changes

    public void PoisonAvailableTimerPlus()
    {
        CurrentSelectedSnake.GetComponent<AbilitiesManager>().PoisonAvailableTimer++;
    }

    public void PoisonAvailableTimerMinus()
    {
        CurrentSelectedSnake.GetComponent<AbilitiesManager>().PoisonAvailableTimer--;
    }

    public void PoisonDurationPlus()
    {
        CurrentSelectedSnake.GetComponent<AbilitiesManager>().PoisionDuration++;
    }

    public void PoisonDurationMinus()
    {
        CurrentSelectedSnake.GetComponent<AbilitiesManager>().PoisionDuration--;
    }

    public void PoisonDamageTickPlus()
    {
        CurrentSelectedSnake.GetComponent<AbilitiesManager>().PoisonDamageTick++;
    }

    public void PoisonDamageTickMinus()
    {
        CurrentSelectedSnake.GetComponent<AbilitiesManager>().PoisonDamageTick--;
    }

    public void PoisonCircleSpeedPlus()
    {
        CurrentSelectedSnake.GetComponent<AbilitiesManager>().PoisonCircleSpeed++;
    }
    public void PoisonCircleSpeedMinus()
    {
        CurrentSelectedSnake.GetComponent<AbilitiesManager>().PoisonCircleSpeed--;
    }

    public void PoisonCircleDurationPlus()
    {
        CurrentSelectedSnake.GetComponent<AbilitiesManager>().CircleDuration++;
    }
    public void PoisonCircleDurationMinus()
    {
        CurrentSelectedSnake.GetComponent<AbilitiesManager>().CircleDuration--;
    }

    public void PoisonCircleSizePlus()
    {
        Vector3 v3 = new Vector3(0,0,0);
        v3 = CurrentSelectedSnake.GetComponent<AbilitiesManager>().CircleSize;
        float zero = v3[0];
        float one = v3[1];
        float two = v3[2];
        zero++;
        one++;
        two++;
        v3 = new Vector3(zero, one, two);
        CurrentSelectedSnake.GetComponent<AbilitiesManager>().CircleSize = v3;
    }
    public void PoisonCircleSizeMinus()
    {
        Vector3 v3 = new Vector3(0, 0, 0);
        v3 = CurrentSelectedSnake.GetComponent<AbilitiesManager>().CircleSize;
        float zero = v3[0];
        float one = v3[1];
        float two = v3[2];
        zero--;
        one--;
        two--;
        v3 = new Vector3(zero, one, two);
        CurrentSelectedSnake.GetComponent<AbilitiesManager>().CircleSize = v3;
    }

    public void PoisonIntensityPlus()
    {
        CurrentSelectedSnake.GetComponent<AbilitiesManager>().PoisonIntensity++;
    }
    public void PoisonIntensityMinus()
    {
        CurrentSelectedSnake.GetComponent<AbilitiesManager>().PoisonIntensity--;
    }

    // Change class functions

    public void MakeStunner()
    {
        CurrentSelectedSnake.GetComponent<AbilitiesManager>().Stun = true;
        CurrentSelectedSnake.GetComponent<AbilitiesManager>().Burn = false;
        CurrentSelectedSnake.GetComponent<AbilitiesManager>().AttackEnemies = false;
        CurrentSelectedSnake.GetComponent<AbilitiesManager>().PoisonCircle = false;
    }

    public void MakeBurner()
    {
        CurrentSelectedSnake.GetComponent<AbilitiesManager>().Stun = false;
        CurrentSelectedSnake.GetComponent<AbilitiesManager>().Burn = true;
        CurrentSelectedSnake.GetComponent<AbilitiesManager>().AttackEnemies = false;
        CurrentSelectedSnake.GetComponent<AbilitiesManager>().PoisonCircle = false;
    }

    public void MakeAttackEnemies()
    {
        CurrentSelectedSnake.GetComponent<AbilitiesManager>().Stun = false;
        CurrentSelectedSnake.GetComponent<AbilitiesManager>().Burn = false;
        CurrentSelectedSnake.GetComponent<AbilitiesManager>().AttackEnemies = true;
        CurrentSelectedSnake.GetComponent<AbilitiesManager>().PoisonCircle = false;
    }

    public void MakePoisonShooter()
    {
        CurrentSelectedSnake.GetComponent<AbilitiesManager>().Stun = false;
        CurrentSelectedSnake.GetComponent<AbilitiesManager>().Burn = false;
        CurrentSelectedSnake.GetComponent<AbilitiesManager>().AttackEnemies = false;
        CurrentSelectedSnake.GetComponent<AbilitiesManager>().PoisonCircle = true;
    }
}
