using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Created by Jayden, dont edit it
    int carSpeed = 1;
    int accelCar = 1;
    int maxSpeed = 50;
   
    Vector3 forward = new Vector3(0,0,1);
    Vector3 backward = new Vector3(0, 0, -1);

    Vector3 right = new Vector3(1,0,0);
    Vector3 left = new Vector3(-1, 0, 0);
    
    Vector3 playerMove;

    

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
    }

    private void CarMovement()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {


            rb.MovePosition(playerMove.position, forward, 0, 0);
            
        }

       
        if (Input.GetKeyDown(KeyCode.D))
        {


            rb.AddForce(10, 0, 0);

        }
        
        if (Input.GetKeyDown(KeyCode.W) & accelCar < maxSpeed)
        {

            rb.AddForce(0, carSpeed, 0);


        }
        
        if (Input.GetKeyDown(KeyCode.S) & accelCar < maxSpeed)
        {
            rb.AddForce(0, -10, 0);



        }

    }
}
