using TMPro;
using UnityEngine;

public class NewSnake : MonoBehaviour
{
    [Header("identifiers")]
    public new string tag;
    [Header("Get Snakes")]
    public GetSnakes gs;
    public SnakeManager sm;
    [Header("Button Text")]
    public TextMeshProUGUI ButtonText;
    [Header("Randomize Options")]
    public int rngt1;
    public int rngt2;
    public int rngt3;
    public int rngt4;
    [Header("Selected Option")]
    public string SelectedOption;
    public TextMeshProUGUI SnakeDescription;
    [Header("Upgrade Screen")]
    public UpgradeScreen us;
    public BoughtNotBoughtUpgrade bnbu;
    [Header("Gold")]
    public int Cost;

    public void Update()
    {
        if (tag == "TierOne")
        {
            TierOneEffects();
        }
        if (tag == "TierTwo")
        {
            TierTwoEffects();
        }
        if (tag == "TierThree")
        {
            TierThreeEffects();
        }
        if (tag == "TierFour")
        {
            TierFourEffects();
        }
    }

    // Tier Effects //
    public void TierOneEffects()
    {
        switch (rngt1)
        {
            case 1:
                SelectedOption = "T1B1";
                ButtonText.text = "Poison Shooter Tier 1";
                SnakeDescription.text = "Shoots a poison circle dealing AoE damage";
                break;
            case 2:
                SelectedOption = "T1B2";
                ButtonText.text = "Stunner Tier 1";
                SnakeDescription.text = "Stuns the nearest enemy";
                break;
            case 3:
                SelectedOption = "T1B3";
                ButtonText.text = "Burner Tier 1";
                SnakeDescription.text = "Burns the nearest enemy";
                break;
            case 4:
                SelectedOption = "T1B4";
                ButtonText.text = "Enemy Attack Enemy Tier 1";
                SnakeDescription.text = "Makes the nearest enemy attack the nearest enemy to that enemy";
                break;
        }

    }

    public void TierTwoEffects()
    {
        switch (rngt2)
        {
            case 1:
                SelectedOption = "T2B1";
                ButtonText.text = "Poison Shooter Tier 2";
                SnakeDescription.text = "Shoots a poison circle dealing AoE damage";
                break;
            case 2:
                SelectedOption = "T2B2";
                ButtonText.text = "Stunner Tier 2";
                SnakeDescription.text = "Stuns the nearest enemy";
                break;
            case 3:
                SelectedOption = "T2B3";
                ButtonText.text = "Burner Tier 2";
                SnakeDescription.text = "Burns the nearest enemy";
                break;
            case 4:
                SelectedOption = "T2B4";
                ButtonText.text = "Enemy Attack Enemy Tier 2";
                SnakeDescription.text = "Makes the nearest enemy attack the nearest enemy to that enemy";
                break;
        }
    }

    public void TierThreeEffects()
    {
        switch (rngt3)
        {
            case 1:
                SelectedOption = "T3B1";
                ButtonText.text = "Poison Shooter Tier 3";
                SnakeDescription.text = "Shoots a poison circle dealing AoE damage";
                break;
            case 2:
                SelectedOption = "T3B2";
                ButtonText.text = "Stunner Tier 3";
                SnakeDescription.text = "Stuns the nearest enemy";
                break;
            case 3:
                SelectedOption = "T3B3";
                ButtonText.text = "Burner Tier 3";
                SnakeDescription.text = "Burns the nearest enemy";
                break;
            case 4:
                SelectedOption = "T3B4";
                ButtonText.text = "Enemy Attack Enemy Tier 3";
                SnakeDescription.text = "Makes the nearest enemy attack the nearest enemy to that enemy";
                break;
        }
    }

