using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialoguetrigger2 : MonoBehaviour
{
    public Dialogue dialogue;

    public void trggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue); 
    }

    public void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
