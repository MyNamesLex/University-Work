using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GetNumbers : MonoBehaviour
{
    public TextMesh Option1;
    public TextMesh Option2;
    public TextMesh Option3;


    public void UpdateNumbers()
    {
        LevelVoteBox vote = FindObjectOfType<LevelVoteBox>();

        Option1 = (TextMesh)GameObject.Find("Option1Text").GetComponent<TextMesh>();
        Option2 = (TextMesh)GameObject.Find("Option2Text").GetComponent<TextMesh>();
        Option3 = (TextMesh)GameObject.Find("Option3Text").GetComponent<TextMesh>();

        Option1.text = "Option 1: " + vote.VoteOne;
        Option2.text = "Option 2: " + vote.VoteTwo;
        Option3.text = "Option 3: " + vote.VoteThree;
    }
}
