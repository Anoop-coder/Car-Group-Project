using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Created by Jayden, dont edit it
    int carSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CarMovement();
    }

    private void CarMovement()
    {
        float sideMove = Input.GetAxis("Side") * carSpeed * Time.deltaTime;
        float frontMove = Input.GetAxis("Front") * carSpeed * Time.deltaTime;
    }
}
