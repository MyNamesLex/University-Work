﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void RestartGame()
    {
        { Time.timeScale = 1; }
        SceneManager.LoadScene(1); //reloads the scene so it restarts the game
    }
}
