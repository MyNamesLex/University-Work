using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoadDuplicate : MonoBehaviour
{
    // Start is called before the first frame update

    public static DontDestroyOnLoad instance;

    void Start()
    {
        DontDestroyOnLoad(this);
    }
}
