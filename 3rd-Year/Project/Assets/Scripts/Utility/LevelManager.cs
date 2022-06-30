using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance = null;
    public int LevelsPassed = 1;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }
        if (instance == this) return;
        Destroy(gameObject);
    }
    public void UpdateCounter()
    {
        LevelsPassed++;
    }

    private void OnLevelWasLoaded(int level)
    {
        if(level == 0) // Main Menu
        {
            LevelsPassed = 1;
        }
    }
}
