using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignClothes : MonoBehaviour
{
    [Header("Clothes Items")]
    public GameObject Hat;
    public GameObject Shirt;
    public GameObject Pants;
    public GameObject Shoes;

    [Header("Clothes Manager")]
    public ClothesManager cm;

    [Header("Scene Requirements")]
    public MinigameAction action;

    [Header("Currently Equipped")]
    public bool isShoesEquipped;
    public bool isShirtEquipped;
    public bool isPantsEquipped;
    public bool isHatEquipped;

    [Header("Debug Values")]
    public bool Won;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip CorrectEquipped;
    public AudioClip WrongEquipped;
    public float volume;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Shoes"))
        {
            string correctnameShoes = cm.CorrectShoes.name + "(Clone)";
            if (other.gameObject.name == correctnameShoes)
            {
                isShoesEquipped = true;
                other.GetComponent<DragObject>().Locked = true;
                other.transform.position = Shoes.transform.position;
                audioSource.PlayOneShot(CorrectEquipped, volume);
            }
            else
            {
                Debug.Log("wrong Shoes");
                audioSource.PlayOneShot(WrongEquipped, volume);
                action.LoseMicrogame();
            }
        }
        if (other.CompareTag("Pants") )
        {
            string CorrectPantsName = cm.CorrectPants.name + "(Clone)";
            if (other.gameObject.name == CorrectPantsName)
            {
                isPantsEquipped = true;
                other.GetComponent<DragObject>().Locked = true;
                other.transform.position = Pants.transform.position;
                audioSource.PlayOneShot(CorrectEquipped, volume);
            }
            else
            {
                Debug.Log("wrong Pants");
                audioSource.PlayOneShot(WrongEquipped, volume);
                action.LoseMicrogame();
            }
        }
        if (other.CompareTag("Hat"))
        {
            string CorrectHatName = cm.CorrectHat.name + "(Clone)";
            if (other.gameObject.name == CorrectHatName)
            {
                isHatEquipped = true;
                other.GetComponent<DragObject>().Locked = true;
                other.transform.position = Hat.transform.position;
                audioSource.PlayOneShot(CorrectEquipped, volume);
            }
            else
            {
                Debug.Log("wrong Hat");
                audioSource.PlayOneShot(WrongEquipped, volume);
                action.LoseMicrogame();
            }
        }
        if (other.CompareTag("Shirt"))
        {
            string CorrectShirtName = cm.CorrectShirt.name + "(Clone)";
            if (other.gameObject.name == CorrectShirtName)
            {
                isShirtEquipped = true;
                other.GetComponent<DragObject>().Locked = true;
                other.transform.position = Shirt.transform.position;
                audioSource.PlayOneShot(CorrectEquipped, volume);
            }
            else
            {
                Debug.Log("wrong Shirt");
                audioSource.PlayOneShot(WrongEquipped, volume);
                action.LoseMicrogame();
            }
        }
    }

    private void Update()
    {
        if (isHatEquipped && isShirtEquipped && isPantsEquipped && isShoesEquipped && Won == false)
        {
            Won = true;
            action.WinMicrogame();
        }
    }
}
