using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFINISH : MonoBehaviour
{
    [SerializeField] public bool secondPlace = false;
    [SerializeField] public bool playerFinish = false;


    Cash cash;

    public void Start()
    {
        cash = FindObjectOfType<Cash>();
        
    }
    
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Npc")
        {
            secondPlace = true;
        }

        if(other.gameObject.tag == "Player")
        {                     
            
            playerFinish = true;
            cash.currentMoney += cash.cashGet;
        }
        
        
        
    }
}
