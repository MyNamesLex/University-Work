using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Football : MonoBehaviour
{
    [Header("Potential Score Positions")]
    public List<GameObject> Spots;

    [Header("Chosen Position")]
    public GameObject ChosenSpot;

    [Header("Speed")]
    public float Speed;

    [Header("Goalkeeper")]
    public GoalKeeper gk;
    public float RangeXPos;

    [Header("Been Caught")]
    public bool isCaught = false;
    void Start()
    {
        int rng = Random.Range(0, Spots.Count);
        ChosenSpot = Spots[rng];
    }
    public void Update()
    {
        float s = Speed * Time.deltaTime;
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, ChosenSpot.transform.position, s);

        RangeXPos = Mathf.Clamp(RangeXPos, gameObject.transform.position.x, gk.transform.position.x);

        if(Input.GetKeyDown(KeyCode.Space) && gameObject.transform.position.z < 1 && gameObject.transform.position.z >= 0.8f && RangeXPos <= 0.9f && RangeXPos >= 0.5f)
        {
            gk.Caught(gameObject);
        }
    }
}
