using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Reflection;
using UnityEditor.Experimental.GraphView;

public class ShopChange : MonoBehaviour
{
    private int currentCar;
    [SerializeField] private Button nextButton;
    [SerializeField] private Button previousButton;

    [SerializeField] private Button play;
    [SerializeField] private Button playC; 
    [SerializeField] private Button playK;
    [SerializeField] private Button buy;
    [SerializeField] private TextMeshProUGUI textPrice;
    [SerializeField] private TextMeshProUGUI topSpeed;
    [SerializeField] private int[] carPrices;

    private void Start()
    {
        currentCar = SaveManager.instance.currentCar;
        SelectCar(currentCar);
    }

    private void SelectCar(int _index) // parameter for which car
    {
       
        for (int i = 0; i < transform.childCount; i++)   //changes index of car
        {
            transform.GetChild(i).gameObject.SetActive(i == _index);
            UpdateUI();
        }
      
        
        
    }

    private void UpdateUI()
    {
        if (SaveManager.instance.carsUnlocked[currentCar])
        {
           
            play.gameObject.SetActive(true);
            buy.gameObject.SetActive(false);
            if (currentCar == 1)
            {
                playC.gameObject.SetActive(true);
                buy.gameObject.SetActive(false);
            }
            if (currentCar == 1)
            {
                playK.gameObject.SetActive(true);
                buy.gameObject.SetActive(false);
            }

        }

     

        else
        {
            play.gameObject.SetActive(false); 
            playC.gameObject.SetActive(false);
            playK.gameObject.SetActive(false);
            buy.gameObject.SetActive(true);
            textPrice.text = carPrices[currentCar] + "$";
        }

        

        
        
    }

    private void Update()
    {
        if (buy.gameObject.activeInHierarchy)
        {
            //check if enough money
            buy.interactable = (SaveManager.instance.money >= carPrices[currentCar]);
        }
    }

    public void ChangeCar(int _change)  // when button is press if i=0 which is the starter car, it will add 1 to change the car index from SelectCar function and thus the car
    {
        currentCar += _change;

        if(currentCar > transform.childCount - 1)
        {
            currentCar = 0;
        }
        else if(currentCar < 0){
            currentCar = transform.childCount - 1;
        }

        SaveManager.instance.currentCar = currentCar;
        SaveManager.instance.Save();
        SelectCar(currentCar);
    }

    public void BuyCar()
    {
        SaveManager.instance.money -= carPrices[currentCar];
        SaveManager.instance.carsUnlocked[currentCar] = true;
        SaveManager.instance.Save();
        UpdateUI();
    }
}
