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
    [SerializeField] float maxSpeed = 150;
   
  

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

        
    }
   

    // Update is called once per frame
    void FixedUpdate()
    {
        CarMovement();
        CarRotation();
        CarBreaking();

       
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

        leftFrontWheelCollider.brakeTorque = currentBreakForce;
        rightFrontWheelCollider.brakeTorque = currentBreakForce;
        leftBackWheelCollider.brakeTorque = currentBreakForce;
        rightBackWheelCollider.brakeTorque = currentBreakForce;
    }

    private void CarRotation()
    {

        rotY = Input.GetAxis("Rotation") * rotationSpeed;
        Mathf.Clamp(rotY, -60, 60);
        rightFrontWheelCollider.steerAngle = rotY;              
        leftFrontWheelCollider.steerAngle = rotY;
          



    }

    

    private void CarMovement()
    {


       carSpeed = accelCar * Input.GetAxis("Front");

        leftFrontWheelCollider.motorTorque = carSpeed;
        rightFrontWheelCollider.motorTorque = carSpeed;
       
       
        if(carSpeed > 0)
        {
            StartCoroutine(addSpeed());
        }

       
        
       
      IEnumerator addSpeed()
        {
           if(carSpeed > 0 && accelCar < maxSpeed)
            {               
                accelCar = accelCar + 1;
                yield return new WaitForSeconds(3);
                
            }

            
            
        }

        
        
    }
}
