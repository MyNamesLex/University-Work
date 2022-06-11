using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelineScript : MonoBehaviour
{
    public Player player;
    public CorrectIncorrect ci;
    // Start is called before the first frame update

    public void StartTimeline()
    {
        ci.EditText("Wrong Answer");
        player.InTimeline = true;
        player.Freeze = true;
    }

    private void OnDisable()
    {
        player.InTimeline = false;
        player.Freeze = false;
    }
}
