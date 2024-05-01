using System;
using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    //Created by Jayden, dont edit it
    public GameObject car;

    [SerializeField] float carSpeed = 0;
    [SerializeField] float accelCar = 1;
    [SerializeField] int maxSpeed = 10;
    [SerializeField] float deAccel = 5f;

    [SerializeField] WheelCollider leftFrontWheelCollider;
    [SerializeField] WheelCollider rightFrontWheelCollider;
    [SerializeField] WheelCollider leftBackWheelCollider;
    [SerializeField] WheelCollider rightBackWheelCollider;

   



    Vector3 playerMove;
    Vector3 EulerAngleVelocityLeft = new Vector3(0, -70, 0);
    Vector3 EulerAngleVelocityRight = new Vector3(0, 70, 0);
     float maxRotation = 70;


    private float rotY;


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

       
    }

    private void CarRotation()
    {

        rotY = Input.GetAxis("Rotation") * rotationSpeed;                  
           rightFrontWheelCollider.steerAngle = rotY;              
           leftFrontWheelCollider.steerAngle = rotY;
           rotY = Mathf.Clamp(rotY, -70, 70);



    }

    

    private void CarMovement()
    {
                      


       
        
        if (Input.GetKey(KeyCode.W))
        {

            transform.position += transform.forward * carSpeed;
            if (carSpeed <= maxSpeed)
            {
                carSpeed += accelCar * Time.deltaTime;
            }




        }
        
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += transform.forward * carSpeed;
           if(carSpeed <= maxSpeed)
            {
                carSpeed += -accelCar * Time.deltaTime;
            }
        }

        else
        {
          if(carSpeed > 0)
            {
                transform.position += transform.forward * carSpeed;
                carSpeed = carSpeed - deAccel * Time.deltaTime;
            }

          else if(carSpeed < 0)
            {
                transform.position += transform.forward * carSpeed;
                carSpeed = carSpeed + deAccel * Time.deltaTime;
            }

            else
            {
                carSpeed = 0;
            }
            
            
           
           

        }
        
    }
}
