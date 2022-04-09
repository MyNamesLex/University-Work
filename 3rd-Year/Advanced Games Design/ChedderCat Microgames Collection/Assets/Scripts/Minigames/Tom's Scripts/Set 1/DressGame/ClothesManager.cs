using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesManager : MonoBehaviour
{
    [Header("Correct GameObjects")]
    public GameObject CorrectHat;
    public GameObject CorrectShirt;
    public GameObject CorrectPants;
    public GameObject CorrectShoes;

    [Header("GameObject Lists")]
    public List<GameObject> AllHats;
    public List<GameObject> AllShirts;
    public List<GameObject> AllPants;
    public List<GameObject> AllShoes;
    public List<GameObject> AllClothes;

    [Header("Spawn Locations")]
    public GameObject HatSpawn;
    public GameObject ShoeSpawn;
    public GameObject PantsSpawn;
    public GameObject ShirtSpawn;

    public GameObject CorrectHatSpawn;
    public GameObject CorrectShoeSpawn;
    public GameObject CorrectPantsSpawn;
    public GameObject CorrectShirtSpawn;

    public void Start()
    {
        int rngHats = Random.Range(0, AllHats.Count);
        int rngShirts = Random.Range(0, AllShirts.Count);
        int rngPants = Random.Range(0, AllPants.Count);
        int rngShoes = Random.Range(0, AllShoes.Count);

        CorrectHat = AllHats[rngHats];
        CorrectShirt = AllShirts[rngShirts];
        CorrectPants = AllPants[rngPants];
        CorrectShoes = AllShoes[rngShoes];

        int rngX = Random.Range(0, 5);
        int rngY = Random.Range(-4, 4);

        Instantiate(CorrectHat, new Vector3(rngX, rngY, 0), transform.rotation);
        rngX = Random.Range(0, 5);
        rngY = Random.Range(-4, 4);

        Instantiate(CorrectShoes, new Vector3(rngX, rngY, 0), transform.rotation);
        rngX = Random.Range(0, 5);
        rngY = Random.Range(-4, 4);

        Instantiate(CorrectPants, new Vector3(rngX, rngY, 0), transform.rotation);
        rngX = Random.Range(0, 5);
        rngY = Random.Range(-4, 4);

        Instantiate(CorrectShirt, new Vector3(rngX, rngY, 0), transform.rotation);

        GameObject g = Instantiate(CorrectHat, CorrectHatSpawn.transform.position, transform.rotation);
        g.GetComponent<DragObject>().Locked = true;

        GameObject t = Instantiate(CorrectShoes, CorrectShoeSpawn.transform.position, transform.rotation);
        t.GetComponent<DragObject>().Locked = true;

        GameObject x = Instantiate(CorrectPants, CorrectPantsSpawn.transform.position, transform.rotation);
        x.GetComponent<DragObject>().Locked = true;

        GameObject y = Instantiate(CorrectShirt, CorrectShirtSpawn.transform.position, transform.rotation);
        y.GetComponent<DragObject>().Locked = true;
    }
}
