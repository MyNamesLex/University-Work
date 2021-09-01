 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1); // load scene 1 (SampleScene) in the build settings
    }
    public void Back()
    {
        SceneManager.LoadScene(0); // load scene 0 (Menu) in the build settings
    }

    public void Controls()
    {
        SceneManager.LoadScene(7); // load scene 7 (Controls) in the build settings
    }
}
