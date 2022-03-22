using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RestStop : MonoBehaviour
{
    public void OnCall()
    {
        SceneManager.LoadScene(4);

    }
}
