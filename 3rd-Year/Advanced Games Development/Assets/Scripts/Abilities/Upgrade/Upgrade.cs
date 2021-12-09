using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    [Header("Gameobject Tag")]
    public new string tag;
    [Header("Get Snakes")]
    public GetSnakes gs;
    public SnakeController sc;
    public SnakeManager sm;
    [Header("Button Text")]
    public Text ButtonText;
    [Header("Randomise Options")]
    public int rngt1;
    public int rngt2;
    public int rngt3;
    public int rngt4;
    [Header("Selected Option")]
    public string SelectedOption;
    [Header("Upgrade Screen")]
    public UpgradeScreen us;
    public BoughtNotBoughtUpgrade bnbu;
    [Header("Gold")]
    public GetGold gg;
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
                SelectedOption = "T1C1";
                ButtonText.text = "Poison Damage +1";
                break;
            case 2:
                SelectedOption = "T1C2";
                ButtonText.text = "Stun Duration +1";
                break;
            case 3:
                SelectedOption = "T1C3";
                ButtonText.text = "Poison Duration +1";
                break;
            case 4:
                SelectedOption = "T1C4";
                ButtonText.text = "Attack Enemies Explosion Size +1";
                break;
        }

    }

    public void TierTwoEffects()
    {
        switch (rngt2)
        {
            case 1:
                SelectedOption = "T2C1";
                ButtonText.text = "Burn Available -0.5";
                break;
            case 2:
                SelectedOption = "T2C2";
                ButtonText.text = "Burn Intensity +0.8";
                break;
            case 3:
                SelectedOption = "T2C3";
                ButtonText.text = "Poison Damage +1.2";
                break;
            case 4:
                SelectedOption = "T2C4";
                ButtonText.text = "Poison Circle Speed +0.5";
                break;
        }
    }

    public void TierThreeEffects()
    {
        switch (rngt3)
        {
            case 1:
                SelectedOption = "T3C1";
                ButtonText.text = "Poison Circle Duration +3";
                break;
            case 2:
                SelectedOption = "T3C2";
                ButtonText.text = "Stun Available -1.3";
                break;
            case 3:
                SelectedOption = "T3C3";
                ButtonText.text = "Stun Duration +1.2";
                break;
            case 4:
                SelectedOption = "T3C4";
                ButtonText.text = "Attack Enemies Explosion Size +3";
                break;
        }
    }

    public void TierFourEffects()
    {
        switch (rngt4)
        {
            case 1:
                SelectedOption = "T4C1";
                ButtonText.text = "Poison Circle Size +4";
                break;
            case 2:
                SelectedOption = "T4C2";
                ButtonText.text = "Stun Duration +4";
                break;
            case 3:
                SelectedOption = "T4C3";
                ButtonText.text = "Burn Intensity +4";
                break;
            case 4:
                SelectedOption = "T4C4";
                ButtonText.text = "Burn Tick Damage +0.7";
                break;
        }
    }
    // Button Press //
    public void OnClick()
    {
        switch (SelectedOption)
        {

            //Tier One

            case "T1C1": // Poison +1
                Cost = 2;
                if (Cost <= sm.Gold)
                {
                    sm.Gold -= Cost;
                    bnbu.UpdateText("Bought");
                    UpgradePoisonDamage(1);
                }
                else
                {
                    bnbu.UpdateText("Can't afford upgrade");
                }
                break;
            case "T1C2": // StunDuration +1
                Cost = 2;
                if (Cost <= sm.Gold)
                {
                    sm.Gold -= Cost;
                    bnbu.UpdateText("Bought");
                    IncreaseStunDuration(1);
                }
                else
                {
                    bnbu.UpdateText("Can't afford upgrade");
                }
                break;
            case "T1C3": // PoisonCircleDuration +1
                Cost = 2;
                if (Cost <= sm.Gold)
                {
                    sm.Gold -= Cost;
                    bnbu.UpdateText("Bought");
                    IncreasePoisonCircleDuration(1);
                }
                else
                {
                    bnbu.UpdateText("Can't afford upgrade");
                }
                break;
            case "T1C4": // ExplosionSize +1
                Cost = 2;
                if (Cost <= sm.Gold)
                {
                    sm.Gold -= Cost;
                    bnbu.UpdateText("Bought");
                    IncreaseExplosionSize(1);
                }
                else
                {
                    bnbu.UpdateText("Can't afford upgrade");
                }
                break;

            // Tier Two

            case "T2C1": // Burn Available -0.5
                Cost = 4;
                if (Cost <= sm.Gold)
                {
                    sm.Gold -= Cost;
                    bnbu.UpdateText("Bought");
                    DecreaseBurnAvailable(0.5f);
                }
                else
                {
                    bnbu.UpdateText("Can't afford upgrade");
                }
                break;

            case "T2C2": // Burn Intensity +0.8
                Cost = 4;
                if (Cost <= sm.Gold)
                {
                    sm.Gold -= Cost;
                    bnbu.UpdateText("Bought");
                    IncreaseBurnIntensity(0.8f);
                }
                else
                {
                    bnbu.UpdateText("Can't afford upgrade");
                }
                break;

            case "T2C3": // Poison Damage +1.2
                Cost = 4;
                if (Cost <= sm.Gold)
                {
                    sm.Gold -= Cost;
                    bnbu.UpdateText("Bought");
                    UpgradePoisonDamage(1.2f);
                }
                else
                {
                    bnbu.UpdateText("Can't afford upgrade");
                }
                break;

            case "T2C4": //Poison Circle Speed +0.5
                Cost = 4;
                if (Cost <= sm.Gold)
                {
                    sm.Gold -= Cost;
                    bnbu.UpdateText("Bought");
                    IncreaseCircleSpeed(0.5f);
                }
                else
                {
                    bnbu.UpdateText("Can't afford upgrade");
                }
                break;

            // Tier Three

            case "T3C1": //Poison Circle Duration +3
                Cost = 4;
                if (Cost <= sm.Gold)
                {
                    sm.Gold -= Cost;
                    bnbu.UpdateText("Bought");
                    IncreasePoisonCircleDuration(3);
                }
                else
                {
                    bnbu.UpdateText("Can't afford upgrade");
                }
                break;
            case "T3C2": //Stun Available -1.3
                Cost = 4;
                if (Cost <= sm.Gold)
                {
                    sm.Gold -= Cost;
                    bnbu.UpdateText("Bought");
                    DecreaseStunAvailable(1.3f);
                }
                else
                {
                    bnbu.UpdateText("Can't afford upgrade");
                }
                break;
            case "T3C3": //Stun Duration +1.2
                Cost = 4;
                if (Cost <= sm.Gold)
                {
                    sm.Gold -= Cost;
                    bnbu.UpdateText("Bought");
                    IncreaseStunDuration(1.2f);
                }
                else
                {
                    bnbu.UpdateText("Can't afford upgrade");
                }
                break;
            case "T3C4": //Attack Enemies Explosion Size +3
                Cost = 4;
                if (Cost <= sm.Gold)
                {
                    sm.Gold -= Cost;
                    bnbu.UpdateText("Bought");
                    IncreaseExplosionSize(3f);
                }
                else
                {
                    bnbu.UpdateText("Can't afford upgrade");
                }
                break;

            // Tier Four

            case "T4C1": //Increase Circle Size +4
                Cost = 4;
                if (Cost <= sm.Gold)
                {
                    sm.Gold -= Cost;
                    bnbu.UpdateText("Bought");
                    IncreaseCircleSize(new Vector3(4, 4, 4));
                }
                else
                {
                    bnbu.UpdateText("Can't afford upgrade");
                }
                break;
            case "T4C2": //Stun Duration +4
                Cost = 4;
                if (Cost <= sm.Gold)
                {
                    sm.Gold -= Cost;
                    bnbu.UpdateText("Bought");
                    IncreaseStunDuration(4f);
                }
                else
                {
                    bnbu.UpdateText("Can't afford upgrade");
                }
                break;
            case "T4C3": //Increase Burn Intensity +4
                Cost = 4;
                if (Cost <= sm.Gold)
                {
                    sm.Gold -= Cost;
                    bnbu.UpdateText("Bought");
                    IncreaseBurnIntensity(4f);
                }
                else
                {
                    bnbu.UpdateText("Can't afford upgrade");
                }
                break;
            case "T4C4": //Burn Tick Damage +0.7f
                Cost = 4;
                if (Cost <= sm.Gold)
                {
                    sm.Gold -= Cost;
                    bnbu.UpdateText("Bought");
                    IncreaseBurnTickDamage(0.7f);
                }
                else
                {
                    bnbu.UpdateText("Can't afford upgrade");
                }
                break;
        }
    }

    // Upgrade Function //

    //Poison
    public void UpgradePoisonDamage(float damage)
    {
        us.CloseUpgrades();
        gs.Snake0Ab.PoisonIntensity += damage;
        gs.Snake1Ab.PoisonIntensity += damage;
        gs.Snake2Ab.PoisonIntensity += damage;
        gs.Snake3Ab.PoisonIntensity += damage;
        gs.Snake4Ab.PoisonIntensity += damage;
    }

    public void IncreasePoisonCircleDuration(float CircleTimer)
    {
        us.CloseUpgrades();
        gs.Snake0Ab.PoisionDuration += CircleTimer;
        gs.Snake1Ab.PoisionDuration += CircleTimer;
        gs.Snake2Ab.PoisionDuration += CircleTimer;
        gs.Snake3Ab.PoisionDuration += CircleTimer;
        gs.Snake4Ab.PoisionDuration += CircleTimer;
    }

    public void IncreaseCircleSpeed(float CircleSpeed)
    {
        us.CloseUpgrades();
        gs.Snake0Ab.PoisonCircleSpeed += CircleSpeed;
        gs.Snake1Ab.PoisonCircleSpeed += CircleSpeed;
        gs.Snake2Ab.PoisonCircleSpeed += CircleSpeed;
        gs.Snake3Ab.PoisonCircleSpeed += CircleSpeed;
        gs.Snake4Ab.PoisonCircleSpeed += CircleSpeed;
    }

    public void IncreaseCircleSize(Vector3 Size)
    {
        us.CloseUpgrades();
        gs.Snake0Ab.CircleSize += Size;
        gs.Snake1Ab.CircleSize += Size;
        gs.Snake2Ab.CircleSize += Size;
        gs.Snake3Ab.CircleSize += Size;
        gs.Snake4Ab.CircleSize += Size;
    }


    //Stun

    public void IncreaseStunDuration(float duration)
    {
        us.CloseUpgrades();
        gs.Snake0Ab.StunDurationTimer += duration;
        gs.Snake1Ab.StunDurationTimer += duration;
        gs.Snake2Ab.StunDurationTimer += duration;
        gs.Snake3Ab.StunDurationTimer += duration;
        gs.Snake4Ab.StunDurationTimer += duration;
    }


    //Enemy Attack Enemy
    public void IncreaseExplosionSize(float ExplosionSize)
    {
        us.CloseUpgrades();
        gs.Snake0Ab.ExplosionSize += ExplosionSize;
        gs.Snake1Ab.ExplosionSize += ExplosionSize;
        gs.Snake2Ab.ExplosionSize += ExplosionSize;
        gs.Snake3Ab.ExplosionSize += ExplosionSize;
        gs.Snake4Ab.ExplosionSize += ExplosionSize;
    }

    public void DecreaseStunAvailable(float StunAvailable)
    {
        us.CloseUpgrades();
        gs.Snake0Ab.StunAvailableTimer -= StunAvailable;
        gs.Snake1Ab.ExplosionSize -= StunAvailable;
        gs.Snake2Ab.ExplosionSize -= StunAvailable;
        gs.Snake3Ab.ExplosionSize -= StunAvailable;
        gs.Snake4Ab.ExplosionSize -= StunAvailable;
    }

    //Burn

    public void DecreaseBurnAvailable(float BurnAvailable)
    {
        us.CloseUpgrades();
        gs.Snake0Ab.BurnAvailableTimer -= BurnAvailable;
        gs.Snake1Ab.BurnAvailableTimer -= BurnAvailable;
        gs.Snake2Ab.BurnAvailableTimer -= BurnAvailable;
        gs.Snake3Ab.BurnAvailableTimer -= BurnAvailable;
        gs.Snake4Ab.BurnAvailableTimer -= BurnAvailable;
    }

    public void IncreaseBurnIntensity(float BurnIntensity)
    {
        us.CloseUpgrades();
        gs.Snake0Ab.BurnIntensity += BurnIntensity;
        gs.Snake1Ab.BurnIntensity += BurnIntensity;
        gs.Snake2Ab.BurnIntensity += BurnIntensity;
        gs.Snake3Ab.BurnIntensity += BurnIntensity;
        gs.Snake4Ab.BurnIntensity += BurnIntensity;
    }

    public void IncreaseBurnTickDamage(float BurnTick)
    {
        us.CloseUpgrades();
        gs.Snake0Ab.BurnTick += BurnTick;
        gs.Snake1Ab.BurnTick += BurnTick;
        gs.Snake2Ab.BurnTick += BurnTick;
        gs.Snake3Ab.BurnTick += BurnTick;
        gs.Snake4Ab.BurnTick += BurnTick;
    }
}
