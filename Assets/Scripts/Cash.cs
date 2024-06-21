using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cash : MonoBehaviour
{
    AIFINISH aIFINISH;

    [SerializeField] TextMeshProUGUI cashText;
  
    [SerializeField] public int cashGet = 0;
    [SerializeField] public int carHitSubtract = 100;
    [SerializeField] public int car1Place = 27500;
    [SerializeField] public int car2Place = 17500;
    int waitTime = 2;




    [SerializeField] public bool alreadyGetFirst = false;
    [SerializeField] public bool alreadyGetSecond = false;



    public void Start()
    {
        aIFINISH = FindObjectOfType<AIFINISH>();
    }

    public void Update()
    {
        cashText.text = "Cash: " + SaveManager.instance.money.ToString();
        racePlace();
    }

    public void racePlace()
    {
        if (aIFINISH.playerFinish == true & aIFINISH.secondPlace == true & alreadyGetSecond == false & alreadyGetFirst == false)
        {
            cashGet += car2Place;
            SaveManager.instance.money += cashGet;
            SaveManager.instance.Save();
            alreadyGetSecond = true;
            StartCoroutine(Lose());

        }

        if (aIFINISH.playerFinish == true & aIFINISH.secondPlace == false & alreadyGetFirst == false & alreadyGetSecond == false)
        {
            cashGet += car1Place;
            SaveManager.instance.money += cashGet;
            SaveManager.instance.Save();
            alreadyGetFirst = true;
            StartCoroutine(Cutscene());
        }

        IEnumerator Lose()
        {
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            yield return new WaitForSeconds(waitTime);

            if(currentScene < 4)
            {
                SceneManager.LoadScene("Lose Scene");
            }

            if (currentScene >=  4 & currentScene < 7)
            {
                SceneManager.LoadScene("Lose Scene 1");
            }

            if (currentScene > 7)
            {
                SceneManager.LoadScene("Lose Scene 2");
            }

        }

        IEnumerator Cutscene()
        {
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            if (currentScene < 4)
            {
                yield return new WaitForSeconds(waitTime);
                SceneManager.LoadScene("Cutscene 1");
            }

            if (currentScene  >=  4 & currentScene < 7)
            {
                yield return new WaitForSeconds(waitTime);
                SceneManager.LoadScene("Cutscene for level 2");
            }

            if (currentScene > 7)
            {
                SceneManager.LoadScene("Cutscene for level 3");
            }



        }

    }

}
