using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cash : MonoBehaviour
{
    AIFINISH aIFINISH;

    [SerializeField] TextMeshProUGUI cashText;
    [SerializeField] public static int currentMoney = 0;
    [SerializeField] public int cashGet = 0;
    [SerializeField] public int carHitSubtract = 100;
    [SerializeField] public int car1Place = 25000;
    [SerializeField] public int car2Place = 20000;
    int waitTime = 2;




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
        if(aIFINISH.playerFinish == true & aIFINISH.secondPlace == true & alreadyGetSecond == false & alreadyGetFirst == false)
        {                     
            cashGet += car2Place;
            currentMoney += cashGet;
            alreadyGetSecond = true;
            StartCoroutine(Lose());
            
        }

        if (aIFINISH.playerFinish == true & aIFINISH.secondPlace == false & alreadyGetFirst == false & alreadyGetSecond == false)
        {
            cashGet += car1Place;
            currentMoney += cashGet;
            alreadyGetFirst = true;
            StartCoroutine(Cutscene());
        }

        IEnumerator Lose()
        {
            
            yield return new WaitForSeconds(waitTime);
            SceneManager.LoadScene("Lose Scene");
        }

        IEnumerator Cutscene()
        {
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            if(currentScene < 4)
            {
                yield return new WaitForSeconds(waitTime);
                SceneManager.LoadScene("Cutscene 1");
            }
           
        }
       
    }
       
}
