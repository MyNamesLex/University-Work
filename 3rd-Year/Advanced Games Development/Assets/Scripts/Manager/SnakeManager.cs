using System.Collections.Generic;
using UnityEngine;

public class SnakeManager : MonoBehaviour
{
    public List<GameObject> Snakes;

    [Header("Snake Objects")]
    public GameObject Snake0;
    public GameObject Snake1;
    public GameObject Snake2;
    public GameObject Snake3;
    public GameObject Snake4;

    public int Gold;

    public void Start()
    {
        SnakesListOrganise();
    }

    // organises the snakes by order in the hierarchy and adds them to the Snakes list

    public void SnakesListOrganise()
    {
        Snakes.Clear();
        if (Snake0 != null)
        {
            if (Snake0.activeInHierarchy == true)
            {
                Snakes.Add(Snake0);
            }
        }
        if (Snake1 != null)
        {
            if (Snake1.activeInHierarchy == true)
            {
                Snakes.Add(Snake1);
            }
        }
        if (Snake2 != null)
        {
            if (Snake2.activeInHierarchy == true)
            {
                Snakes.Add(Snake2);
            }
        }
        if (Snake3 != null)
        {
            if (Snake3.activeInHierarchy == true)
            {
                Snakes.Add(Snake3);
            }
        }
        if (Snake4 != null)
        {
            if (Snake4.activeInHierarchy == true)
            {
                Snakes.Add(Snake4);
            }
        }
    }
    public void RemoveSnake(GameObject g)
    {
        Snakes.Remove(g);
    }
}
