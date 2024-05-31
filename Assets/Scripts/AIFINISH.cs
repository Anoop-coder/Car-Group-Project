using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFINISH : MonoBehaviour
{
   
    public Collider aICollider;
    Cash cash;

    private void Start()
    {
        cash = FindObjectOfType<Cash>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Npc")
        {
            cash.secondPlace = true;
            
        }
    }
}
