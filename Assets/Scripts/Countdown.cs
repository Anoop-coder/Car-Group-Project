using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    Movement movement;
    [SerializeField] TMP_Text timeText;
    [SerializeField] GameObject goText;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip timeClip;
    float timeCount = 4f;
    float timeSubtract = 1f;
    // Start is called before the first frame update
    void Start()
    {
        movement =  FindObjectOfType<Movement>();
        audioSource.PlayOneShot(timeClip);
        StartCoroutine(Time());
        
        movement.enabled = false;
        goText.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        timeText.text = timeCount.ToString();
        StartCoroutine(Go());
    }

    IEnumerator Go()
    {
        if(timeCount == 0)
        {
            goText.SetActive(true);
            yield return new WaitForSeconds(1);
            goText.SetActive(false);
        }
    }
    IEnumerator Time()
    {
       
        timeCount = timeCount - timeSubtract;
        timeText.text = timeCount.ToString();
        yield return new WaitForSeconds(1);
        
        if(timeCount == 1)
        {
            
            timeText.enabled = false;
            movement.enabled = true;

        }
        StartCoroutine(Time());
    }
}