    public void TierFourEffects()
    {
        switch (rngt4)
        {
            case 1:
                SelectedOption = "T4B1";
                ButtonText.text = "Poison Shooter Tier 4";
                SnakeDescription.text = "Shoots a poison circle dealing AoE damage";
                break;
            case 2:
                SelectedOption = "T4B2";
                ButtonText.text = "Stunner Tier 4";
                SnakeDescription.text = "Stuns the nearest enemy";
                break;
            case 3:
                SelectedOption = "T4B3";
                ButtonText.text = "Burner Tier 4";
                SnakeDescription.text = "Burns the nearest enemy";
                break;
            case 4:
                SelectedOption = "T4B4";
                ButtonText.text = "Enemy Attack Enemy Tier 4";
                SnakeDescription.text = "Makes the nearest enemy attack the nearest enemy to that enemy";
                break;
        }
    }
    // Button Press //
    public void OnClick()
    {
        switch (SelectedOption)
        {
            case "T1B1":
                Cost = 2;
                if (Cost <= sm.Gold)
                {
                    bnbu.UpdateText("Bought");
                    sm.Gold -= Cost;
                    PoisonShooterT1();
                }
                else
                {
                    bnbu.UpdateText("Can't afford to buy");
                }
                break;
            case "T1B2":
                Cost = 2;
                if (Cost <= sm.Gold)
                {
                    bnbu.UpdateText("Bought");
                    sm.Gold -= Cost;
                    StunT1();
                }
                else
                {
                    bnbu.UpdateText("Can't afford to buy");
                }
                break;
            case "T1B3":
                Cost = 2;
                if (Cost <= sm.Gold)
                {
                    bnbu.UpdateText("Bought");
                    sm.Gold -= Cost;
                    BurnT1();
                }
                else
                {
                    bnbu.UpdateText("Can't afford to buy");
                }
                break;
            case "T1B4":
                Cost = 2;
                if (Cost <= sm.Gold)
                {
                    bnbu.UpdateText("Bought");
                    sm.Gold -= Cost;
                    AttackEnemyT1();
                }
                else
                {
                    bnbu.UpdateText("Can't afford to buy");
                }
                break;
            case "T2B1":
                Cost = 4;
                if (Cost <= sm.Gold)
                {
                    bnbu.UpdateText("Bought");
                    sm.Gold -= Cost;
                    PoisonShooterT2();
                }
                else
                {
                    bnbu.UpdateText("Can't afford to buy");
                }
                break;
            case "T2B2":
                Cost = 4;
                if (Cost <= sm.Gold)
                {
                    bnbu.UpdateText("Bought");
                    sm.Gold -= Cost;
                    StunT2();
                }
                else
                {
                    bnbu.UpdateText("Can't afford to buy");
                }
                break;
            case "T2B3":
                Cost = 4;
                if (Cost <= sm.Gold)
                {
                    bnbu.UpdateText("Bought");
                    sm.Gold -= Cost;
                    BurnT2();
                }
                else
                {
                    bnbu.UpdateText("Can't afford to buy");
                }
                break;
            case "T2B4":
                Cost = 4;
                if (Cost <= sm.Gold)
                {
                    bnbu.UpdateText("Bought");
                    sm.Gold -= Cost;
                    AttackEnemyT2();
                }
                else
                {
                    bnbu.UpdateText("Can't afford to buy");
                }
                break;

            // Tier Three

            case "T3B1":
                Cost = 6;
                if (Cost <= sm.Gold)
                {
                    bnbu.UpdateText("Bought");
                    sm.Gold -= Cost;
                    PoisonShooterT3();
                }
                else
                {
                    bnbu.UpdateText("Can't afford to buy");
                }
                break;
            case "T3B2":
                Cost = 6;
                if (Cost <= sm.Gold)
                {
                    bnbu.UpdateText("Bought");
                    sm.Gold -= Cost;
                    StunT3();
                }
                else
                {
                    bnbu.UpdateText("Can't afford to buy");
                }
                break;
            case "T3B3":
                Cost = 6;
                if (Cost <= sm.Gold)
                {
                    bnbu.UpdateText("Bought");
                    sm.Gold -= Cost;
                    BurnT3();
                }
                else
                {
                    bnbu.UpdateText("Can't afford to buy");
                }
                break;
            case "T3B4":
                Cost = 6;
                if (Cost <= sm.Gold)
                {
                    bnbu.UpdateText("Bought");
                    sm.Gold -= Cost;
                    AttackEnemyT3();
                }
                else
                {
                    bnbu.UpdateText("Can't afford to buy");
                }
                break;

            // Tier Four

            case "T4B1":
                Cost = 8;
                if (Cost <= sm.Gold)
                {
                    bnbu.UpdateText("Bought");
                    sm.Gold -= Cost;
                    PoisonShooterT4();
                }
                else
                {
                    bnbu.UpdateText("Can't afford to buy");
                }
                break;
            case "T4B2":
                Cost = 8;
                if (Cost <= sm.Gold)
                {
                    bnbu.UpdateText("Bought");
                    sm.Gold -= Cost;
                    StunT4();
                }
                else
                {
                    bnbu.UpdateText("Can't afford to buy");
                }
                break;
            case "T4B3":
                Cost = 8;
                if (Cost <= sm.Gold)
                {
                    bnbu.UpdateText("Bought");
                    sm.Gold -= Cost;
                    BurnT4();
                }
                else
                {
                    bnbu.UpdateText("Can't afford to buy");
                }
                break;
            case "T4B4":
                Cost = 8;
                if (Cost <= sm.Gold)
                {
                    bnbu.UpdateText("Bought");
                    sm.Gold -= Cost;
                    AttackEnemyT4();
                }
                else
                {
                    bnbu.UpdateText("Can't afford to buy");
                }
                break;
        }
    }

