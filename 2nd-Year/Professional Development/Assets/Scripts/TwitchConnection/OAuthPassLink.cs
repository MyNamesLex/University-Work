using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OAuthPassLink : MonoBehaviour
{
    public void OnClick()
    {
        Application.OpenURL("https://twitchapps.com/tmi/");
    }
}
