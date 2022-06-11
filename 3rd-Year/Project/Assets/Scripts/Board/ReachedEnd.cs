using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReachedEnd : MonoBehaviour
{
    public LevelManager lm;
    public bool Hit = false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && Hit == false)
        {
            Hit = true;
            lm.UpdateCounter();
            SceneManager.LoadScene(lm.LevelsPassed + 1);
            Debug.Log("Levels passed: " + lm.LevelsPassed);
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        if(lm == null)
        {
            GameObject g = GameObject.FindGameObjectWithTag("LevelCounter");
            lm = g.GetComponent<LevelManager>();
        }
    }
}
