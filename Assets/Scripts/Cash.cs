using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cash : MonoBehaviour
{
    AIFINISH aIFINISH;

    [SerializeField] TextMeshProUGUI cashText;
    [SerializeField] public int currentMoney = 0;
    [SerializeField] public int cashGet = 0;
    [SerializeField] public int carHitSubtract = 100;
    [SerializeField] public int car1Place = 10000;
    [SerializeField] public int car2Place = 8000;




    [SerializeField] public bool alreadyGetFirst = false;
    [SerializeField] public bool alreadyGetSecond = false;



    public void Start()
    {
        aIFINISH = FindObjectOfType<AIFINISH>();
    }

    public void Update()
    {
        cashText.text = currentMoney.ToString();
        racePlace();
    }

    public void racePlace()
    {
        if(aIFINISH.playerFinish == true & aIFINISH.secondPlace == true & alreadyGetSecond == false)
        {                     
                cashGet += car2Place;
                alreadyGetSecond = true;                   
        }

        if (aIFINISH.playerFinish == true & aIFINISH.secondPlace == false & alreadyGetFirst == false)
        {
            cashGet += car1Place;
            alreadyGetFirst = true;
        }
       
    }
       
}
