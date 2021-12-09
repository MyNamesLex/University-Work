using UnityEngine;

public class UpgradeScreen : MonoBehaviour
{
    public GetGold gg;
    public SnakeManager sm;
    public void CloseUpgrades()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
