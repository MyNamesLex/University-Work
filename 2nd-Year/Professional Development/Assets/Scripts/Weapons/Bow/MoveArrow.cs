using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveArrow : MonoBehaviour
{
    public GameObject InstantiateArrow;

    public int arrowspeed;

    public Rigidbody rigid;

    public NewPlayerMovement player;

    public Camera camera;

    private void Start()
    {
        Rigidbody rigid = InstantiateArrow.GetComponent<Rigidbody>();
        NewPlayerMovement player = GetComponent<NewPlayerMovement>();
        CameraControlloer camera = GetComponent<CameraControlloer>();
    }

    private void Awake()
    {
        rigid.AddForce(camera.transform.forward * arrowspeed, ForceMode.Force);
    }
}
