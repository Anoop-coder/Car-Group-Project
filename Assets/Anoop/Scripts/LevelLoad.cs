using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoad : MonoBehaviour
{
    
    public void LoadLevell()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void LoadLevel1Charge()
    {
        SceneManager.LoadScene("Level 1 Charger");
    }
    public void LoadLevel1koins()
    {
        SceneManager.LoadScene("Level 1 koins");
    }
    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level 2");
    }
    public void LoadLevel2charge()
    {
        SceneManager.LoadScene("Level 2 charger");
    }
    public void LoadLevel2koin()
    {
        SceneManager.LoadScene("Level 2 koin");
    }
}
