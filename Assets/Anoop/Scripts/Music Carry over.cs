using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicCarryover1 : MonoBehaviour
{

    public static MusicCarryover1 instance;
    private void Awake()
    {
        if(instance != null) 
        Destroy(gameObject);
        
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
