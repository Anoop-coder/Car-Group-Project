using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    float time;

    private void Update()
    {
        StartCoroutine(Stopwatch());
      
    }

    IEnumerator Stopwatch()
    {
        yield return new WaitForSeconds(3);
        time += Time.fixedDeltaTime;
        
        timerText.text = time.ToString("F2");
    }
}
