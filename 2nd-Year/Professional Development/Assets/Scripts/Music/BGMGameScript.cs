using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMGameScript : MonoBehaviour
{
    public static BGMGameScript _instance;
    void Awake()
    {
        if (_instance)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Update()
    {
        if(SceneManager.GetActiveScene().name == "WinScreen" || SceneManager.GetActiveScene().name == "LoseScreen")
        {
            Destroy(gameObject);
        }
    }
}
