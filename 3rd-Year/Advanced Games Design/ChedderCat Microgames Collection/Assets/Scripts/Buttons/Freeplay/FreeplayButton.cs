using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeplayButton : MonoBehaviour
{
    public GameObject ShowFreeplayPanel;
    public PersistenceHandler persistenceHandler;
    public void OnClick()
    {
        GameObject g = GameObject.FindGameObjectWithTag("PersistenceHandler");
        persistenceHandler = g.GetComponent<PersistenceHandler>();
        if(ShowFreeplayPanel.activeInHierarchy == true)
        {
            persistenceHandler.isFreeplay = false;
            ShowFreeplayPanel.SetActive(false);
        }
        else
        {
            persistenceHandler.isFreeplay = true;
            ShowFreeplayPanel.SetActive(true);
        }
    }
}
