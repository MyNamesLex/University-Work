using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMUIScript : MonoBehaviour
{
    public static BGMUIScript _instance;
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
        if(SceneManager.GetActiveScene().name == "RestStop")
        {
            Destroy(gameObject);
        }
    }
}
