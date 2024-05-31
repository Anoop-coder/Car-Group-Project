 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopRotate1 : MonoBehaviour
{
    public float rotationS = 50;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotationS * Time.deltaTime, 0);
    }
}
