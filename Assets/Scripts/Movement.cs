using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    //Created by Jayden, dont edit it


    internal enum driveType
    {
        frontWheelDrive,
        allWheelDrive
    }

    [SerializeField] private driveType drive;
    
    Cash cash;

    [SerializeField] TextMeshProUGUI angleText;

    [SerializeField] float carSpeed = 0f;
    [SerializeField] float accelCar = 500f;
    [SerializeField] float maxSpeed = 15f;
    [SerializeField] float mag;

    [SerializeField] int waitTime = 2;

    [SerializeField] public float currentBreakForce = 0f;
    [SerializeField] public float breakForce = 300f;

 

    float driftAngle = 0f;
    float driftFactor = 1f;
    float speed = 0f;
    bool isDrifting = false;

    public float minSpeed = 5f;
    public float minAngle = 10f;

    public float downForce = 50f;


    [SerializeField] WheelCollider leftFrontWheelCollider;
    [SerializeField] WheelCollider rightFrontWheelCollider;
    [SerializeField] WheelCollider leftBackWheelCollider;
    [SerializeField] WheelCollider rightBackWheelCollider;

    [SerializeField] Transform leftFrontWheel;
    [SerializeField] Transform rightFrontWheel;
    [SerializeField] Transform leftBackWheel;
    [SerializeField] Transform rightBackWheel;

    public WheelFrictionCurve backwFCSide;
    public WheelFrictionCurve frontWFCSide;
    public WheelFrictionCurve backwheelFront;
    public WheelFrictionCurve frontWFCFront;

    AudioSource carSource;
    public AudioClip carEngine;

    [SerializeField] private float rotY;
    [SerializeField] float rotationSpeed = 30f;
    [SerializeField] float turnFaster = 4f;
    [SerializeField] float turnFasterDrift = 2;
    [SerializeField] float carSpeedRound;

    public Rigidbody rb;


    public AudioClip bangAudio;


    [Header("Extremum")]

    [SerializeField] public float backSidewaysESlip = 0.1f;
    [SerializeField] public float backForwardESlip = 0.3f;

    [SerializeField] public float backSidewaysEValue = 1.5f;
    [SerializeField] public float backForwardEValue = 2f;

    [SerializeField] public float frontSidewaysEValue = 1.5f;
    [SerializeField] public float frontForwardEValue = 1.5f;

    [SerializeField] public float frontSidewaysESlip = 0.12f;
    [SerializeField] public float frontForwardESlip = 0.1f;

 

    [Header("Extremum Drift")]
   
    [SerializeField] public float backSidewaysESlipDrift = 0.3f;
    [SerializeField] public float backForwardESlipDrift = 0.3f;

    [SerializeField] public float backSidewaysEValueDrift = 2f;
    [SerializeField] public float backForwardEValueDrift = 2f;

    [SerializeField] public float frontSidewaysEValueDrift = 1.5f;
    [SerializeField] public float frontForwardEValueDrift = 1.5f;

    [SerializeField] public float frontSidewaysESlipDrift = 0.12f;
    [SerializeField] public float frontForwardESlipDrift = 0.1f;

  


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        carSource = GetComponent<AudioSource>();
        cash = FindAnyObjectByType<Cash>();
        mag =  rb.velocity.magnitude;
        
    }
   

    // Update is called once per frame
    void FixedUpdate()
    {
        CarMovement();
        CarRotation();
        CarBreaking();
        CarReset();
        CarDrifting();
        CarWheelControl();
     
        mag = rb.velocity.magnitude;
        wheelMovement(rightBackWheelCollider, rightBackWheel);
        wheelMovement(rightFrontWheelCollider, rightFrontWheel);
        wheelMovement(leftBackWheelCollider, leftBackWheel);
        wheelMovement(leftFrontWheelCollider, leftFrontWheel);


       
    }

    private void CarWheelControl()
    {

        backwFCSide = leftBackWheelCollider.sidewaysFriction;
        backwFCSide = rightBackWheelCollider.sidewaysFriction;

        frontWFCSide = leftFrontWheelCollider.sidewaysFriction;
        frontWFCSide = rightFrontWheelCollider.sidewaysFriction;

        backwheelFront = rightBackWheelCollider.forwardFriction;
        backwheelFront = leftBackWheelCollider.forwardFriction;

        frontWFCFront = leftFrontWheelCollider.forwardFriction;
        frontWFCFront = rightBackWheelCollider.forwardFriction;



    }

    private void CarDrifting()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            backwFCSide = leftBackWheelCollider.sidewaysFriction;
            backwFCSide = rightBackWheelCollider.sidewaysFriction;

            frontWFCSide = leftFrontWheelCollider.sidewaysFriction;
            frontWFCSide = rightFrontWheelCollider.sidewaysFriction;

            backwheelFront = rightBackWheelCollider.forwardFriction;
            backwheelFront = leftBackWheelCollider.forwardFriction;

            frontWFCFront = leftFrontWheelCollider.forwardFriction;
            frontWFCFront = rightBackWheelCollider.forwardFriction;


            backwFCSide.extremumSlip = backSidewaysESlipDrift;
            backwFCSide.extremumValue = backSidewaysEValueDrift;
           
            backwheelFront.extremumSlip = backForwardESlipDrift;
            backwheelFront.extremumValue = backForwardESlipDrift;

            frontWFCSide.extremumSlip = frontSidewaysESlipDrift;
            frontWFCSide.extremumValue = frontSidewaysEValueDrift;

            frontWFCFront.extremumSlip = frontForwardESlipDrift;
            frontWFCFront.extremumValue = frontSidewaysEValueDrift;

            


            rightBackWheelCollider.sidewaysFriction = backwFCSide;
            leftBackWheelCollider.sidewaysFriction = backwFCSide;

             leftFrontWheelCollider.sidewaysFriction = frontWFCSide;
             rightFrontWheelCollider.sidewaysFriction = frontWFCSide;

            rightBackWheelCollider.forwardFriction = backwheelFront;
            leftBackWheelCollider.forwardFriction = backwheelFront;


            rightFrontWheelCollider.forwardFriction = frontWFCFront;
            leftFrontWheelCollider.forwardFriction = frontWFCFront;

        }

        else
        {
            backwFCSide = leftBackWheelCollider.sidewaysFriction;
            backwFCSide = rightBackWheelCollider.sidewaysFriction;

            frontWFCSide = leftFrontWheelCollider.forwardFriction;
            frontWFCSide = rightFrontWheelCollider.forwardFriction;

            backwheelFront = rightBackWheelCollider.forwardFriction;
            backwheelFront = leftBackWheelCollider.forwardFriction;

            frontWFCFront = leftFrontWheelCollider.forwardFriction;
            frontWFCFront = rightBackWheelCollider.forwardFriction;

           
            backwFCSide.extremumSlip = backSidewaysESlip;
            backwFCSide.extremumValue = backForwardEValue;

            backwheelFront.extremumSlip = backForwardESlip;
            backwheelFront.extremumValue = backForwardEValue;

            frontWFCSide.extremumSlip = frontSidewaysESlip;
            frontWFCSide.extremumValue = frontSidewaysEValue;

            frontWFCFront.extremumSlip = frontForwardESlip;
            frontWFCFront.extremumValue = frontSidewaysEValue;




            rightBackWheelCollider.sidewaysFriction = backwFCSide;
            leftBackWheelCollider.sidewaysFriction = backwFCSide;

            leftFrontWheelCollider.sidewaysFriction = frontWFCSide;
            rightFrontWheelCollider.sidewaysFriction = frontWFCSide;

            rightBackWheelCollider.forwardFriction = backwheelFront;
            leftBackWheelCollider.forwardFriction = backwheelFront;


            rightFrontWheelCollider.forwardFriction = frontWFCFront;
            leftFrontWheelCollider.forwardFriction = frontWFCFront;
        }
    }


    private void CarBreaking()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            currentBreakForce = breakForce;

        }

        else
        {
            currentBreakForce = 0;

        }

        leftBackWheelCollider.brakeTorque = currentBreakForce;
        leftFrontWheelCollider.brakeTorque = currentBreakForce;
        rightBackWheelCollider.brakeTorque = currentBreakForce;
        rightFrontWheelCollider.brakeTorque = currentBreakForce;

    }

    private void CarRotation()
    {
         
        rotY = Input.GetAxis("Rotation") * rotationSpeed;
     
        
        
        if(drive == driveType.frontWheelDrive)
        {
            rightFrontWheelCollider.steerAngle = rotY;
            leftFrontWheelCollider.steerAngle = rotY;
        }

        if (drive == driveType.allWheelDrive)
        {
            rightBackWheelCollider.steerAngle = -rotY;
            leftBackWheelCollider.steerAngle = -rotY;
            rightFrontWheelCollider.steerAngle = rotY;
            leftFrontWheelCollider.steerAngle = rotY;
        }

      



    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Barrier"))
        {
            AudioSource.PlayClipAtPoint(bangAudio, Camera.main.transform.position);
            AudioSource.PlayClipAtPoint(bangAudio, Camera.main.transform.position);
        }

        if (collision.gameObject.CompareTag("SubtractMoney"))
        {
            cash.cashGet = cash.cashGet - cash.carHitSubtract;
        }

        if (collision.gameObject.CompareTag("Reset"))
        {
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentScene);
        }
    }

 
    private void CarMovement()
    {         
        if(mag >= maxSpeed)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        }
        carSpeed = accelCar * Input.GetAxis("Front");  
       
        
       
            leftFrontWheelCollider.motorTorque = carSpeed;
            rightFrontWheelCollider.motorTorque = carSpeed; 
        
        if(mag > 1)
        {
            carSource.enabled = true;
            carSource.PlayOneShot(carEngine);
        }
      

        else
        {
            carSource.enabled = false;
        }
    }

    void wheelMovement(WheelCollider wc, Transform trans)

    {

        //wheel collider  
        Vector3 position = trans.position;
        Quaternion rotation = trans.rotation;
        wc.GetWorldPose(out position, out rotation); //get world space accounting ground, angle, rotation 

        //return wheel transform state 
        trans.position = position;
        trans.rotation = rotation;

    }


    void CarReset()
    {
        if (Input.GetKey(KeyCode.R))
        {
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentScene);
        }
    }



   













}
