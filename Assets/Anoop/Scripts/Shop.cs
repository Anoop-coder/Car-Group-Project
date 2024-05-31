using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject[] carS;
    public int carIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject car in carS)
            car.SetActive(false);
        carS[carIndex].SetActive(false) ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
