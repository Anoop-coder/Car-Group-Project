using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CashSystem : MonoBehaviour
{
   public TMP_Text moneyText;
   [SerializeField] public int money = 0;
   [SerializeField] public int addMoney = 25000;
    // Start is called before the first frame update

    public void Start()
    {
        StartCoroutine(MoneyTime());
    }
    IEnumerator MoneyTime()
   {
        yield return new WaitForSeconds(5);
        money += addMoney;
        moneyText.text = money.ToString();
        
        Debug.Log("AddedMoney");
   }
}
