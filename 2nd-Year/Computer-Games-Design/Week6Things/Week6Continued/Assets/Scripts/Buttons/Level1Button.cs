﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Level1Button : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene(2);
    }
}
