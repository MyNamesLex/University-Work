using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartThrows : MonoBehaviour
{
    public BossLevelJoggingBoss boss;
    public GameObject BossHealthCanvas;
    public GameObject Camera;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            boss.StartThrows = true;
            BossHealthCanvas.SetActive(true);
        }
    }
}
