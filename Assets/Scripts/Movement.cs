using System;
using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    //Created by Jayden, dont edit it

    Cash cash;

    [SerializeField] float carSpeed = 0f;
    [SerializeField] float accelCar = 500f;
    [SerializeField] float maxSpeed = 15f;
    [SerializeField] float mag;

    [SerializeField] int waitTime = 2;

    [SerializeField] public float currentBreakForce = 0f;
    [SerializeField] public float breakForce = 300f;

    float driftAngle = 0f;
    float driftFactor = 0f;
    float speed = 0f;
    public float minSpeed = 5f;
    public float minAngle = 10f;
    bool isDrifting = false;

    
    [SerializeField] WheelCollider leftFrontWheelCollider;
    [SerializeField] WheelCollider rightFrontWheelCollider;
    [SerializeField] WheelCollider leftBackWheelCollider;
    [SerializeField] WheelCollider rightBackWheelCollider;

    [SerializeField] Transform leftFrontWheel;
    [SerializeField] Transform rightFrontWheel;
    [SerializeField] Transform leftBackWheel;
    [SerializeField] Transform rightBackWheel;

    public WheelFrictionCurve wFC;
    public WheelFrictionCurve frontWFC;
    public WheelFrictionCurve backwheelFrition;

    AudioSource carSource;
    public AudioClip carEngine;

    [SerializeField] private float rotY;
 

    [SerializeField] float rotationSpeed = 50f;

     public Rigidbody rb;


    public AudioClip bangAudio;
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
        mag = rb.velocity.magnitude;
        wheelMovement(rightBackWheelCollider, rightBackWheel);
        wheelMovement(rightFrontWheelCollider, rightFrontWheel);
        wheelMovement(leftBackWheelCollider, leftBackWheel);
        wheelMovement(leftFrontWheelCollider, leftFrontWheel);
       
       

    }

    private void CarDrifting()
    {
        if (Input.GetKey(KeyCode.LeftShift))

        {

            wFC = leftBackWheelCollider.sidewaysFriction;

            wFC = rightBackWheelCollider.sidewaysFriction;

            frontWFC = leftFrontWheelCollider.sidewaysFriction;

            frontWFC = rightFrontWheelCollider.sidewaysFriction;

            backwheelFrition = rightBackWheelCollider.forwardFriction;

            backwheelFrition = leftBackWheelCollider.forwardFriction;





            backwheelFrition.stiffness = 0.6f;

            wFC.extremumSlip = 0.5f;

            wFC.stiffness = 0.8f;



            frontWFC.extremumSlip = 0.23f;

            frontWFC.stiffness = 0.8f;





            rightBackWheelCollider.sidewaysFriction = wFC;

            leftBackWheelCollider.sidewaysFriction = wFC;

            rightBackWheelCollider.forwardFriction = backwheelFrition;

            leftBackWheelCollider.forwardFriction = backwheelFrition;



            rightFrontWheelCollider.sidewaysFriction = frontWFC;

            leftFrontWheelCollider.sidewaysFriction = frontWFC;



        }



        else

        {

            wFC = leftBackWheelCollider.sidewaysFriction;

            wFC = rightBackWheelCollider.sidewaysFriction;

            frontWFC = leftFrontWheelCollider.sidewaysFriction;

            frontWFC = rightFrontWheelCollider.sidewaysFriction;

            backwheelFrition = rightBackWheelCollider.forwardFriction;

            backwheelFrition = leftBackWheelCollider.forwardFriction;



            wFC.extremumSlip = 0.1f;

            wFC.stiffness = 1.5f;

            backwheelFrition.stiffness = 1f;





            frontWFC.extremumSlip = 0.1f;

            frontWFC.stiffness = 1.5f;



            rightBackWheelCollider.sidewaysFriction = wFC;

            leftBackWheelCollider.sidewaysFriction = wFC;

            rightBackWheelCollider.forwardFriction = backwheelFrition;

            leftBackWheelCollider.forwardFriction = backwheelFrition;



            rightFrontWheelCollider.sidewaysFriction = frontWFC;

            leftFrontWheelCollider.sidewaysFriction = frontWFC;



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
        if(mag < 10)
        {
            mag = 1.25f;
        }
        rotY = Input.GetAxis("Rotation") * rotationSpeed * 2f /mag;
        
        rightFrontWheelCollider.steerAngle = rotY;              
        leftFrontWheelCollider.steerAngle = rotY;
       
          



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
