using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueDelay : MonoBehaviour
{
    public GameObject dialogueCanvas;

    IEnumerator delayDialogue()
    {
        dialogueCanvas.SetActive(false);
        yield return new WaitForSeconds(8);
        dialogueCanvas.SetActive(true);
    }
   
}
