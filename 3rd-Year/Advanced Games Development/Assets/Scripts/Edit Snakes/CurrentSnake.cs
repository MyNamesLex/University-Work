using UnityEngine;

public class CurrentSnake : MonoBehaviour
{
    public GameObject GetSnakesObject;
    public SnakeManager sm;
    public BoughtNotBoughtUpgrade bnbs;
    public void OnClick()
    {
        switch (gameObject.tag)
        {

            // Gets the snake that has been clicked on

            case "SnakeButton0":
                GetSnakesObject.GetComponent<GetSnakes>().CurrentSelectedSnake = GetSnakesObject.GetComponent<GetSnakes>().GetSnake0;
                break;

            case "SnakeButton1":
                GetSnakesObject.GetComponent<GetSnakes>().CurrentSelectedSnake = GetSnakesObject.GetComponent<GetSnakes>().GetSnake1;
                break;

            case "SnakeButton2":
                GetSnakesObject.GetComponent<GetSnakes>().CurrentSelectedSnake = GetSnakesObject.GetComponent<GetSnakes>().GetSnake2;
                break;

            case "SnakeButton3":
                GetSnakesObject.GetComponent<GetSnakes>().CurrentSelectedSnake = GetSnakesObject.GetComponent<GetSnakes>().GetSnake3;
                break;

            case "SnakeButton4":
                GetSnakesObject.GetComponent<GetSnakes>().CurrentSelectedSnake = GetSnakesObject.GetComponent<GetSnakes>().GetSnake4;
                break;

            // purchase new snake ability

            case "NewSnakeButton":
                if (GetSnakesObject.GetComponent<GetSnakes>().CurrentSelectedSnake == null)
                {
                    bnbs.UpdateText("No selected snake");
                    break;
                }
                else
                {
                    if (sm.Gold >= 2)
                    {
                        switch (sm.Snakes.Count)
                        {
                            case 0:
                                sm.Snake0.SetActive(true);
                                sm.SnakesListOrganise();
                                GetSnakesObject.GetComponent<GetSnakes>().CurrentSelectedSnake = sm.Snake0;
                                break;
                            case 1:
                                sm.Snake1.SetActive(true);
                                sm.SnakesListOrganise();
                                GetSnakesObject.GetComponent<GetSnakes>().CurrentSelectedSnake = sm.Snake1;
                                break;
                            case 2:
                                sm.Snake2.SetActive(true);
                                sm.SnakesListOrganise();
                                GetSnakesObject.GetComponent<GetSnakes>().CurrentSelectedSnake = sm.Snake2;
                                break;
                            case 3:
                                sm.Snake3.SetActive(true);
                                sm.SnakesListOrganise();
                                GetSnakesObject.GetComponent<GetSnakes>().CurrentSelectedSnake = sm.Snake3;
                                break;
                            case 4:
                                sm.Snake4.SetActive(true);
                                sm.SnakesListOrganise();
                                GetSnakesObject.GetComponent<GetSnakes>().CurrentSelectedSnake = sm.Snake4;
                                break;
                        }
                        break;
                    }
                    else
                    {
                        bnbs.UpdateText("Can't afford new snake");
                        break;
                    }
                }

                // sell the current selected snake

            case "SellSnakeButton":
                if (GetSnakesObject.GetComponent<GetSnakes>().CurrentSelectedSnake == null)
                {
                    bnbs.UpdateText("No selected snake");
                    break;
                }
                else
                {
                    GetSnakesObject.GetComponent<GetSnakes>().SellSnakeFunction(GetSnakesObject.GetComponent<GetSnakes>().CurrentSelectedSnake);
                    break;
                }

                // upgrades the current selected snake

            case "UpgradeSnakeButton":
                if (GetSnakesObject.GetComponent<GetSnakes>().CurrentSelectedSnake == null)
                {
                    bnbs.text.text = "No selected snake";
                    bnbs.UpdateText("No selected snake");
                    break;
                }
                else
                {
                    GetSnakesObject.GetComponent<GetSnakes>().UpgradeCurrentSnake(GetSnakesObject.GetComponent<GetSnakes>().CurrentSelectedSnake);
                }
                break;

                // upgrades the currently selected snake without charging gold due to different function
                // in GetSnakes

            case "UpgradeSnakeButtonDev":
                if (GetSnakesObject.GetComponent<GetSnakes>().CurrentSelectedSnake == null)
                {
                    bnbs.text.text = "No selected snake";
                    bnbs.UpdateText("No selected snake");
                    break;
                }
                else
                {
                    GetSnakesObject.GetComponent<GetSnakes>().UpgradeCurrentSnakeDev(GetSnakesObject.GetComponent<GetSnakes>().CurrentSelectedSnake);
                }
                break;

        }
    }
}
