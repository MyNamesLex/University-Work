using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGameBossLevelJogging : MonoBehaviour
{
    public MinigameAction action;
    public AudioSource audioSource;
    public AudioClip won;
    public float volume;
    private bool Hit = false; // avoid dupe
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && Hit == false)
        {
            Hit = true;
            audioSource.PlayOneShot(won, volume);
            action.WinMicrogame();
        }
    }
}
