using UnityEngine;

public class BuySnakesButtons : MonoBehaviour
{
    [Header("Tiers")]
    public int Tier1 = 1;
    public int Tier2 = 2;
    public int Tier3 = 3;
    public int Tier4 = 4;

    [Header("RNG Tier Selecter")]
    public int selected = 0;
    public int selectedtwo = 0;
    public int selectedthree = 0;

    [Header("Button Choice")]
    public int ButtonOneBuy = 1;
    public int ButtonTwoBuy = 2;
    public int ButtonThreeBuy = 3;
    public void RNG()
    {



        // First RNG Selecter

        if (selected == Tier1)
        {
            TierOneFunction(ButtonOneBuy);
        }
        if (selected == Tier2)
        {
            TierTwoFunction(ButtonOneBuy);
        }
        if (selected == Tier3)
        {
            TierThreeFunction(ButtonOneBuy);
        }
        if (selected == Tier4)
        {
            TierFourFunction(ButtonOneBuy);
        }

        // Second RNG Selecter

        if (selectedtwo == Tier1)
        {
            TierOneFunction(ButtonTwoBuy);
        }
        if (selectedtwo == Tier2)
        {
            TierTwoFunction(ButtonTwoBuy);
        }
        if (selectedtwo == Tier3)
        {
            TierThreeFunction(ButtonTwoBuy);
        }
        if (selectedtwo == Tier4)
        {
            TierFourFunction(ButtonTwoBuy);
        }

        //Third RNG Selecter

        if (selectedthree == Tier1)
        {
            TierOneFunction(ButtonThreeBuy);
        }
        if (selectedthree == Tier2)
        {
            TierTwoFunction(ButtonThreeBuy);
        }
        if (selectedthree == Tier3)
        {
            TierThreeFunction(ButtonThreeBuy);
        }
        if (selectedthree == Tier4)
        {
            TierFourFunction(ButtonThreeBuy);
        }
    }

    public void TierOneFunction(int buttonchoice)
    {
        switch (buttonchoice)
        {
            case 1:
                //transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "ChosenT1";
                transform.GetChild(0).gameObject.tag = "TierOne";
                transform.GetChild(0).gameObject.GetComponent<NewSnake>().tag = "TierOne";
                break;
            case 2:
                //transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "ChosenT1";
                transform.GetChild(1).gameObject.tag = "TierOne";
                transform.GetChild(1).gameObject.GetComponent<NewSnake>().tag = "TierOne";
                break;
            case 3:
                //transform.GetChild(2).GetChild(0).GetComponent<Text>().text = "ChosenT1";
                transform.GetChild(2).gameObject.tag = "TierOne";
                transform.GetChild(2).gameObject.GetComponent<NewSnake>().tag = "TierOne";
                break;
        }
    }
    public void TierTwoFunction(int buttonchoice)
    {
        switch (buttonchoice)
        {
            case 1:
                //transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "ChosenT2";
                transform.GetChild(0).gameObject.tag = "TierTwo";
                transform.GetChild(0).gameObject.GetComponent<NewSnake>().tag = "TierTwo";
                break;
            case 2:
                //transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "ChosenT2";
                transform.GetChild(1).gameObject.tag = "TierTwo";
                transform.GetChild(1).gameObject.GetComponent<NewSnake>().tag = "TierTwo";
                break;
            case 3:
                //transform.GetChild(2).GetChild(0).GetComponent<Text>().text = "ChosenT2";
                transform.GetChild(2).gameObject.tag = "TierTwo";
                transform.GetChild(2).gameObject.GetComponent<NewSnake>().tag = "TierTwo";
                break;
        }
    }
    public void TierThreeFunction(int buttonchoice)
    {
        switch (buttonchoice)
        {
            case 1:
                //transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "ChosenT3";
                transform.GetChild(0).gameObject.tag = "TierThree";
                transform.GetChild(0).gameObject.GetComponent<NewSnake>().tag = "TierThree";
                break;
            case 2:
                //transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "ChosenT3";
                transform.GetChild(1).gameObject.tag = "TierThree";
                transform.GetChild(1).gameObject.GetComponent<NewSnake>().tag = "TierThree";
                break;
            case 3:
                //transform.GetChild(2).GetChild(0).GetComponent<Text>().text = "ChosenT3";
                transform.GetChild(2).gameObject.tag = "TierThree";
                transform.GetChild(2).gameObject.GetComponent<NewSnake>().tag = "TierThree";
                break;
        }
    }
    public void TierFourFunction(int buttonchoice)
    {
        switch (buttonchoice)
        {
            case 1:
                //transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "ChosenT4";
                transform.GetChild(0).gameObject.tag = "TierFour";
                transform.GetChild(0).gameObject.GetComponent<NewSnake>().tag = "TierFour";
                break;
            case 2:
                //transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "ChosenT4";
                transform.GetChild(1).gameObject.tag = "TierFour";
                transform.GetChild(1).gameObject.GetComponent<NewSnake>().tag = "TierFour";
                break;
            case 3:
                //transform.GetChild(2).GetChild(0).GetComponent<Text>().text = "ChosenT4";
                transform.GetChild(2).gameObject.tag = "TierFour";
                transform.GetChild(2).gameObject.GetComponent<NewSnake>().tag = "TierFour";
                break;
        }
    }
}
