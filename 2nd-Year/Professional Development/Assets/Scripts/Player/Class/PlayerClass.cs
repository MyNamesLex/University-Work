using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class PlayerClass : MonoBehaviour
{
    public bool scout = false;
    public bool engineer = false;
    public bool medic = false;
    public bool soldier = false;
    public bool janitor = false;

    public Text scouttext;
    public Text engineertext;
    public Text medictext;
    public Text soldiertext;
    public Text janitortext;

    public Text Timertext;

    public int scoutint;
    public int engineerint;
    public int medicint;
    public int soldierint;
    public int janitorint;

    public static PlayerClass instance;

    public bool StopVote;
    public bool StopDupe;
    public bool PlayerChooseVote = false;

    public float timerint;

    public string scenestring;

    void Awake()
    {
        scenestring = SceneManager.GetActiveScene().name;

        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }


    public void Start()
    {
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        while(true)
        {
            yield return new WaitForSeconds(timerint);
            StopVote = true;
            break;
        }
    }

    //get votes

    public void ScoutInt()
    {
        if(StopVote == false)
        {
            scoutint += 1;
            scouttext.text = "Scout Votes: " + scoutint;
        }
        else
        {
            return;
        }
    }
    public void EngineerInt()
    {
        if (StopVote == false)
        {
            engineerint += 1;
            engineertext.text = "Engineer Votes: " + engineerint;
        }
        else
        {
            return;
        }
    }
    public void MedicInt()
    {
        if (StopVote == false)
        {
            medicint += 1;
            medictext.text = "Medic Votes: " + medicint;
        }
        else
        {
            return;
        }
    }
    public void SoldierInt()
    {
        if (StopVote == false)
        {
            soldierint += 1;
            soldiertext.text = "Soldier Votes: " + soldierint;
        }
        else
        {
            return;
        }
    }
    public void JanitorInt()
    {
        if (StopVote == false)
        {
            janitorint += 1;
            janitortext.text = "Janitor Votes: " + janitorint;
        }
        else
        {
            return;
        }
    }

    public void Update()
    {
        if(scenestring == "PlayerChooseClass")
        {
            PlayerChooseVote = true;
        }

        if(StopVote == true && PlayerChooseVote == false)
        {
            TallyOverall();
        }
        else if(PlayerChooseVote == false)
        {
            timerint -= Time.deltaTime;
            Timertext.text = "Time Left: " + timerint;
        }
        else
        {
            return;
        }
    }

    public void TallyOverall()
    {
        //TALLY UP VOTES

        if(StopDupe == false)
        {
            StopDupe = true;
            int[] biggest = { engineerint, soldierint, medicint, janitorint, scoutint };
            int mostvoted = biggest.Max();

            if(engineerint == mostvoted)
            {
                Engineer();
            }
            if(scoutint == mostvoted)
            {
                Scout();
            }
            if(medicint == mostvoted)
            {
                Medic();
            }
            if(janitorint == mostvoted)
            {
                Janitor();
            }
            if(soldierint == mostvoted)
            {
                Soldier();
            }


            SceneManager.LoadScene(4);
            return;
        }
    }

    //Assigning Classses

    public void Scout()
    {
        scout = true;
        engineer = false;
        soldier = false;
        janitor = false;
        medic = false;
    }

    public void Engineer()
    {
        scout = false;
        engineer = true;
        soldier = false;
        janitor = false;
        medic = false;
    }

    public void Soldier()
    {
        scout = false;
        engineer = false;
        soldier = true;
        janitor = false;
        medic = false;
    }

    public void Medic()
    {
        scout = false;
        engineer = false;
        soldier = false;
        janitor = false;
        medic = true;
    }

    public void Janitor()
    {
        scout = false;
        engineer = false;
        soldier = false;
        janitor = true;
        medic = false;
    }

}
