using System.Collections;
using TMPro;
using UnityEngine;

public class BoughtNotBoughtUpgrade : MonoBehaviour
{
    public TextMeshProUGUI text;

    public void UpdateText(string NewText)
    {
        text.text = NewText;
    }
}