    // Upgrade Function //

    // Tier One

    public void PoisonShooterT1()
    {
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().Stun = false;
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().Burn = false;
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().AttackEnemies = false;
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().PoisonCircle = true;
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().TierString = SelectedOption;

        //T1 Poison Abilities

        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().PoisonAvailableTimer += 10;
        us.CloseUpgrades();
    }
    public void StunT1()
    {
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().Stun = true;
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().Burn = false;
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().AttackEnemies = false;
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().PoisonCircle = false;
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().TierString = SelectedOption;

        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().StunAvailableTimer += 10;
        us.CloseUpgrades();
    }
    public void BurnT1()
    {
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().Stun = false;
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().Burn = true;
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().AttackEnemies = false;
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().PoisonCircle = false;
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().TierString = SelectedOption;

        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().BurnAvailableTimer += 10;
        us.CloseUpgrades();
    }
    public void AttackEnemyT1()
    {
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().Stun = false;
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().Burn = false;
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().AttackEnemies = true;
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().PoisonCircle = false;
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().TierString = SelectedOption;

        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().AttackAvailableTimer += 10;
        us.CloseUpgrades();
    }

    // Tier Two

    public void PoisonShooterT2()
    {
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().Stun = false;
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().Burn = false;
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().AttackEnemies = false;
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().PoisonCircle = true;
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().TierString = SelectedOption;

        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().PoisonAvailableTimer += 9;
        us.CloseUpgrades();
    }

    public void StunT2()
    {
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().Stun = true;
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().Burn = false;
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().AttackEnemies = false;
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().PoisonCircle = false;
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().TierString = SelectedOption;

        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().StunAvailableTimer += 9;
        us.CloseUpgrades();
    }
    public void BurnT2()
    {
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().Stun = false;
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().Burn = true;
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().AttackEnemies = false;
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().PoisonCircle = false;
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().TierString = SelectedOption;

        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().BurnAvailableTimer += 9;
        us.CloseUpgrades();
    }
    public void AttackEnemyT2()
    {
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().Stun = false;
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().Burn = false;
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().AttackEnemies = true;
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().PoisonCircle = false;
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().TierString = SelectedOption;

        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().AttackAvailableTimer += 9;
        us.CloseUpgrades();
    }

    // Tier Three

    public void PoisonShooterT3()
    {
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().Stun = false;
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().Burn = false;
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().AttackEnemies = false;
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().PoisonCircle = true;
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().TierString = SelectedOption;

        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().PoisonAvailableTimer += 8;
        us.CloseUpgrades();
    }

    public void StunT3()
    {
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().Stun = true;
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().Burn = false;
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().AttackEnemies = false;
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().PoisonCircle = false;
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().TierString = SelectedOption;

        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().StunAvailableTimer += 8;
        us.CloseUpgrades();
    }
    public void BurnT3()
    {
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().Stun = false;
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().Burn = true;
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().AttackEnemies = false;
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().PoisonCircle = false;
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().TierString = SelectedOption;

        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().BurnAvailableTimer += 8;
        us.CloseUpgrades();
    }
    public void AttackEnemyT3()
    {
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().Stun = false;
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().Burn = false;
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().AttackEnemies = true;
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().PoisonCircle = false;
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().TierString = SelectedOption;

        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().AttackAvailableTimer += 8;
        us.CloseUpgrades();
    }

    // Tier Four

    public void PoisonShooterT4()
    {
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().Stun = false;
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().Burn = false;
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().AttackEnemies = false;
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().PoisonCircle = true;
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().TierString = SelectedOption;

        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().PoisonAvailableTimer += 7;
        us.CloseUpgrades();
    }

    public void StunT4()
    {
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().Stun = true;
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().Burn = false;
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().AttackEnemies = false;
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().PoisonCircle = false;
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().TierString = SelectedOption;

        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().StunAvailableTimer += 7;
        us.CloseUpgrades();
    }
    public void BurnT4()
    {
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().Stun = false;
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().Burn = true;
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().AttackEnemies = false;
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().PoisonCircle = false;
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().TierString = SelectedOption;

        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().BurnAvailableTimer += 7;
        us.CloseUpgrades();
    }
    public void AttackEnemyT4()
    {
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().Stun = false;
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().Burn = false;
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().AttackEnemies = true;
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().PoisonCircle = false;
        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().TierString = SelectedOption;

        gs.CurrentSelectedSnake.GetComponent<AbilitiesManager>().AttackAvailableTimer += 7;
        us.CloseUpgrades();
    }
}
