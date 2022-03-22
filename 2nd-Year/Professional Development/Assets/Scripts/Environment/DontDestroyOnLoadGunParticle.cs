using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoadGunParticle : MonoBehaviour
{
    // Start is called before the first frame update

    public static DontDestroyOnLoadGunParticle instance;

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
