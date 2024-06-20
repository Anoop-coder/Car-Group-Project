using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public void LoadShopScene()
    {
        SceneManager.LoadScene("Shop");
    }


    public void LoadShop2Scene()
    {
        SceneManager.LoadScene("Shop 2");
    }

    public void LoadLevelSelectScene()
    {
        SceneManager.LoadScene("Level Select");
    }
    public void LoadLevelSelectChargerScene()
    {
        SceneManager.LoadScene("Level Select charger");
    }
    public void LoadShopLevelSelectkoinsScene()
    {
        SceneManager.LoadScene("Level Select koins");
    }

    public void Level1()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void Level2()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void Level3()
    {
        SceneManager.LoadScene("Level 3");
    }

    public void StartScene()
    {
        SceneManager.LoadScene(0);
    }
}
