using System.Collections;
using UnityEngine;

public class ExplosionRadius : MonoBehaviour
{
    public CircleCollider2D ExplosionRadiusCircle;
    public bool Moved = false;
    public bool InCourotine = false;
    public void Explode(GameObject g, GameObject AbilityCaster)
    {
        transform.position = g.transform.position;
        transform.localScale = new Vector3(AbilityCaster.GetComponent<AbilitiesManager>().ExplosionSize, AbilityCaster.GetComponent<AbilitiesManager>().ExplosionSize, AbilityCaster.GetComponent<AbilitiesManager>().ExplosionSize);
        StartCoroutine(ExplodeTimer(g, AbilityCaster));
    }
    IEnumerator ExplodeTimer(GameObject g, GameObject AbilityCaster)
    {
        if (InCourotine == false)
        {
            transform.position = g.transform.position;
            InCourotine = true;
            Debug.Log("AbilityCast Name = " + AbilityCaster.gameObject.name);
            ExplosionRadiusCircle.radius = AbilityCaster.GetComponent<AbilitiesManager>().ExplosionSize;
            Debug.Log("ExplosionSize = " + AbilityCaster.GetComponent<AbilitiesManager>().ExplosionSize);
            Debug.Log("ExplosionRadiusCircle.radius = " + ExplosionRadiusCircle.radius);
            yield return new WaitForSeconds(2);
            Destroy(gameObject);
            Debug.Log("Hit End Of ExplodeTimer");
            yield return null;
        }
    }
}
