using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadAnoopScene()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadVerticalSliceScene()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadShop2Scene()
    {
        SceneManager.LoadScene(5);
    }

    public void LoadShopScene()
    {
        SceneManager.LoadScene(4);
    }
    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadShop3Scene()
    {
        SceneManager.LoadScene(6);
    }
}
