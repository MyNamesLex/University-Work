using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class LevelVoteBox : MonoBehaviour
{
    public static LevelVoteBox Instance;

    public int VoteOne = 0;
    public int VoteTwo = 0;
    public int VoteThree = 0;

    public int timeramount;
    public int buildindex;

    public Text FirstOption;
    public Text SecondOption;
    public Text ThirdOption;

    public string level;

    public bool voteenabled = false;

    public bool tele = false;

    public bool LastLevel = false;

    public int LevelCompleteIntCheck = 0;

    public int activescene;

    void Awake()
    {

        if (Instance)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        voteenabled = true;
        VoteOne = 0;
        VoteTwo = 0;
        VoteThree = 0;

        StartCoroutine(Timer());

        FirstRNG();
        SecondRNG();
        ThirdRNG();
     
    }

    public void Update()
    {
        if(LevelCompleteIntCheck == 1)
        {
            LastLevel = true;
            TriggerSelectedScene trig = FindObjectOfType<TriggerSelectedScene>();
            buildindex = 10;
            trig.ChosenLevel = buildindex;
            voteenabled = false;

            FirstOption.text = "Last Level (Voting Disabled)";
            SecondOption.text = "Last Level (Voting Disabled)";
            ThirdOption.text = "Last Level (Voting Disabled)";
        }

        activescene = SceneManager.GetActiveScene().buildIndex;
    }

    public void FirstRNG()
    {
        activescene = SceneManager.GetActiveScene().buildIndex;
        if (LastLevel == false)
        {
        int RNG = Random.Range(2, 6);

            switch (RNG)
            {
                case 1:
                    if (activescene == 4)
                    {
                        FirstRNG();
                        return;
                    }
                    else
                    {
                        FirstOption.text = "Chill";
                        if (FirstOption.text == SecondOption.text)
                            FirstRNG();
                        else if (FirstOption.text == ThirdOption.text)
                            FirstRNG();

                        break;
                    }
                    break;

                case 2:
                    if (activescene == 5)
                    {
                        FirstRNG();
                        return;
                    }
                    else
                    {
                        FirstOption.text = "Easy";
                        if (FirstOption.text == SecondOption.text)
                            FirstRNG();
                        if (FirstOption.text == ThirdOption.text)
                            FirstRNG();

                        break;
                    }
                    break;

                case 3:
                    if (activescene == 7)
                    {
                        FirstRNG();
                        return;
                    }
                    else
                    {
                        FirstOption.text = "Medium";
                        if (FirstOption.text == SecondOption.text)
                            FirstRNG();
                        if (FirstOption.text == ThirdOption.text)
                            FirstRNG();
                        break;
                    }
                    break;

                case 4:
                    if (activescene == 6)
                    {
                        FirstRNG();
                        return;
                    }
                    else
                    {
                        FirstOption.text = "Hard";
                        if (FirstOption.text == SecondOption.text)
                            FirstRNG();
                        if (FirstOption.text == ThirdOption.text)
                            FirstRNG();
                        break;
                    }
                    break;

                case 5:
                    if (activescene == 8)
                    {
                        FirstRNG();
                        return;
                    }
                    else
                    {
                        FirstOption.text = "Practically Instadeath";
                        if (FirstOption.text == SecondOption.text)
                            FirstRNG();
                        if (FirstOption.text == ThirdOption.text)
                            FirstRNG();
                        break;
                    }
                    break;

                case 6:
                    if (activescene == 9)
                    {
                        FirstRNG();
                        return;
                    }
                    else
                    {
                        FirstOption.text = "Hard As You Go";
                        if (FirstOption.text == SecondOption.text)
                            FirstRNG();
                        if (FirstOption.text == ThirdOption.text)
                            FirstRNG();
                        break;
                    }
                    break;
            }
        }
    }

    public void SecondRNG()
    {
        activescene = SceneManager.GetActiveScene().buildIndex;
        if (LastLevel == false)
        {
            int RNG = Random.Range(2, 6);

            switch (RNG)
            {
                case 1:
                    if (activescene == 4)
                    {
                        SecondRNG();
                        return;
                    }
                    else
                    {

                        SecondOption.text = "Chill";
                        if (SecondOption.text == FirstOption.text)
                            SecondRNG();
                        else if (SecondOption.text == ThirdOption.text)
                            SecondRNG();
                        break;
                    }
                    break;
                case 2:
                    if (activescene == 5)
                    {
                        SecondRNG();
                        return;
                    }
                    else
                    {


                        SecondOption.text = "Easy";
                        if (SecondOption.text == FirstOption.text)
                            SecondRNG();
                        if (SecondOption.text == ThirdOption.text)
                            SecondRNG();
                        if (activescene == 5)
                            SecondRNG();
                        break;
                    }
                    break;
                case 3:
                    if (activescene == 7)
                    {
                        SecondRNG();
                        return;
                    }
                    else
                    {


                        SecondOption.text = "Medium";
                        if (SecondOption.text == FirstOption.text)
                            SecondRNG();
                        if (SecondOption.text == ThirdOption.text)
                            SecondRNG();
                        if (activescene == 7)
                            SecondRNG();

                        break;
                    }
                    break;
                case 4:
                    if (activescene == 6)
                    {
                        SecondRNG();
                        return;
                    }
                    else
                    {
                        SecondOption.text = "Hard";
                        if (SecondOption.text == FirstOption.text)
                            SecondRNG();
                        if (SecondOption.text == ThirdOption.text)
                            SecondRNG();
                        if (activescene == 6)
                            SecondRNG();

                        break;
                    }
                    break;
                case 5:
                    if (activescene == 8)
                    {
                        SecondRNG();
                        return;
                    }
                    else
                    {
                        SecondOption.text = "Practically Instadeath";
                        if (SecondOption.text == FirstOption.text)
                            SecondRNG();
                        if (SecondOption.text == ThirdOption.text)
                            SecondRNG();
                        if (activescene == 8)
                            SecondRNG();

                        break;
                    }
                    break;

                case 6:
                    if (activescene == 9)
                    {
                        SecondRNG();
                        return;
                    }
                    else
                    {
                        SecondOption.text = "Hard As You Go";
                        if (SecondOption.text == FirstOption.text)
                            SecondRNG();
                        if (SecondOption.text == ThirdOption.text)
                            SecondRNG();
                        if (activescene == 9)
                            SecondRNG();

                        break;
                    }
                    break;
            }
        }
    }

    public void ThirdRNG()
    {
        activescene = SceneManager.GetActiveScene().buildIndex;
        if (LastLevel == false)
        {
            int RNG = Random.Range(2, 6);

            switch (RNG)
            {
                case 1:
                    if (activescene == 4)
                    {
                        Debug.Log("Repeat");
                        ThirdRNG();
                        return;
                    }
                    else
                    {
                        ThirdOption.text = "Chill";
                        if (ThirdOption.text == FirstOption.text)
                            ThirdRNG();
                        else if (ThirdOption.text == SecondOption.text)
                            ThirdRNG();

                        break;
                    }
                    break;

                case 2:
                    if (activescene == 5)
                    {
                        ThirdRNG();
                        return;
                    }
                    else
                    {
                        ThirdOption.text = "Easy";
                        if (ThirdOption.text == FirstOption.text)
                            ThirdRNG();
                        if (ThirdOption.text == SecondOption.text)
                            ThirdRNG();
                        if (activescene == 5)
                            ThirdRNG();

                        break;
                    }
                    break;
                case 3:
                    if (activescene == 7)
                    {
                        ThirdRNG();
                        return;
                    }
                    else
                    {
                        ThirdOption.text = "Medium";
                        if (ThirdOption.text == FirstOption.text)
                            ThirdRNG();
                        if (ThirdOption.text == SecondOption.text)
                            ThirdRNG();
                        if (activescene == 7)
                            ThirdRNG();

                        break;
                    }
                    break;
                case 4:
                    if (activescene == 6)
                    {
                        ThirdRNG();
                        return;
                    }
                    else
                    {
                        ThirdOption.text = "Hard";
                        if (ThirdOption.text == FirstOption.text)
                            ThirdRNG();
                        if (ThirdOption.text == SecondOption.text)
                            ThirdRNG();
                        if (activescene == 6)
                            ThirdRNG();

                        break;
                    }
                    break;
                case 5:
                    if (activescene == 8)
                    {
                        ThirdRNG();
                        return;
                    }
                    else
                    {
                        ThirdOption.text = "Practically Instadeath";
                        if (ThirdOption.text == FirstOption.text)
                            ThirdRNG();
                        if (ThirdOption.text == SecondOption.text)
                            ThirdRNG();
                        if (activescene == 8)
                            ThirdRNG();

                        break;
                    }
                    break;
                case 6:
                    if (activescene == 9)
                    {
                        ThirdRNG();
                        return;
                    }
                    else
                    {
                        ThirdOption.text = "Hard As You Go";
                        if (ThirdOption.text == FirstOption.text)
                            ThirdRNG();
                        if (ThirdOption.text == SecondOption.text)
                            ThirdRNG();
                        if (activescene == 9)
                            ThirdRNG();

                        break;
                    }
                    break;
            }
        }
    }

    //getting player votes
    public void AddVoteOne(int amount)
    {
        if(voteenabled == true && LastLevel == false)
        {
            VoteOne += amount;
            GetNumbers get = FindObjectOfType<GetNumbers>();
            get.UpdateNumbers();
        }
        else
        {
            return;
        }
    }

    public void AddVoteTwo(int amount)
    {
        if (voteenabled == true && LastLevel == false)
        {
            VoteTwo += amount;
            GetNumbers get = FindObjectOfType<GetNumbers>();
            get.UpdateNumbers();
        }
        else
        {
            return;
        }
    }

    public void AddVoteThree(int amount)
    {
        if (voteenabled == true && LastLevel == false)
        {
            VoteThree += amount;
            GetNumbers get = FindObjectOfType<GetNumbers>();
            get.UpdateNumbers();
        }
        else
        {
            return;
        }
    }


    //timer

    IEnumerator Timer()
    {
        while(true)
        {
            yield return new WaitForSeconds(timeramount);
            AddAll();
            tele = true;

            break;
        }
    }


    //Count votes
    public void AddAll()
    {
        int[] maxvotes = { VoteOne, VoteTwo, VoteThree};
        int vote = maxvotes.Max();

        if(vote == VoteOne)
        {
            level = FirstOption.text;
            PickLevel();
        }
        if (vote == VoteTwo)
        {
            level = SecondOption.text;
            PickLevel();
        }
        if (vote == VoteThree)
        {
            level = ThirdOption.text;
            PickLevel();
        }
    }

    public void PickLevel()
    {
        GameObject NextLevel = GameObject.Find("NextLevel");
        NextLevel.SetActive(true);
        if (level == "Chill")
        {
            TriggerSelectedScene trig = FindObjectOfType<TriggerSelectedScene>();
            //level scene
            int RNG = Random.Range(1, 1);
           
            switch(RNG)
            {
                case 1:
                    level = "4";
                    buildindex = 4;
                    trig.ChosenLevel = buildindex; 
                    voteenabled = false;
                    break;
                case 2:
                    //string collects chosen level which would have a unity scene file name = level and then trig.Chosen level = unity scene file name string
                    trig.ChosenLevel = buildindex;
                    voteenabled = false;
                    break;
            }

        }

        if (level == "Easy")
        {
            TriggerSelectedScene trig = FindObjectOfType<TriggerSelectedScene>();
            //level scene
            int RNG = Random.Range(1, 1);
            switch (RNG)
            {
                case 1:
                    //string collects chosen level which would have a unity scene file name = level and then trig.Chosen level = unity scene file name string
                    level = "5";
                    buildindex = 5;
                    trig.ChosenLevel = buildindex;
                    voteenabled = false;
                    break;
                case 2:
                    //string collects chosen level which would have a unity scene file name = level and then trig.Chosen level = unity scene file name string
                    trig.ChosenLevel = buildindex;
                    voteenabled = false;
                    break;
            }
        }

        if (level == "Medium")
        {
            TriggerSelectedScene trig = FindObjectOfType<TriggerSelectedScene>();
            //level scene
            int RNG = Random.Range(1, 1);
            switch (RNG)
            {
                case 1:
                    //string collects chosen level which would have a unity scene file name = level and then trig.Chosen level = unity scene file name string
                    level = "7";
                    buildindex = 7;
                    trig.ChosenLevel = buildindex;
                    voteenabled = false;
                    break;
                case 2:
                    //string collects chosen level which would have a unity scene file name = level and then trig.Chosen level = unity scene file name string
                    trig.ChosenLevel = buildindex;
                    voteenabled = false;
                    break;
            }
        }

        if (level == "Hard")
        {
            TriggerSelectedScene trig = FindObjectOfType<TriggerSelectedScene>();
            //level scene
            int RNG = Random.Range(1, 1);
            switch (RNG)
            {
                case 1:
                    //string collects chosen level which would have a unity scene file name = level and then trig.Chosen level = unity scene file name string
                    level = "6";
                    buildindex = 6;
                    trig.ChosenLevel = buildindex;
                    voteenabled = false;
                    break;
                case 2:
                    //string collects chosen level which would have a unity scene file name = level and then trig.Chosen level = unity scene file name string
                    trig.ChosenLevel = buildindex;
                    voteenabled = false;
                    break;
            }
        }

        if (level == "Practically Instadeath")
        {
            TriggerSelectedScene trig = FindObjectOfType<TriggerSelectedScene>();
            //level scene
            int RNG = Random.Range(1, 1);
            switch (RNG)
            {
                case 1:
                    //string collects chosen level which would have a unity scene file name = level and then trig.Chosen level = unity scene file name string
                    level = "8";
                    buildindex = 8;
                    trig.ChosenLevel = buildindex;
                    voteenabled = false;
                    break;
                case 2:
                    //string collects chosen level which would have a unity scene file name = level and then trig.Chosen level = unity scene file name string
                    trig.ChosenLevel = buildindex;
                    voteenabled = false;
                    break;
            }
        }

        if (level == "Hard As You Go")
        {
            TriggerSelectedScene trig = FindObjectOfType<TriggerSelectedScene>();
            //level scene
            int RNG = Random.Range(1, 1);
            switch (RNG)
            {
                case 1:
                    //string collects chosen level which would have a unity scene file name = level and then trig.Chosen level = unity scene file name string
                    level = "9";
                    buildindex = 9;
                    trig.ChosenLevel = buildindex;
                    voteenabled = false;
                    break;
                case 2:
                    //string collects chosen level which would have a unity scene file name = level and then trig.Chosen level = unity scene file name string
                    trig.ChosenLevel = buildindex;
                    voteenabled = false;
                    break;
            }
        }

        if (level == "Boss Fight")
        {
            TriggerSelectedScene trig = FindObjectOfType<TriggerSelectedScene>();
            //level scene
            int RNG = Random.Range(1, 1);
            switch (RNG)
            {
                case 1:
                    //string collects chosen level which would have a unity scene file name = level and then trig.Chosen level = unity scene file name string
                    level = "10";
                    buildindex = 10;
                    trig.ChosenLevel = buildindex;
                    voteenabled = false;
                    break;
                case 2:
                    //string collects chosen level which would have a unity scene file name = level and then trig.Chosen level = unity scene file name string
                    trig.ChosenLevel = buildindex;
                    voteenabled = false;
                    break;
            }
        }
    }
}


