using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyCounter : MonoBehaviour
{
    private TextMeshProUGUI txt;
    private void Awake()
    {
        txt =  GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        txt.text = SaveManager.instance.money + "$";
    }
}
