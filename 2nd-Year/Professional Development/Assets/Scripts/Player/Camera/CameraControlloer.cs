using UnityEngine;
using System.Collections;

public class CameraControlloer : MonoBehaviour
{

    GameObject player;

    public GameObject PlayerMesh;

    public Transform Target;

    public Transform Obstruction;
    float zoomspeed = 2f;

    public float rotationspeed = 1;
    public float distance;
    public float originaldistance = -5;

    private const float YMin = -50.0f;
    private const float YMax = 50.0f;

    public bool Zoomed = false;

    public Transform lookAt;

    private float currentX = 0.0f;
    private float currentY = 0.0f;
    public float sensivity = 4.0f;

    void Start()
    {
        player = GameObject.Find("Player");
        Target = player.gameObject.transform;
        Obstruction = Target;
    }

    void Update()
    {
        player = GameObject.Find("Player");
        Target = player.gameObject.transform;


        if(Input.GetMouseButtonDown(1))
        {
            if(Zoomed == false)
            {
                Zoomed = true;
                return;
            }
            if(Zoomed == true)
            {
                Zoomed = false;
                return;
            }
        }

        ViewObstructed();
    }

    void LateUpdate()
    {

        currentX += Input.GetAxis("Mouse X") * sensivity * Time.deltaTime;
        currentY += Input.GetAxis("Mouse Y") * sensivity * Time.deltaTime;

        currentY = Mathf.Clamp(currentY, YMin, YMax);

        Vector3 Direction = new Vector3(0, 0, -distance);

        Vector3 DirectionZoom = new Vector3(0, 2, -distance);

        Vector3 MoveUp = new Vector3(0, 1, -1);

        Vector3 MoveUpZoom = new Vector3(0, 0, 0);

        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);

        transform.position = lookAt.position + rotation * Direction;

        if (Zoomed == true)
        {
            distance = -1f;

            PlayerMesh.gameObject.GetComponent<SkinnedMeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
            lookAt.gameObject.GetComponent<SkinnedMeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;

            transform.LookAt(MoveUpZoom + lookAt.position);

            transform.position = lookAt.position + rotation * DirectionZoom;

            return;
        }
        else
        {
            distance = originaldistance;
            PlayerMesh.gameObject.GetComponent<SkinnedMeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
            lookAt.gameObject.GetComponent<SkinnedMeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;

            transform.LookAt(MoveUp + lookAt.position);

            return;
        }

    }

    void ViewObstructed()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position, Target.position - transform.position, out hit, 4.5f))
        {
            if (hit.collider.gameObject.tag != "Player" && hit.collider.gameObject.tag != "Enemy" && hit.collider.gameObject.tag != "Item" && hit.collider.gameObject.tag != "Untagged" && hit.collider.gameObject.tag != "Boss" && hit.collider.gameObject.tag != "Bomb" && hit.collider.gameObject.tag != "Projectile" && hit.collider.gameObject.tag != "Ramp" && hit.collider.gameObject.tag != "ShooterEnemy")
            {
                Obstruction = hit.transform;
                if (Obstruction.gameObject.name == "Player")
                {
                    Obstruction.gameObject.GetComponent<SkinnedMeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;

                    if (Vector3.Distance(Obstruction.position, transform.position) >= 3f && Vector3.Distance(transform.position, Target.position) >= 1.5f)
                    {
                        transform.Translate(Vector3.forward * zoomspeed * Time.deltaTime);
                    }
                }
                else
                {
                    Obstruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;

                    if (Vector3.Distance(Obstruction.position, transform.position) >= 3f && Vector3.Distance(transform.position, Target.position) >= 1.5f)
                    {
                        transform.Translate(Vector3.forward * zoomspeed * Time.deltaTime);
                    }
                }
            }
            else
            {
                if (Obstruction.gameObject.name == "Player")
                {
                    Obstruction.gameObject.GetComponent<SkinnedMeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
                    if (Vector3.Distance(transform.position, Target.position) < 4.5f)
                    {
                        transform.Translate(Vector3.back * zoomspeed * Time.deltaTime);
                    }
                }
                else
                {
                    Obstruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
                    if (Vector3.Distance(transform.position, Target.position) < 4.5f)
                    {
                        transform.Translate(Vector3.back * zoomspeed * Time.deltaTime);
                    }
                }
            }
        }
    }
}