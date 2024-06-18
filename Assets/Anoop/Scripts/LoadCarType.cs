using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCarType : MonoBehaviour
{
    [SerializeField] private GameObject[] carModels;
    

    private void Start()
    {
        ChooseCarModel(SaveManager.instance.currentCar);
        
    }

    private void ChooseCarModel(int _index)
    {
        Instantiate(carModels[-_index], transform.position, Quaternion.identity, transform);
        
    }
}
