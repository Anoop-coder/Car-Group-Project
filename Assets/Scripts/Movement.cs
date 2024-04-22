using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Created by Jayden, dont edit it
    [SerializeField] float carSpeed = 0;
    [SerializeField] float accelCar = 1;
    [SerializeField] int maxSpeed = 10;
    [SerializeField] float deAccel = 5f;
   
    Vector3 forward = new Vector3(0,0,1);
    Vector3 backward = new Vector3(0, 0, -1);

    Vector3 right = new Vector3(1,0,0);
    Vector3 left = new Vector3(-1, 0, 0);
    
    Vector3 playerMove;
    Vector3 EulerAngleVelocityLeft = new Vector3(0, -70);
    Vector3 EulerAngleVelocityRight = new Vector3(0, 70);

    



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
        Brakes();
    }

    private void Brakes()
    {
       
    }

    private void CarMovement()
    {
        if(Input.GetKey(KeyCode.A))
        {

            Quaternion deltaRotation = Quaternion.Euler(EulerAngleVelocityLeft * Time.fixedDeltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
            
            
        }

       
        if (Input.GetKey(KeyCode.D))
        {

            Quaternion deltaRotation = Quaternion.Euler(EulerAngleVelocityRight * Time.fixedDeltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);

        }
        
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
            transform.position += -transform.forward * carSpeed;
           if(carSpeed <= maxSpeed)
            {
                carSpeed += accelCar * Time.deltaTime;
            }
        }

        else
        {
          if(carSpeed > 0)
            {
                transform.position += -transform.forward * carSpeed;
                carSpeed = carSpeed - deAccel * Time.deltaTime;
            }

          else if(carSpeed < 0)
            {
                carSpeed = carSpeed + deAccel * Time.deltaTime;
            }

            else
            {
                carSpeed = 0;
            }
            
            
           
           

        }
        
    }
}
