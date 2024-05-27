using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    public Behaviour gameObject;
    [SerializeField] TMP_Text timeText;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip timeClip;
    float timeCount = 3f;
    float timeSubtract = 1f;
    // Start is called before the first frame update
    void Start()
    {
       gameObject =  GetComponent<Behaviour>();
        audioSource.PlayOneShot(timeClip);
        StartCoroutine(Time());
        gameObject.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        timeText.text = timeCount.ToString();
    }

    IEnumerator Time()
    {
        
        timeCount = timeCount - timeSubtract;
        yield return new WaitForSeconds(1);
        
        if(timeCount == 0)
        {
            gameObject.enabled = true;

        }
        StartCoroutine(Time());
    }
}
