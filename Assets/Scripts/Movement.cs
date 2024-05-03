using System;
using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    //Created by Jayden, dont edit it
    

    [SerializeField] float carSpeed = 0;
    [SerializeField] float accelCar = 500;
    [SerializeField] float mag;
   
  

    [SerializeField] public float currentBreakForce = 0f;
    [SerializeField] public float breakForce = 300f;


    [SerializeField] WheelCollider leftFrontWheelCollider;
    [SerializeField] WheelCollider rightFrontWheelCollider;
    [SerializeField] WheelCollider leftBackWheelCollider;
    [SerializeField] WheelCollider rightBackWheelCollider;

    [SerializeField] Transform leftFrontWheel;
    [SerializeField] Transform rightFrontWheel;
    [SerializeField] Transform leftBackWheel;
    [SerializeField] Transform rightBackWheel;


    [SerializeField] private float rotY;
 

    [SerializeField] float rotationSpeed = 50f;

     public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mag =  rb.velocity.magnitude;
        
    }
   

    // Update is called once per frame
    void FixedUpdate()
    {
        CarMovement();
        CarRotation();
        CarBreaking();
        mag = rb.velocity.magnitude;
        wheelMovement(rightBackWheelCollider, rightBackWheel);
        wheelMovement(rightFrontWheelCollider, rightFrontWheel);
        wheelMovement(leftBackWheelCollider, leftBackWheel);
        wheelMovement(leftFrontWheelCollider, leftFrontWheel);

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


    }

    private void CarRotation()
    {
        if(mag < 10)
        {
            mag = 1.25f;
        }
        rotY = Input.GetAxis("Rotation") * rotationSpeed * 1 /mag;
        
        rightFrontWheelCollider.steerAngle = rotY;              
        leftFrontWheelCollider.steerAngle = rotY;
       
          



    }

    

    private void CarMovement()
    {
       
        
            carSpeed = accelCar * Input.GetAxis("Front");

           
       
            leftFrontWheelCollider.motorTorque = carSpeed;
            rightFrontWheelCollider.motorTorque = carSpeed;
        


       
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






















}
