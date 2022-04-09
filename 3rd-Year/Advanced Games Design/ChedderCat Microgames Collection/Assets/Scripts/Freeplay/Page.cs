using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page : MonoBehaviour
{
    public List<GameObject> PageList;
    private int internaltracker;
    public void OnClickNext()
    {
        if (internaltracker >= PageList.Count)
        {
            Debug.Log("Internal tracker greater or equal to length of PageList");
        }
        else
        {
            PageList[internaltracker].gameObject.SetActive(false);
            internaltracker++;
            PageList[internaltracker].gameObject.SetActive(true);
        }
    }

    public void OnClickBack()
    {
        if (internaltracker < 0)
        {
            Debug.Log("Internal tracker less then 0");
        }
        else
        {
            PageList[internaltracker].gameObject.SetActive(false);
            internaltracker--;
            PageList[internaltracker].gameObject.SetActive(true);
        }
    }
}
