using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoadPostProcessing : MonoBehaviour
{
    // Start is called before the first frame update

    public static DontDestroyOnLoadPostProcessing instance;

    void Start()
    {
        DontDestroyOnLoad(this);
    }

    void Awake()
    {
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
}
