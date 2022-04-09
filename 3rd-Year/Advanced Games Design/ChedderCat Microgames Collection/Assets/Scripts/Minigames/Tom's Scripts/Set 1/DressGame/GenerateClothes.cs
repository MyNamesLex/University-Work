using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateClothes : MonoBehaviour
{

    // Make the correct clothes appear on screen aswell as the wrong clothes - Tom
    // (Instantiate prefabs) - Tom
    //public float

    [Header("Random Clothes")]
    public ClothesManager Clothes;

    [Header("SceneRequirements")]
    public MinigameAction action;

    [Header("Save File")]
    public MinigameAction.minigameData data;

    [Header("Amount Of Extra Clothes")]
    public int ExtraClothes;

    // Start is called before the first frame update
    void Start()
    {
        data = action.loaded;
        GenerateWrongClothes();

        ExtraClothes = data.timesPlayed;

        if (data.timesPlayed >= 5)
        {
            ExtraClothes = 5;
        }
    }

    public void GenerateWrongClothes()
    {

            /*
            for (int i = 0; i < data.timesPlayed; i++)
            {
                GenerateWrongClothes();
                i++;
            }
            */
            /*
            for (int i = 0; i < 1; i++)
            {
                GenerateWrongClothes();
                i++;
            }
            */

        int rng = Random.Range(0, Clothes.AllClothes.Count);
        if (Clothes.AllClothes.Contains(Clothes.AllClothes[rng]))
        {
            int rngX = Random.Range(-1, 8);
            int rngY = Random.Range(-4, 4);
            GameObject g = Instantiate(Clothes.AllClothes[rng], new Vector3(rngX, rngY, 0), new Quaternion(0, 0, 0, 0));
            if (g == Clothes.CorrectHat)
            {
                Destroy(g);
                GenerateWrongClothes();
            }
            if(g == Clothes.CorrectShoes)
            {
                Destroy(g);
                GenerateWrongClothes();
            }
            if(g == Clothes.CorrectShirt)
            {
                Destroy(g);
                GenerateWrongClothes();
            }
            if(g == Clothes.CorrectPants)
            {
                Destroy(g);
                GenerateWrongClothes();
            }
        }
    }
}
