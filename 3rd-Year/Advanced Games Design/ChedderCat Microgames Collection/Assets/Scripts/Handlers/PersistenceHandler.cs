using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PersistenceHandler : MonoBehaviour
{
    public static PersistenceHandler instance = null;
    [Header("Persistent Values")]
    public int points;

    public int startLives;
    public int lives;

    public bool isFreeplay;

    [Header("Acessibility")]
    public bool Accessibility = false;

    [Header("Background Music")]
    public AudioSource audioSource;

    private void Start()
    {
        audioSource.Play();
    }

    private void OnLevelWasLoaded(int level) // reset freeplay when being moved back to mainmenu - Tom
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            isFreeplay = false;
            lives = startLives;
        }
    }

    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }
        if (instance == this)
        {
            Destroy(gameObject);
        }
    }
}
