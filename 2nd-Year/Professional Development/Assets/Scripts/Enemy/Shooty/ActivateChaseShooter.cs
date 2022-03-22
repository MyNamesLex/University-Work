using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateChaseShooter : MonoBehaviour
{
    public GameObject eyes;
    private void Update()
    {
        Raycast();
    }

    private void Raycast()
    {
        Vector3 origin = transform.position;

        Vector3 forward = transform.forward;
        Vector3 left = transform.forward + Vector3.left;
        Vector3 right = transform.forward + Vector3.right;

        Debug.DrawRay(origin, forward * 100f, Color.red);
        Debug.DrawRay(origin, left * 100f, Color.red);
        Debug.DrawRay(origin, right * 100f, Color.red);

        Ray ray = new Ray(origin, forward);
        Ray ray2 = new Ray(origin, left);
        Ray ray3 = new Ray(origin, right);

        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {

            if (raycastHit.collider.gameObject.name == "Player")
            {
                ShootEnemy.IsStalking = true;
            }
            else if (Stalker.IsStalking == true && raycastHit.collider)
            {
                StartCoroutine(Forget());
            }
        }

        if (Physics.Raycast(ray2, out RaycastHit raycastHit2))
        {
            if (raycastHit2.collider.gameObject.name == "Player")
            {
                ShootEnemy.IsStalking = true;
            }
            else if (ShootEnemy.IsStalking == true && !raycastHit2.collider)
            {
                StartCoroutine(Forget());
            }
        }

        if (Physics.Raycast(ray3, out RaycastHit raycastHit3))
        {
            if (raycastHit3.collider.gameObject.name == "Player")
            {
                ShootEnemy.IsStalking = true;
            }
            else if (ShootEnemy.IsStalking == true && !raycastHit3.collider)
            {
                StartCoroutine(Forget());
            }
        }
    }

    IEnumerator Forget()
    {
        if (true)
        {
            yield return new WaitForSeconds(5);
            ShootEnemy.IsStalking = false;
            yield break;
        }
    }
}
