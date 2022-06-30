using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Player : MonoBehaviour
{
    [Header("Wheels")]
    public WheelCollider Wheel_LF;
    public WheelCollider Wheel_RF;
    public WheelCollider Wheel_LR;
    public WheelCollider Wheel_RR;
    public GameObject Wheel_LFOBJ;
    public GameObject Wheel_RFOBJ;
    public GameObject Wheel_LROBJ;
    public GameObject Wheel_RROBJ;

    [Header("Input Axis Floats")]
    public float HorizontalAxis;
    public float VerticalAxis;

    [Header("Movement")]
    public bool Freeze;
    public float MaxSpeed;
    public float HorsePower;
    public float MaxSteer = 25.0f;
    public float SteerPower;
    public float Power = 0.0f;
    public float Brake = 0.0f;
    public float Steer = 0.0f;
    public bool OnGround;
    public bool Movement;
    public Vector3 currentvelocity;
    public float MPH;
    public float ReduceSpeedValue;
    private Rigidbody rb;
    public LayerMask Floor;

    [Header("Camera")]
    public CameraController Cam;

    [Header("Timeline Manager")]
    public TimelineManager timelineManager;

    [Header("Score")]
    public int AnsweredCorrect = 0;

    [Header("Settings")]
    public GameObject SettingsToggle;

    [Header("Board")]
    public GivenAnswer ga;
    public Board board;
    public CorrectIncorrect ci;

    [Header("Audio")]
    public AudioSource SFXAudioSource;
    public float volume;
    public float DecreaseIncreaseVolumeValue;
    public AudioClip DrivingSFX;

    [Header("Particles")]
    public ParticleSystem RearLeftWheelParticles;
    public ParticleSystem RearRightWheelParticles;
    public float ParticlePlayThreshold;

    [Header("Spawn")]
    public GameObject spawn;

    [Header("Timeline Effects")]
    public bool InTimeline = false;

    [Header("Road Effects")]
    public bool CanCrossLine = false;

    void Start()
    {
        spawn.transform.position = transform.position;
        rb = GetComponent<Rigidbody>();
        SFXAudioSource.volume = volume;
        rb.centerOfMass += new Vector3(0, -1f, 0); //To prevent car flipping by reducing its center of mass
    }

    private void FixedUpdate()
    {
        if (Freeze == false)
        {
            if(MaxSpeedLimitCheck() == false)
            {
                VerticalAxis = Input.GetAxis("Vertical");
            }

            HorizontalAxis = Input.GetAxis("Horizontal");

            Steer = HorizontalAxis * MaxSteer;

            //CURRENTSPEED
            currentvelocity = rb.velocity;
            MPH = currentvelocity.magnitude;

            //GROUND CHECK
            OnGround = Physics.Raycast((new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1f, gameObject.transform.position.z)), Vector3.down, 2f, Floor);

            //MOVEMENT CHECK
            if (Input.GetKey(KeyCode.W))
            {
                Movement = true;
            }
            else if (Input.GetKeyUp(KeyCode.W))
            {
                Movement = false;
            }

            //TURNING

            Steering();

             //BRAKE
            Brake = Input.GetKey(KeyCode.S) ? GetComponent<Rigidbody>().mass * 7.0f * (MPH/190) : 0.0f; // snippet modified from https://forum.unity.com/threads/help-script-for-car-controller.341031/

            if (OnGround)
            {
                if (Movement)
                {
                    if (SFXAudioSource.volume < volume)
                    {
                        SFXAudioSource.volume += (DecreaseIncreaseVolumeValue) * Time.deltaTime;
                    }
                    SFXAudioSource.clip = DrivingSFX;
                    if (SFXAudioSource.isPlaying == false)
                    {
                        SFXAudioSource.Play();
                    }

                    if (MaxSpeedLimitCheck() == false)
                    {
                        Power = VerticalAxis * HorsePower * (Time.deltaTime * 500.0f);
                    }
                }
                // when player not interacting with 'w' key
                else if (Movement == false)
                {
                    //ReduceSpeed();
                }
            }

            //Audio

            if (Movement == false && SFXAudioSource.isPlaying)
            {
                SFXAudioSource.volume -= (DecreaseIncreaseVolumeValue) * Time.deltaTime;
            }

            if (MPH < 0.1)
            {
                SFXAudioSource.volume -= DecreaseIncreaseVolumeValue;
            }
        }
    }

    void Update()
    {
        // PARTICLES //

        if (MPH <= ParticlePlayThreshold && Input.GetKeyDown("w"))
        {
            RearRightWheelParticles.Play();
            RearLeftWheelParticles.Play();
        }

        if (MPH <= ParticlePlayThreshold && Input.GetKeyUp("w"))
        {
            RearRightWheelParticles.Stop();
            RearLeftWheelParticles.Stop();
        }

        if (MPH > ParticlePlayThreshold || !OnGround)
        {
            RearRightWheelParticles.Stop();
            RearLeftWheelParticles.Stop();
        }

        // WHEEL SPIN //

        WheelSpin();

        // DISPLAYS //

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SettingsDisplay();
        }

        //STEERING from https://forum.unity.com/threads/help-script-for-car-controller.341031/
        Wheel_LF.steerAngle = Steer;
        Wheel_RF.steerAngle = Steer;

        //BRAKING / REDUCE SPEED from https://forum.unity.com/threads/help-script-for-car-controller.341031/
        if (Brake > 0.0 || Movement == false)
        {
            Wheel_LF.brakeTorque = Brake;
            Wheel_RF.brakeTorque = Brake;
            Wheel_LR.brakeTorque = Brake;
            Wheel_RR.brakeTorque = Brake;
            Wheel_LR.motorTorque = 0.0f;
            Wheel_RR.motorTorque = 0.0f;
        }
        else if(Movement == true)
        {
            Wheel_LF.brakeTorque = 0;
            Wheel_RF.brakeTorque = 0;
            Wheel_LR.brakeTorque = 0;
            Wheel_RR.brakeTorque = 0;
            Wheel_LR.motorTorque = Power;
            Wheel_RR.motorTorque = Power;
        }
    }

    // UTILITY FUNCTIONS //

    public void MovePlayerToSpawn()
    {
        rb.velocity = new Vector3(0, 0, 0);
        gameObject.transform.rotation = spawn.transform.rotation;
        transform.position = spawn.transform.position;
    }

    // DRIVING FUNCTIONS //

    public bool MaxSpeedLimitCheck()
    {
        // slighly reduce the velocity every time it exceeds the speed limit to keep within speed limit

        // design decision, do I make the player aware they were speeding or do i do this subtly?

        if (MPH >= MaxSpeed)
        {
            rb.velocity *= 0.99f; // smooth decrease, not noticeable

            //rb.velocity *= 0.80f; // jolty decrease, very noticeable

            Debug.Log("Max speed hit, current speed equals: " + MPH + "| Max speed is: " + MaxSpeed);
            return true;
        }

        else if(MPH < MaxSpeed)
        {
            return false;
        }

        Debug.LogWarning("No conditions met in MaxSpeedLimitCheck, default is return false");
        return false;
    }

    public void Steering()
    {
        if (Input.GetKey(KeyCode.D))
        {
            if (MPH > 1)
            {
                transform.Rotate(new Vector3(0, SteerPower * (MPH / 20), 0) * Time.deltaTime);
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (MPH > 1)
            {
                transform.Rotate(new Vector3(0, -SteerPower * (MPH / 20), 0) * Time.deltaTime);
            }
        }
    }

    public void FreezePlayer()
    {
        if(Freeze == false)
        {
            Freeze = true;
            MPH = 0;
            currentvelocity = new Vector3(0, 0, 0);
            rb.velocity = new Vector3(0, 0, 0);
            VerticalAxis = 0;
            HorizontalAxis = 0;
            rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
            return;
        }
        else if(Freeze == true)
        {
            Freeze = false;
            rb.constraints = 0;
            return;
        }
    }

    // WHEEL SPIN //

    public void WheelSpin()
    {
        if (MPH > 1)
        {
            Wheel_LFOBJ.transform.Rotate(new Vector3(0, 0, MPH * 9) * Time.deltaTime);
            Wheel_RFOBJ.transform.Rotate(new Vector3(0, 0, -MPH * 9) * Time.deltaTime);
            Wheel_LROBJ.transform.Rotate(new Vector3(0, 0, MPH * 9) * Time.deltaTime);
            Wheel_RROBJ.transform.Rotate(new Vector3(0, 0, -MPH * 9) * Time.deltaTime);
        }
    }

    // DISPLAYS //

    public void SettingsDisplay()
    {
        if (SettingsToggle.activeInHierarchy)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1;
            SettingsToggle.SetActive(false);
        }
        else
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            Time.timeScale = 0;
            SettingsToggle.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // CAR COLLISION FAIL CONDITIONS //
        if(other.CompareTag("FallCollider"))
        {
            MovePlayerToSpawn();
            ci.EditText("Fell out of the map");
        }

        if (other.CompareTag("DeadEnd"))
        {
            MovePlayerToSpawn();
            ci.EditText("You hit a dead end!");
        }

        if (other.CompareTag("Pavement"))
        {
            MovePlayerToSpawn();
            ci.EditText("You hit the pavement");
        }

        if (other.CompareTag("MiddleRoadObject") && InTimeline == false && CanCrossLine == false)
        {
            MovePlayerToSpawn();
            ci.EditText("You crossed the white line unnecessarily");
        }

        if (other.CompareTag("Wall"))
        {
            if(InTimeline)
            {
                foreach ( GameObject g in timelineManager.AllTimelines)
                {
                    if (g.activeInHierarchy)
                    {
                        g.SetActive(false);
                    }
                }
            }
            MovePlayerToSpawn();
            ci.EditText("You hit a wall");
        }

        if (other.CompareTag("TrafficLightLine"))
        {
            MovePlayerToSpawn();
            ci.EditText("You ran a red light");
        }

        if(other.CompareTag("End"))
        {
            SceneManager.LoadScene("EndGame");
        }
    }
}
