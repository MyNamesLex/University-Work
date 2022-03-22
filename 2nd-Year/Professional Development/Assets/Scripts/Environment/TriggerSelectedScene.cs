using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TriggerSelectedScene : MonoBehaviour
{
    public int ChosenLevel;
    public void OnTriggerEnter(Collider other)
    {
        LevelVoteBox level = FindObjectOfType<LevelVoteBox>();

        NewPlayerMovement Player = FindObjectOfType<NewPlayerMovement>();

        CameraControlloer cam = FindObjectOfType<CameraControlloer>();
        if(level.tele == true)
        {
            cam.Obstruction = Player.Player.transform;
            Player.LevelCompleteInt += 1;
            Debug.Log(ChosenLevel);
            SceneManager.LoadScene(ChosenLevel);
        }
        else
        {
            return;
        }
    }
}
