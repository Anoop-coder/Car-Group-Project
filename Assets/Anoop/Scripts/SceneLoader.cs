using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    

   

    public void LoadShop2Scene()
    {
        SceneManager.LoadScene("Shop 2");
    }

    public void LoadShopScene()
    {
        SceneManager.LoadScene("Shop");
    }
    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadShop3Scene()
    {
        SceneManager.LoadScene("Shop 3");
    }
}
