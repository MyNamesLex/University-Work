using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoadCam : MonoBehaviour
{
    // Start is called before the first frame update

    public static DontDestroyOnLoadCam instance;

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
