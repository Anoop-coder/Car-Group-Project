using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuySystem : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI mustangChangeText;
    [SerializeField] TextMeshProUGUI koinChangeText;

    int mustangCost = 25000;
    int koinCost = 70000;

   
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BuyMustang();
    }

    public void BuyMustang()
    {
        if(Cash.currentMoney >= mustangCost)
        {

        }
    }
}
