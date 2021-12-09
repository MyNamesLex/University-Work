using System.Collections.Generic;
using UnityEngine;

public class EnemiesOnScreen : MonoBehaviour
{
    public List<GameObject> EnemiesOnScreenList;
    public GameObject NearestEnemy;
    public GameObject PlayerHead;
    public AbilitiesManager ab0;
    public AbilitiesManager ab1;
    public AbilitiesManager ab2;
    public AbilitiesManager ab3;
    public AbilitiesManager ab4;

    public void Update()
    {
        if (PlayerHead == null) //finds the players head
        {
            PlayerHead = GameObject.FindGameObjectWithTag("Snake0");
        }
        else
        {
            GetClosestObject();
        }
    }

    public void GetClosestObject()
    {
        float closest = 200; //max range
        NearestEnemy = null;
        for (int i = 0; i < EnemiesOnScreenList.Count; i++)  //Cycles through every enemy on screen
        {
            if (EnemiesOnScreenList[i].gameObject == null) //failsafe if the current object is missing/destroyed
            {
                return;
            }
            else
            {
                float dist = Vector3.Distance(EnemiesOnScreenList[i].transform.position, PlayerHead.transform.position);
                //distance between the current enemy being iterated through and the player
                if (dist < closest) // if the current enemy iteration is closer then the one set to closest replace it
                {
                    closest = dist;
                    NearestEnemy = EnemiesOnScreenList[i];
                }
            }
        }
    }
}
